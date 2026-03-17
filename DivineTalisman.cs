using System;

namespace BoringRPG {
  public class DivineTalisman : ConsumableItem {
    public int DivineCharge { get; private set; }
    private static Random random = new Random();

    public DivineTalisman(int value) : base("Divine Talisman", value) {
      DivineCharge = value * 3;
    }

    public override string GetDescription() {
      return $"Священный артефакт! Имеет {DivineCharge} божественной энергии. Может благословить или проклясть!";
    }

    // Обычное использование - благословение (+)
    public static Cleric operator +(Cleric hero, DivineTalisman talisman) {
      if (talisman.DivineCharge <= 0) {
        Console.WriteLine($"{talisman.Name} не имеет энергии!");
        return hero;
      }

      hero.HP += talisman.Value;
      hero.MP += talisman.Value;
      hero.Damage += talisman.Value / 2;

      if (hero.HP > 75) {
        hero.HP = 75;
      }
      if (hero.MP > 80) {
        hero.MP = 80;
      }

      Console.WriteLine($"{hero.Name} получает благословение от {talisman.Name}!");
      Console.WriteLine($"  HP +{talisman.Value}!");
      Console.WriteLine($"  MP +{talisman.Value}!");
      Console.WriteLine($"  Урон +{talisman.Value / 2}!");
      
      talisman.DivineCharge -= talisman.Value;
      Console.WriteLine($"  Осталось энергии: {talisman.DivineCharge}");
      
      return hero;
    }

    public static DummyClass operator +(DummyClass hero, DivineTalisman talisman) {
      if (talisman.DivineCharge <= 0) {
        Console.WriteLine($"{talisman.Name} не имеет энергии!");
        return hero;
      }

      hero.HP += talisman.Value;
      hero.MP += talisman.Value / 2;
      hero.Damage += talisman.Value;

      if (hero.HP > 100) {
        hero.HP = 100;
      }
      if (hero.MP > 50) {
        hero.MP = 50;
      }

      Console.WriteLine($"{hero.Name} получает благословение от {talisman.Name}!");
      Console.WriteLine($"  HP +{talisman.Value}!");
      Console.WriteLine($"  MP +{talisman.Value / 2}!");
      Console.WriteLine($"  Урон +{talisman.Value}!");
      
      talisman.DivineCharge -= talisman.Value;
      Console.WriteLine($"  Осталось энергии: {talisman.DivineCharge}");
      
      return hero;
    }

    // Безумное использование - проклятие (-)
    public static Cleric operator -(Cleric hero, DivineTalisman talisman) {
      if (talisman.DivineCharge <= 0) {
        Console.WriteLine($"{talisman.Name} не имеет энергии!");
        return hero;
      }

      int cursePower = talisman.Value * 2;
      
      hero.HP -= cursePower;
      hero.MP -= cursePower / 2;
      hero.Damage -= talisman.Value;

      if (hero.HP < 0) {
        hero.HP = 0;
      }
      if (hero.MP < 0) {
        hero.MP = 0;
      }
      if (hero.Damage < 1) {
        hero.Damage = 1;
      }

      Console.WriteLine($"{hero.Name} получает ПРОКЛЯТИЕ от {talisman.Name}!!!");
      Console.WriteLine($"  HP -{cursePower}!");
      Console.WriteLine($"  MP -{cursePower / 2}!");
      Console.WriteLine($"  Урон -{talisman.Value}!");
      
      talisman.DivineCharge -= cursePower;
      Console.WriteLine($"  Осталось энергии: {talisman.DivineCharge}");
      
      return hero;
    }

    public static DummyClass operator -(DummyClass hero, DivineTalisman talisman) {
      if (talisman.DivineCharge <= 0) {
        Console.WriteLine($"{talisman.Name} не имеет энергии!");
        return hero;
      }

      int cursePower = talisman.Value * 2;
      
      hero.HP -= cursePower;
      hero.MP -= cursePower / 2;
      hero.Damage -= talisman.Value;

      if (hero.HP < 0) {
        hero.HP = 0;
      }
      if (hero.MP < 0) {
        hero.MP = 0;
      }
      if (hero.Damage < 1) {
        hero.Damage = 1;
      }

      Console.WriteLine($"{hero.Name} получает ПРОКЛЯТИЕ от {talisman.Name}!!!");
      Console.WriteLine($"  HP -{cursePower}!");
      Console.WriteLine($"  MP -{cursePower / 2}!");
      Console.WriteLine($"  Урон -{talisman.Value}!");
      
      talisman.DivineCharge -= cursePower;
      Console.WriteLine($"  Осталось энергии: {talisman.DivineCharge}");
      
      return hero;
    }

    // Самый безумный эффект - божественное вмешательство (*)
    public static Cleric operator *(Cleric hero, DivineTalisman talisman) {
      if (talisman.DivineCharge <= 0) {
        Console.WriteLine($"{talisman.Name} не имеет энергии!");
        return hero;
      }

      int effect = random.Next(1, 101);
      
      Console.WriteLine($"{hero.Name} активирует БОЖЕСТВЕННОЕ ВМЕШАТЕЛЬСТВО!");
      
      if (effect <= 30) {
        hero.HP = 75;
        hero.MP = 80;
        hero.Damage = 15;
        Console.WriteLine($"ЧУДО! {hero.Name} полностью исцелен божественной силой!");
      } 
      else if (effect <= 60) {
        hero.HP /= 2;
        hero.MP /= 2;
        Console.WriteLine($"ГНЕВ БОЖИЙ! {hero.Name} теряет половину HP и MP!");
      }
      else if (effect <= 85) {
        hero.HP = 999;
        Console.WriteLine($"БЕССМЕРТИЕ! {hero.Name} получает 999 HP (но только на мгновение)!");
      }
      else {
        Console.WriteLine($"ВОЗНЕСЕНИЕ! {hero.Name} покидает этот мир...");
        hero.HP = 0;
      }

      talisman.DivineCharge = 0;
      Console.WriteLine($"  {talisman.Name} исчерпал всю энергию!");
      
      return hero;
    }

    public static DummyClass operator *(DummyClass hero, DivineTalisman talisman) {
      if (talisman.DivineCharge <= 0) {
        Console.WriteLine($"{talisman.Name} не имеет энергии!");
        return hero;
      }

      int effect = random.Next(1, 101);
      
      Console.WriteLine($"{hero.Name} активирует БОЖЕСТВЕННОЕ ВМЕШАТЕЛЬСТВО!");
      
      if (effect <= 30) {
        hero.HP = 100;
        hero.MP = 50;
        hero.Damage = 20;
        Console.WriteLine($"ЧУДО! {hero.Name} полностью исцелен божественной силой!");
      } 
      else if (effect <= 60) {
        hero.HP /= 2;
        hero.MP /= 2;
        Console.WriteLine($"ГНЕВ БОЖИЙ! {hero.Name} теряет половину HP и MP!");
      }
      else if (effect <= 85) {
        hero.HP = 999;
        Console.WriteLine($"БЕССМЕРТИЕ! {hero.Name} получает 999 HP (но только на мгновение)!");
      }
      else {
        Console.WriteLine($"ВОЗНЕСЕНИЕ! {hero.Name} покидает этот мир...");
        hero.HP = 0;
      }

      talisman.DivineCharge = 0;
      Console.WriteLine($"  {talisman.Name} исчерпал всю энергию!");
      
      return hero;
    }
  }
}