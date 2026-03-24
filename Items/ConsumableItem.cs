using System;

namespace BoringRPG.Items
{
  internal abstract class ConsumableItem
  {
    public int Value;

    protected ConsumableItem(int value)
    {
      Value = value;
    }
  }
}