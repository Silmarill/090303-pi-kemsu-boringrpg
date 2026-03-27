namespace BoringRPG {
  internal class HealthPotion : ConsumableItem {
    public HealthPotion(int value) : base(value) { }

    public override void Apply(Archetype hero) {
      hero.HP += Value;
    }
  }
}