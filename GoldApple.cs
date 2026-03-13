using System;

namespace BoringRPG {
  public class GoldApple : ConsumableItem {

    public GoldApple (int value) : base (value) {
    }

    public override string GetEffectDescription() {
      return $"Восстанавливает {Value} HP и увеличивает количество маны на {Value * 3}";
    }
  }
}
