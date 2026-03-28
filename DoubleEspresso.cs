using System;

namespace BoringRPG {
  public class DoubleEspresso : ConsumableItem {
    public DoubleEspresso(int value) : base(value) { }

    public static DoubleEspresso operator *(DoubleEspresso coffee, int multiplier)
    {
      return new DoubleEspresso(coffee.Value * multiplier);
    }
  }
}