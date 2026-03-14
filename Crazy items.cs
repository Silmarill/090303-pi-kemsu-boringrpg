using System;

namespace BoringRPG {
  public class DoubleEspresso : ConsumableItem {
    public DoubleEspresso(int value) : base(value) { }

    public static DoubleEspresso operator *(DoubleEspresso coffee, int multiplier)
    {
      return new DoubleEspresso(coffee.Value * multiplier);
    }
  }

  public class MysteryCookie : ConsumableItem {
    private static Random random = new Random();

    public MysteryCookie(int value) : base(value) { }

    public static MysteryCookie operator %(MysteryCookie cookie, int divisor)
    {
      return new MysteryCookie(cookie.Value / divisor);
    }
  }
}