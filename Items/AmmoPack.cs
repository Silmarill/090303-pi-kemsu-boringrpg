using BoringRPG;

internal class AmmoPack : ConsumableItem {
  public AmmoPack(int value) : base(value) { }
  public override void Apply(Archetype hero) {
    hero.Ammo += Value;
  }
}