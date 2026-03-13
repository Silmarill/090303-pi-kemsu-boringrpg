using System;

namespace BoringRPG {
  internal class HealthPotion : ConsumableItem {
    public HealthPotion(int value) : base(value) { }

    public override string GetDescription() {
      return $"Зелье здоровья (+{Value} HP)";
    }
  }

  internal class ManaPotion : ConsumableItem {
    public ManaPotion(int value) : base(value) { }

    public override string GetDescription() {
      return $"Зелье маны (+{Value} MP)";
    }
  }

  internal class AmmoPack : ConsumableItem {
    public AmmoPack(int value) : base(value) { }

    public override string GetDescription() {
      return $"Патроны (+{Value} Ammo)";
    }
  }

  internal class BugPotion : ConsumableItem {
    private static Random random = new Random();

    public BugPotion() : base(0) {
      Value = random.Next(1, 11);
    }

    public override string GetDescription() {
      return $"Зелье-баг (случайный эффект: {Value})";
    }
  }
}