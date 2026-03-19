using System;

namespace BoringRPG {
  internal class ManaPotion : ConsumableItem {
    public ManaPotion(int value) : base(value) {
    }
    public static Warrior operator +(Warrior hero, ManaPotion mana) {
      hero.MP += mana.Value;
      return hero;
    }
    public static DummyClass operator +(DummyClass hero, ManaPotion mana) {
      hero.MP += mana.Value;
      return hero;
    }
  }
}
