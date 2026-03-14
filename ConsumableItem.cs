using System;

namespace BoringRPG {
  public abstract class ConsumableItem {
    public int Value;

    public ConsumableItem(int value)
    {
      Value = value;
    }
  }
}