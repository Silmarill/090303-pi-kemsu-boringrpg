using System;

namespace BoringRPG {
  public class DivineTalisman : ConsumableItem {
    public int DivineCharge { get; private set; }

    public DivineTalisman(int value) : base("Divine Talisman", value) {
      DivineCharge = value * 3;
    }

    public override string GetDescription() {
      return $"Sacred artifact! Has {DivineCharge} divine energy. Can bless or curse!";
    }

    public void ReduceCharge(int amount) {
      DivineCharge -= amount;
    }
  }
}