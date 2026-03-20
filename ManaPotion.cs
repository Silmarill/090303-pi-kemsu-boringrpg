using System;

namespace BoringRPG {
  public class ManaPotion : ConsumableItem {
    public ManaPotion(int value) : base("Mana Potion", value) {
    }

    public override string GetDescription() {
      return $"Restores {Value} MP";
    }
  }
}