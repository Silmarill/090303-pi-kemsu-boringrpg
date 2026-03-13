using System;

namespace BoringRPG {
  public abstract class ConsumableItem {

    public int Value;

    protected ConsumableItem(int value) {
      Value = value;
    }

    public abstract string GetEffectDescription() {
    }
  }
}
