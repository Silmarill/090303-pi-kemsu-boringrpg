namespace BoringRPG {
  internal class ManaPotion : ConsumableItem {
    public ManaPotion(int value) : base(value) { }

    public override void Apply(Archetype hero) {
      hero.MP += Value;
    }
  }
}