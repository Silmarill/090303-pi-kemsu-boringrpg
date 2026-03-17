using System;

namespace BoringRPG {
  public class StrengthPotion : ConsumableItem {
    public StrengthPotion(int value) : base("Strength Potion", value) {
    }

    public override string GetDescription() {
      return $"Увеличивает урон на {Value}";
    }

    public static Cleric operator +(Cleric hero, StrengthPotion potion) {
      hero.Damage += potion.Value;

      Console.WriteLine($"{hero.Name} выпивает {potion.Name} и получает +{potion.Value} к урону!");
      return hero;
    }
    
    public static DummyClass operator +(DummyClass hero, StrengthPotion potion) {
      hero.Damage += potion.Value;

      Console.WriteLine($"{hero.Name} выпивает {potion.Name} и получает +{potion.Value} к урону!");
      return hero;
    }
  }
}