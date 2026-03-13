using System;

namespace BoringRPG {
  public class AmmoPack : ConsumableItem {

    public AmmoPack(int value) : base(value) {
    }

    public override string GetEffectDescription() {
      return $"Добавляет {Value} патронов";
    }
  }
}
