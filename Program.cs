using System;
using System.Security.Cryptography;
using System.Xml.Linq;

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
      }
      else
      {
        Console.WriteLine($"{archer.Name} calmly reached the enemy");
      }

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

        critTextLancelot = lancelot.LastHitWasCrit ? " - CRITICAL HIT!" : "";

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

        critTextInkoromi = archer.LastHitWasCrit ? " - CRITICAL HIT!" : "";

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


