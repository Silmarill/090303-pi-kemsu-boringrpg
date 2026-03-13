using System;

namespace BoringRPG {
  internal class HealthPotion : ConsumableItem {

    public HealthPotion(int value) : base(value) { 
    }

    public override string GetEffectDescription() {
      return $"Восстанавливает {Value} HP";
    }     
  }
}
