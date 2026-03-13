using System;

namespace BoringRPG {
  internal class HealthPotion : ConsumableItem {
    public HealthPotion(int value) : base(value) {
    }

    public override void ApplyEffect(Archetype target) {
      target.HP += value;
      Console.WriteLine($"{target.Name} восстановил {value} HP");
    }
  }
}