using System;

namespace BoringRPG {
  internal abstract class ConsumableItem {
    public int Value { get; protected set; }

    public ConsumableItem(int value) {
      Value = value;
    }

    public abstract string GetDescription();
  }
}