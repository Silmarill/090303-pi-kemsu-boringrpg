using System;

namespace BoringRPG {
  internal class ManaPotion : ConsumableItem {
    public ManaPotion(int value) : base(value) {
    }

    public override void ApplyEffect(Archetype target) {
      target.MP += value;
      Console.WriteLine($"{target.Name} восстановил {value} MP");
    }
  }
}