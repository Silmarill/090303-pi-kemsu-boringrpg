using System;

namespace BoringRPG {
  public class FatBread : ConsumableItem {
    public FatBread(int value) : base(value) { }
                                                     
    public static Monk operator >(Monk monk, FatBread bread)
    {
      monk.HP += bread.Value;
      monk.MP = Math.Max(0, monk.MP - 10);
      monk.Ammo = Math.Max(0, monk.Ammo - 5);
      Console.WriteLine($" {monk.Name} съел хлеб! +{bread.Value} HP, но -10 MP, -5 патронов");
      return monk;
    }

    public static Monk operator < (Monk monk, FatBread bread)
    {
      return monk;
    }
  }
}