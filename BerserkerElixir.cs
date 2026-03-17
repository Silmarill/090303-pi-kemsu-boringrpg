using System;

namespace BoringRPG
{
  internal class BerserkerElixir : ConsumableItem
  {
    public BerserkerElixir() : base(20)
    {
    }

    public override string GetDescription()
    {
      return $"Эликсир берсерка: -20 HP, +15 к урону";
    }
  }
}
