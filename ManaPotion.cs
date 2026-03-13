using System;

namespace BoringRPG {
  public class ManaPotion : ConsumableItem {
    public ManaPotion(int value) : base(value)
    {
    }

    public override void ApplyEffect(Archetype hero)
    {
      hero.MP += Value;
      Console.WriteLine($" {hero.Name} восстанавливает {Value} маны!");
    }
  }
}