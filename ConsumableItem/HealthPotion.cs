using System;

namespace BoringRPG {
  public class HealthPotion : ConsumableItem {
    public HealthPotion(int value) : base("Health Potion", value) {
    }

    public override string GetDescription() {
      return $"Restores {Value} HP";
    }
  }
}