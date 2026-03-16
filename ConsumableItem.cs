using System;

namespace BoringRPG {
  public abstract class ConsumableItem {
    public int Value { get; set; }
    public ConsumableItem(int value) {
      Value = value;
    }
  }
}
