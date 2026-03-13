using System;

namespace BoringRPG {
  internal class BugPotion : ConsumableItem {
    public BugPotion(int value) : base(value) {
    }

    public static BugPotion operator++ (BugPotion potion) {
      potion.Value *= 2;
      Console.WriteLine($"Огуречный рассол усилен! Теперь сила: {potion.Value}");
      return potion;
    }
  }
}