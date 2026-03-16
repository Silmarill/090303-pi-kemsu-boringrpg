using System;
using System.Net.Http.Headers;

namespace BoringRPG {
  internal class Program
  {
    static void Main(string[] args)
    {
      string critText;
      int beforeHP, damage;

      DummyClass lancelot = new DummyClass("Lancelot is clever");
      DummyClass artur = new DummyClass("Arthur Pendragon");
      Paladin paladin = new Paladin("Mateus Paladinov");

      HealthPotion health = new HealthPotion(25);
      ManaPotion mana = new ManaPotion(10);
      AmmoPack ammo = new AmmoPack(10);
      CrabSticks crab = new CrabSticks(10);

      Console.WriteLine($"\nThe paladin found a crab stick under a stone and ate it +{crab.Value}:");
      paladin += crab;
      Console.WriteLine(paladin.GetInfo());

      Console.WriteLine($"\nPaladin use Mana potion +{mana.Value}:");
      paladin += mana;
      Console.WriteLine(paladin.GetInfo());

      Console.WriteLine($"\nPaladin use health potion +{health.Value}:");
      paladin += health;
      Console.WriteLine(paladin.GetInfo());

      Console.WriteLine($"\nThe paladin picks up a box of ammunition, but why does he need it? +{ammo.Value}:");
      paladin += ammo;
      Console.WriteLine(paladin.GetInfo());

      Console.WriteLine($"\nBEGINNING OF THE BATTLE. Initial state: \n" +
                        $"==================\n" +
                        $"{lancelot.GetInfo()}\n" +
                        $"{artur.GetInfo()}\n" +
                        $"{paladin.GetInfo()}\n");


      Console.WriteLine($"{lancelot.Name} attacks {artur.Name}!");

      beforeHP = artur.HP;
      lancelot.Hit(artur);
      damage = beforeHP - artur.HP;

      critText = lancelot.LastHitWasCrit ? "- CRITICAL HIT!" : "";

      Console.WriteLine($"Damage {damage} dealt {critText}\n");


      Console.WriteLine($"{paladin.Name} attacks {lancelot.Name}!");

      beforeHP = lancelot.HP;
      paladin.Hit(lancelot);
      damage = beforeHP - lancelot.HP;

      critText = paladin.LastHitWasCrit ? "- CRITICAL HIT!" : "";

      Console.WriteLine($"Damage {damage} dealt {critText}\n");


      Console.WriteLine($"{artur.Name} attacks {paladin.Name}!");

      beforeHP = paladin.HP;
      artur.Hit(paladin);
      damage = beforeHP - paladin.HP;

      critText = artur.LastHitWasCrit ? "- CRITICAL HIT!" : "";

      Console.WriteLine($"Damage {damage} dealt {critText}\n");

      Console.WriteLine("FINAL STATUS:");
      Console.WriteLine("======================");
      Console.WriteLine(lancelot.GetInfo());
      Console.WriteLine(artur.GetInfo());
      Console.WriteLine(paladin.GetInfo());

      Console.WriteLine("\n=== DEMONSTRATION OF OPERATORS +, - AND TRUE/FALSE ===");

      paladin = paladin + 10;
      Console.WriteLine($"After +10 HP: {paladin.GetInfo()}");

      paladin = paladin - 10;
      Console.WriteLine($"After -10 HP: {paladin.GetInfo()}");

      if (paladin)
      {
        Console.WriteLine($"{paladin.Name} is alive!");
      }
      else
      {
        Console.WriteLine($"{paladin.Name} is dead!");
      }
      Console.ReadKey();
    }
  }
}