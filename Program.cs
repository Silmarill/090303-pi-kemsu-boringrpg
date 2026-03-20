using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      Console.WriteLine("=== CREATING HEROES ===");
      Cleric cleric = new Cleric("Ambrosius");
      DummyClass warrior = new DummyClass("Brunhilda");

      Console.WriteLine(cleric.GetInfo());
      Console.WriteLine(warrior.GetInfo());

      Console.WriteLine("\n=== DEMONSTRATION OF ITEMS ===");

      HealthPotion healthPotion = new HealthPotion(30);
      Console.WriteLine($"\nItem found: {healthPotion.Name} - {healthPotion.GetDescription()}");
      cleric = cleric + healthPotion;
      Console.WriteLine(cleric.GetInfo());

      ManaPotion manaPotion = new ManaPotion(25);
      Console.WriteLine($"\nItem found: {manaPotion.Name} - {manaPotion.GetDescription()}");
      cleric = cleric + manaPotion;
      Console.WriteLine(cleric.GetInfo());

      StrengthPotion strengthPotion = new StrengthPotion(5);
      Console.WriteLine($"\nItem found: {strengthPotion.Name} - {strengthPotion.GetDescription()}");
      warrior = warrior + strengthPotion;
      cleric = cleric + strengthPotion;
      Console.WriteLine(warrior.GetInfo());
      Console.WriteLine(cleric.GetInfo());

      Console.WriteLine("\n=== DEMONSTRATION OF CRAZY ITEM (DIVINE TALISMAN) ===");

      DivineTalisman talisman = new DivineTalisman(10);
      Console.WriteLine($"\nItem found: {talisman.Name} - {talisman.GetDescription()}");
      Console.WriteLine($"Divine energy: {talisman.DivineCharge}");

      Console.WriteLine("\n1. Blessing (+):");
      cleric = cleric + talisman;
      Console.WriteLine(cleric.GetInfo());

      Console.WriteLine("\n2. Curse (-):");
      warrior = warrior - talisman;
      Console.WriteLine(warrior.GetInfo());

      Console.WriteLine("\n3. Divine Intervention (*):");
      Console.WriteLine("First try:");
      cleric = cleric * talisman;
      Console.WriteLine(cleric.GetInfo());

      Console.WriteLine("\n=== DEMONSTRATION OF TRUE/FALSE OPERATORS ===");
      
      if (cleric) {
        Console.WriteLine("Cleric is alive and ready for adventure!");
      } else {
        Console.WriteLine("Cleric is dead...");
      }

      if (warrior) {
        Console.WriteLine("Warrior is alive!");
      } else {
        Console.WriteLine("Warrior is dead...");
      }

      Console.WriteLine("\n=== FINAL STATE OF HEROES ===");
      Console.WriteLine(cleric.GetInfo());
      Console.WriteLine(warrior.GetInfo());

      Console.ReadKey();
    }
  }
}