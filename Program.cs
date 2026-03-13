using System;
using System.Text;

namespace BoringRPG
{
  internal class Program
  {
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

      while (archer)
      {
        if (lancelot.HP <= 0)
        {
          Console.WriteLine("\nGAME END!\n" + "======================");
          Console.WriteLine($"{archer.Name} wins!");

          break;
        }

        Console.WriteLine($"\nROUND {roundNumber}:\n" + "======================");

        Console.WriteLine($"{lancelot.Name} attacks {archer.Name}!");

        beforeHPInkoromi = archer.HP;
        lancelot.Hit(archer);
        damageLancelot = beforeHPInkoromi - archer.HP;

        critTextLancelot = lancelot.lastHitWasCrit ? " - CRITICAL HIT!" : "";

        Console.WriteLine($"Damage dealt {damageLancelot} {critTextLancelot}\n");

        if (archer.HP <= 0)
        {
          Console.WriteLine("\nGAME END!\n" + "======================");
          Console.WriteLine($"{lancelot.Name} wins!");

          break;
        }

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

        Console.WriteLine("FINAL STATE:");
        Console.WriteLine("======================");
        Console.WriteLine(lancelot.GetInfo());
        Console.WriteLine(archer.GetInfo());
        Console.ReadKey();

        ++roundNumber;
      }
    }
  }
}


