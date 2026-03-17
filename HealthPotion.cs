using System;

namespace BoringRPG {
  public class HealthPotion : ConsumableItem {
    public HealthPotion(int value) : base("Health Potion", value) {
    }

    public override string GetDescription() {
      return $"Восстанавливает {Value} HP";
    }

    public static Cleric operator +(Cleric hero, HealthPotion potion) {
      hero.HP += potion.Value;

      if (hero.HP > 75) {
        hero.HP = 75;
      }

      Console.WriteLine($"{hero.Name} выпивает {potion.Name} и восстанавливает {potion.Value} HP!");
      return hero;
    }
    
    public static DummyClass operator +(DummyClass hero, HealthPotion potion) {
      hero.HP += potion.Value;

      if (hero.HP > 100) {
        hero.HP = 100;
      }

      Console.WriteLine($"{hero.Name} выпивает {potion.Name} и восстанавливает {potion.Value} HP!");
      return hero;
    }
  }
}