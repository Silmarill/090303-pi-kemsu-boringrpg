using System;

namespace BoringRPG {
  internal class ManaPotion : ConsumableItem {

    public ManaPotion(int value) : base(value) {
    }

    public override string GetEffectDescription() {
      return $"Восстанавливает {Value} MP";
    }
  }
}
