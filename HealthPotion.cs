using System;


namespace BoringRPG {
  internal class HealthPotion : ConsumableItem {
    public HealthPotion(int value) : base(value) {
    }
    public static Warrior operator +(Warrior hero, HealthPotion healtPotion) {
      hero.HP += healtPotion.Value;
      return hero;
    }
    public static DummyClass operator +(DummyClass hero, HealthPotion healtPotion) {
      hero.HP += healtPotion.Value;
      return hero;
    }
  }
}