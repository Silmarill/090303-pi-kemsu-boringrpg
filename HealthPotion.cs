using System;

namespace BoringRPG {
  public class HealthPotion : ConsumableItem {
    public HealthPotion(int value) : base(value)
    {
    }

    public override void ApplyEffect(Archetype hero)
    {
      hero.HP += Value;
      Console.WriteLine($" {hero.Name} восстанавливает {Value} здоровья!");
    }
  }
}