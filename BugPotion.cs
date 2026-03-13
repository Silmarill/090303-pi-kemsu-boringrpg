using System;

namespace BoringRPG {
  internal class BugPotion : ConsumableItem {
    private static Random random = new Random();

    public BugPotion(int value) : base(value) { }

    public override void ApplyEffect(Archetype target) {
      int effect = random.Next(-value, value + 1);
      target.HP += effect;

      if (effect >= 0) {
        Console.WriteLine($"{target.Name} выпил огуречный рассол и восстановил {effect} HP!");
      } else {
        Console.WriteLine($"{target.Name} выпил огуречный рассол и получил {Math.Abs(effect)} урона!");
      }
    }

    public static BugPotion operator++ (BugPotion potion) {
      potion.value *= 2;
      Console.WriteLine($"Огуречный рассол усилен! Теперь эффект: +-{potion.value}");
      return potion;
    }
  }
}