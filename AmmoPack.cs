using System;

namespace BoringRPG {
  internal class AmmoPack : ConsumableItem {
    public AmmoPack(int value) : base(value) {
    }

    public override void ApplyEffect(Archetype target) {
      target.Ammo += value;
      Console.WriteLine($"{target.Name} получил {value} патронов");
    }
  }
}