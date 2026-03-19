using System;

namespace BoringRPG {
  internal class AmmoPack : ConsumableItem {
    public AmmoPack(int value) : base(value) {
    }

    public static Warrior operator +(Warrior hero, AmmoPack ammo) {
      hero.Ammo += ammo.Value;
      return hero;
    }
    public static DummyClass operator +(DummyClass hero, AmmoPack ammo) {
      hero.Ammo += ammo.Value;
      return hero;
    }
  }
}