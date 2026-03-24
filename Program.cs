using System;

namespace BoringRPG
{
  internal class Program
  {
    static void Main(string[] args)
    {
      string critText;
      int beforeHP, damage;
      
      DummyClass lancelot = new DummyClass("Ланселот Ловкий");
      Cleric danila = new Cleric("Даня");

      HealthPotion healthPotion = new HealthPotion(1000);
      ManaPotion manaPotion = new ManaPotion(1000);;
      AmmoPack ammoPack = new AmmoPack(1000);
      RagePie ragePie = new RagePie(1000);

      Skill soulLink = new SoulLink("Связь души", 20);
      Skill lastStand = new LastStand("Последний бой", 10);
      Skill manaDrain = new ManaDrain("Истощение маны", 50);
      Skill destinyShuffle = new DestinyShuffle("Неотвратимая судьба", 99);

      Console.WriteLine($"Битва началась! Состояние персонажей:\n" +
                        $"=====================================\n" +
                        $"{lancelot.GetInfo()}\n" +
                        $"{danila.GetInfo()}\n" +
                        $"\n{danila.Name} атакует {lancelot.Name}!\n");

      beforeHP = lancelot.HP;
      danila.Hit(lancelot);
      damage = beforeHP - lancelot.HP;

      critText = danila.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"{danila.Name} использует скилл {soulLink.Name}\n");
      danila.UseSkill(soulLink, lancelot);

      Console.WriteLine($"{lancelot.Name} использует скилл {lastStand.Name}\n");
      lancelot.UseSkill(lastStand, danila);

      Console.WriteLine($"{danila.Name} использует скилл {manaDrain.Name}\n");
      danila.UseSkill(manaDrain, lancelot);

      Console.WriteLine($"{lancelot.Name} использует скилл {destinyShuffle.Name}\n");
      lancelot.UseSkill(destinyShuffle, danila);

      Console.WriteLine($"Нанесено {damage} урона{critText}\n" +
                        $"\nСостояние персонажей:\n" +
                        $"=====================\n" +
                        $"{lancelot.GetInfo()}\n" +
                        $"{danila.GetInfo()}\n" +
                        $"\nОбнаружено внешнее вмешательство!\n" +
                        $"ХП {danila.Name} уменьшено на 10");
      
      danila -= 10;

      Console.WriteLine($"Текущее ХП {danila.Name}: {danila.HP}\n" +
                        $"\nХП {danila.Name} увеличено на 100");

      danila += 100;

      Console.WriteLine($"Текущее ХП {danila.Name}: {danila.HP}\n" +
                        $"\nПроверка на живучесть:");

      if (danila)
      {
        Console.WriteLine($"{danila.Name} ещё живой\n");
      }
      else
      {
        Console.WriteLine($"{danila.Name} вернулся в объятия богини. " +
                          $"Его боевой дух будут помнить вечно\n");
      }

      Console.WriteLine("Нанесён смертельный урон\n");
      danila -= 1000;

      Console.WriteLine($"{danila.Name} использует лечебное зелье, здоровье восполнено!\n");
      danila += healthPotion;

      Console.WriteLine($"{danila.Name} использует зелье маны, мана восполнена!\n");
      danila += manaPotion;

      Console.WriteLine($"{danila.Name} использует комплект боеприпасов, боеприпасы восполнены!\n");
      danila += ammoPack;

      Console.WriteLine($"{danila.Name} использует пирог ярости, характеристики увеличены!\n");
      danila += ragePie;

      if (danila)
      {
        Console.WriteLine($"{danila.Name} ещё живой\n");
      }
      else
      {
        Console.WriteLine($"{danila.Name} вернулся в объятия богини. " +
                          $"Его боевой дух будут помнить вечно\n");
      }

      Console.WriteLine($"Битва окончена. Состояние персонажей:\n" +
                        $"=====================================\n" +
                        $"{lancelot.GetInfo()}\n" +
                        $"{danila.GetInfo()}\n" +
                        $"Нажмите любую клавишу, чтобы продолжить...");

      Console.ReadKey();
    }
  }
}