using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      var artur = new Necromancer("Artur");
      Console.WriteLine("before using items:");
      Console.WriteLine(artur.GetInfo());

      // Standard items are used via the + operator
      artur = (Necromancer)(artur + new HealthPotion(50));
      artur = (Necromancer)(artur + new ManaPotion(30));

      /*
      A Mad Item (Coffee) is consumed via the * operator
      Critical hit chance is multiplied by 1.5x, at the cost of 10 HP
      */
      artur = (Necromancer)(artur * 1.5);

      Console.WriteLine("\nAfter using items (Potions + Coffee):");
      // In the Necromancer's GetInfo, the critical hit chance should be displayed for better clarity
      Console.WriteLine($"{artur.GetInfo()}, Crit Chance: {artur.CritChance:P0}");

      Console.WriteLine("\nTest complete. Press any key...");
      Console.ReadKey();
    }
  }
}