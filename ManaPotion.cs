using System;

namespace BoringRPG {
  public class ManaPotion : ConsumableItem {
    public ManaPotion(int value) : base("Mana Potion", value) {
    }

    public override string GetDescription() {
      return $"Восстанавливает {Value} MP";
    }

    public static Cleric operator +(Cleric hero, ManaPotion potion) {
      hero.MP += potion.Value;

      if (hero.MP > 80) {
        hero.MP = 80;
      }

      Console.WriteLine($"{hero.Name} выпивает {potion.Name} и восстанавливает {potion.Value} MP!");
      return hero;
    }
    
    public static DummyClass operator +(DummyClass hero, ManaPotion potion) {
      hero.MP += potion.Value;

      if (hero.MP > 50) {
        hero.MP = 50;
      }

      Console.WriteLine($"{hero.Name} выпивает {potion.Name} и восстанавливает {potion.Value} MP!");
      return hero;
    }
  }
}