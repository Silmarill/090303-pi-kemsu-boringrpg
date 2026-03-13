using System;

namespace BoringRPG {
  public class DoubleEspresso : ConsumableItem {
    public DoubleEspresso(int value) : base(value) { }

    public override void ApplyEffect(Archetype hero)
    {
      hero.Damage += Value;
      hero.HP -= Value / 2;
    }

    public static DoubleEspresso operator *(DoubleEspresso coffee, int multiplier)
    {
      return new DoubleEspresso(coffee.Value * multiplier);
    }
  }

  public class MysteryCookie : ConsumableItem {
    private static Random random = new Random();

    public MysteryCookie(int value) : base(value) { }

    public override void ApplyEffect(Archetype hero)
    {
      int effect = random.Next(4);
      switch (effect)
      {
        case 0:
          hero.HP += Value * 2;
          Console.WriteLine(" Вкуснятина! Здоровье восстановлено!");
          break;
        case 1:
          hero.MP += Value;
          Console.WriteLine(" Магическая начинка! Мана восстановлена!");
          break;
        case 2:
          hero.Ammo += Value;
          Console.WriteLine(" Хрустящие патроны! Боезапас пополнен!");
          break;
        case 3:
          hero.Damage += Value / 2;
          hero.HP -= Value / 4;
          Console.WriteLine(" Острое печенье! Урон увеличен, но здоровье пострадало!");
          break;
      }
    }

    public static MysteryCookie operator %(MysteryCookie cookie, int divisor)
    {
      return new MysteryCookie(cookie.Value / divisor);
    }
  }
}