using System;

namespace BoringRPG {
  public class AmmoPack : ConsumableItem {
    public AmmoPack(int value) : base(value)
    {
    }

    public override void ApplyEffect(Archetype hero)
    {
      hero.Ammo += Value;
      Console.WriteLine($" {hero.Name} получает {Value} боеприпасов!");
    }
  }
}