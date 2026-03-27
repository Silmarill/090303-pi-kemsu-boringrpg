using System;
using System.Diagnostics.Eventing.Reader;
using System.Text;
using System.Xml.Linq;

namespace BoringRPG
{
  internal class Program
  {
    public class GameOverException : Exception
    {
      public GameOverException(string message) : base(message) 
      {
      }
    }

    private static void CheckDeath(Archetype firstCharacter, Archetype secondCharacter)
    {
      if (firstCharacter.HP <= 0)
      {
        throw new GameOverException($"{secondCharacter.Name} wins!");
      }
      else if (secondCharacter.HP <= 0)
      {
        throw new GameOverException($"{firstCharacter.Name} wins!");
      }
    }

    static void Main(string[] args)
    {
      string critTextLancelot, critTextInkoromi;
      int beforeHPInkoromi, damageLancelot, beforeHPLancelot, damageInkoromi, roundNumber, randomEventmeaning;

      roundNumber = 1;

      DummyClass lancelot = new DummyClass("Lancelot the Nimble");
      Archer archer = new Archer("inkoromi21");
      Heal healPotion = new Heal(30);
      ManaPotion manaPotion = new ManaPotion(30);
      AmmoPack ammoPack = new AmmoPack(5);
      MaliceInShooting superAbility = new MaliceInShooting(30);
      Skill soulLink = new SoulLink();
      Skill coinOfFate = new CoinOfFate();
      Skill complimentEnemy = new ComplimentEnemy();

      randomEventmeaning = archer.RandomEvent(archer);

      Console.WriteLine($"THE BEGINNING OF THE GAME. Initial state: \n" +
                        $"==================\n" +
                        $"{lancelot.GetInfo()}\n" +
                        $"{archer.GetInfo()}\n");

      if (randomEventmeaning > 0)
      {
        Console.WriteLine($"{archer.Name} finds a health potion! +{randomEventmeaning} HP");
      }
      else if (randomEventmeaning < 0)
      {
        Console.WriteLine($"{archer.Name} stepped into a trap! {randomEventmeaning} HP");

        archer += healPotion;
        Console.WriteLine($"{archer.Name} decided to use a health potion! HP = {archer.HP}\n");

        archer += superAbility;
        Console.WriteLine($"{archer.Name} was trapped and very angry! Damage = {archer.Damage} \n");
      }
      else
      {
        Console.WriteLine($"{archer.Name} calmly reached the enemy");
      }

      archer += manaPotion;
      Console.WriteLine($"{archer.Name} decided to drink a mana potion! MP = {archer.MP} \n");

      archer += ammoPack;
      Console.WriteLine($"{archer.Name} decided to use an additional set of arrows! Ammo = {archer.Ammo}\n");
      
      try
      {
        while (archer)
        {
          CheckDeath(archer, lancelot);

          Console.WriteLine($"\nROUND {roundNumber}:\n" + "======================");

          Console.WriteLine($"{lancelot.Name} attacks {archer.Name}!");

          beforeHPInkoromi = archer.HP;
          lancelot.Hit(archer);
          damageLancelot = beforeHPInkoromi - archer.HP;

          critTextLancelot = lancelot.lastHitWasCrit ? " - CRITICAL HIT!" : "";

          Console.WriteLine($"Damage dealt {damageLancelot} {critTextLancelot}\n");

          Console.WriteLine($"{lancelot.Name} using soul Link in {archer.Name}!\n");
          lancelot.UseSkill(soulLink, archer);
          Console.WriteLine($"health {lancelot.Name} = {lancelot.HP},health {archer.Name} = {archer.HP}!\n");

          Console.WriteLine($"{lancelot.Name} is 'coin of fate' using  on {archer.Name}!\n");
          lancelot.UseSkill(coinOfFate, archer);

          CheckDeath(archer, lancelot);

          lancelot.UseSkill(complimentEnemy, archer);
          Console.WriteLine($"{lancelot.Name} receives an improvement to critical chance and damage\n");
          Console.WriteLine($"Damage {archer.Name} = {archer.Damage}, critical chance = {archer.CritChance}!\n");

          CheckDeath(archer, lancelot);

          Console.WriteLine($"{archer.Name} attacks {lancelot.Name}!");

          beforeHPLancelot = lancelot.HP;
          archer.Hit(lancelot);
          damageInkoromi = beforeHPLancelot - lancelot.HP;

          if (damageInkoromi > 0)
          {
            Console.WriteLine($"{archer.Name} took a shot, number of arrows: {archer.Ammo}");
          }
          else
          {
            Console.WriteLine($"{archer.Name} has no arrows. Damage = 0");
          }

          critTextInkoromi = archer.lastHitWasCrit ? " - CRITICAL HIT!" : "";

          Console.WriteLine($"Damage dealt {damageInkoromi} {critTextInkoromi}\n");

          Console.WriteLine($"{archer.Name} using 'soul link' in {lancelot.Name}!\n");
          archer.UseSkill(soulLink, lancelot);
          Console.WriteLine($"health {archer.Name} = {archer.HP},health {lancelot.Name} = {lancelot.HP}!\n");

          Console.WriteLine($"{archer.Name} is 'coin of fate' using  on {lancelot.Name}!\n");
          archer.UseSkill(coinOfFate, lancelot);

          CheckDeath(archer, lancelot);

          archer.UseSkill(complimentEnemy, lancelot);
          Console.WriteLine($"{archer.Name} receives an improvement to critical chance and damage\n");
          Console.WriteLine($"Damage {lancelot.Name} = {lancelot.Damage}, critical chance = {lancelot.CritChance}!\n");

          Console.WriteLine("FINAL STATE:");
          Console.WriteLine("======================");
          Console.WriteLine(lancelot.GetInfo());
          Console.WriteLine(archer.GetInfo());
          Console.ReadKey();

          ++roundNumber;
        }
      }

      catch (GameOverException ex)
      {
        Console.WriteLine($"\nGAME END!\n======================");
        Console.WriteLine(ex.Message);
      }
    }
  }
}