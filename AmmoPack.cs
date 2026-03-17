using System;

namespace BoringRPG
{
  internal class AmmoPack : ConsumableItem
  {
    public AmmoPack() : base(7)
    {
    }

    public override string GetDescription()
    {
      return $"Ящик с патронами: +{Value} Ammo";
    }
  }
}