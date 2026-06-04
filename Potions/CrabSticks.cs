using System;

namespace BoringRPG
{
  internal class CrabSticks : ConsumableItem
  {
    public CrabSticks(int value = 10) : base(value)
    {
    }

    public static CrabSticks operator ++(CrabSticks crab)
    {
      crab.Value++;
      return crab;
    }
  }
}