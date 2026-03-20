using System;

namespace BoringRPG {
  public class StrengthPotion : ConsumableItem {
    public StrengthPotion(int value) : base("Strength Potion", value) {
    }

    public override string GetDescription() {
      return $"Increases damage by {Value}";
    }
  }
}