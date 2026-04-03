using BoringRPG;

internal class Coffee : ConsumableItem {
  public Coffee(int value) : base(value) { }

  public override void Apply(Archetype hero) {
    hero.CritChance *= Value;
  }
}