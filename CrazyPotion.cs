using System;

namespace BoringRPG
{
  internal class CrazyPotion : ConsumableItem
  {
    public CrazyPotion() : base(50)
    {
    }

    public override string GetDescription()
    {
      return $"БЕЗУМНОЕ ЗЕЛЬЕ: +{Value} HP, +20 к урону!";
    }
  }
}