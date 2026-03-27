using System;

namespace BoringRPG.Items {
  public abstract class ConsumableItem {
    public int Value;

    public ConsumableItem(int value)
    {
      Value = value;
    }
  }
}