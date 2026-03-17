using System;

namespace BoringRPG
{
  internal class ManaPotion : ConsumableItem
  {
    public ManaPotion() : base(10)
    {
    }

    public override string GetDescription()
    {
      return $"Зелье маны: +{Value} MP";
    }
  }
}