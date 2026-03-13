using System;

namespace BoringRPG {
  public class CoffeeCup : ConsumableItem {

    public CoffeeCup (int value) : base (value) {
    }

    public override string GetEffectDescription() {
      return $"Восстанавливает {Value} MP";
    }
  }
}
