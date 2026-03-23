using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      string critText;
      int beforeHP, damage;
      
      DummyClass lancelot = new DummyClass("Ланселот Ловкий");
      Cleric danila = new Cleric("Даня");

      HealthPotion healthPotion = new HealthPotion(1000);
      ManaPotion manaPotion = new ManaPotion(1000);;
      AmmoPack ammoPack = new AmmoPack(1000);
      RagePie ragePie = new RagePie(1000);

      Skill soulLink = new SoulLink("Джин Ранкандел", 20);
      Skill lastStand = new LastStand("Кирито", 10);
      Skill manaDrain = new ManaDrain("Сун Джин Ву", 50);

      Console.WriteLine($"НАЧАЛО БИТВЫ. Состояние персонажей: \n" +
                        $"==================\n" +
                        $"{lancelot.GetInfo()}\n" +
                        $"{danila.GetInfo()}\n");
           
      Console.WriteLine($"{danila.Name} атакует {lancelot.Name}!");

      danila.UseSkill(soulLink, lancelot);
      danila.UseSkill(lastStand, lancelot);
      danila.UseSkill(manaDrain, lancelot);
/*
      beforeHP = lancelot.HP;
      danila.Hit(lancelot);
      damage = beforeHP - lancelot.HP;

      critText = danila.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");
      Console.WriteLine($"СОСТОЯНИЕ ПЕРСОНАЖЕЙ:\n" +
                        $"======================\n" +
                        $"{lancelot.GetInfo()}\n" +
                        $"{danila.GetInfo()}");

      Console.WriteLine($"Тест перегрузки:\n" +
                        $"ХП {danila.Name} уменьшено на 10\n");
      
      // перегрузка оператора -
      danila -= 10;

      Console.WriteLine($"Текущее ХП {danila.Name}: {danila.HP}\n" +
                        $"ХП {danila.Name} увеличено на 100:\n");

      // перегрузка оператора +
      danila += 100;

      Console.WriteLine($"Текущее ХП {danila.Name}: {danila.HP}\n");
      Console.WriteLine("Проверка на живучесть:");

      // перегрузка операторов true/false
      if (danila) {
        Console.WriteLine($"{danila.Name} ещё живой\n");
      }
      else {
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

      if (danila) {
        Console.WriteLine($"{danila.Name} ещё живой\n");
      }
      else {
        Console.WriteLine($"{danila.Name} вернулся в объятия богини. " +
                          $"Его боевой дух будут помнить вечно\n");
      }
*/
      Console.WriteLine($"СОСТОЯНИЕ ПЕРСОНАЖЕЙ:\n" +
                  $"======================\n" +
                  $"{lancelot.GetInfo()}\n" +
                  $"{danila.GetInfo()}");

      Console.Write("Нажмите любую клавишу, чтобы продолжить...");
      Console.ReadKey();
    }
  }
}