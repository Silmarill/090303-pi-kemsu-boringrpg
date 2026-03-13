using System;

namespace BoringRPG {
  public abstract class ConsumableItem {
    public int Value { get; protected set; }

    public ConsumableItem(int value) {
      Value = value;
    }

    public abstract string GetDescription();
  }
}