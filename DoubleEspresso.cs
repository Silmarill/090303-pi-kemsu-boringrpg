using System;

namespace BoringRPG {
  public class DoubleEspresso : ConsumableItem {
    public DoubleEspresso(int value) : base(value) { }

    public static DoubleEspresso operator *(DoubleEspresso coffee, int multiplier)
    {
      return new DoubleEspresso(coffee.Value * multiplier);
    }

    public static Druid operator >(Druid druid, DoubleEspresso coffee)
    {
      druid.Damage += coffee.Value;
      druid.HP -= coffee.Value / 2;
      druid.MP += coffee.Value / 2;
      Console.WriteLine($" {druid.Name} выпил двойной эспрессо! Урон +{coffee.Value}, " +
                       $"здоровье -{coffee.Value / 2}, мана +{coffee.Value / 2}");
      return druid;
    }

    public static Druid operator <(Druid druid, DoubleEspresso coffee)
    {
      return druid;
    }
  }
}