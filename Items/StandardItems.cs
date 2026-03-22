namespace BoringRPG {
  // Heal
  internal class HealthPotion : ConsumableItem {
    public HealthPotion(int value) : base(value) { }
    public override void Apply(Archetype hero) {
      hero.HP += Value;
    }
  }

  // Mana
  internal class ManaPotion : ConsumableItem {
    public ManaPotion(int value) : base(value) { }
    public override void Apply(Archetype hero) {
      hero.MP += Value;
    }
  }

  // Ammo
  internal class AmmoPack : ConsumableItem {
    public AmmoPack(int value) : base(value) { }
    public override void Apply(Archetype hero) {
      hero.Ammo += Value;
    }
  }
}