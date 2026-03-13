using System;

namespace BoringRPG {
  internal abstract class ConsumableItem {
    public int value { get; set; }

    public ConsumableItem(int inputValue) {
      value = inputValue;
    }

    public abstract void ApplyEffect(Archetype target){
    }
  }
}