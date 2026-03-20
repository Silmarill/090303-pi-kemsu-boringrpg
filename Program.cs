using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      string critText;
      int beforeHP, damage;

      DummyClass lancelot = new DummyClass("Ланселот Ловкий");
      DummyClass artur =    new DummyClass("Артур Пендрагон");
      BerserkerClass berserk = new BerserkerClass("Berserker");

      Console.WriteLine($"НАЧАЛО БИТВЫ. Исходное состояние: \n" +
                               $"==================\n" +
                               $"{lancelot.GetInfo()}\n" +
                               $"{artur.GetInfo()}\n" +
                               $"{berserk.GetInfo()}\n");

      Console.WriteLine($"{lancelot.Name} атакует {artur.Name}!");
      Console.WriteLine($"{berserk.Name} атакует {lancelot.Name}");

      beforeHP = artur.HP;
      lancelot.Hit(artur);
      damage = beforeHP - artur.HP;
      Console.WriteLine("======================");
      beforeHP = lancelot.HP;
      berserk.Hit(lancelot);
      damage = beforeHP - lancelot.HP;

      critText = lancelot.LastHitWasCrit ? " - критический удар!" : "";

      Console.WriteLine("Нанесено " + damage + " урона" + critText + "\n");

      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(lancelot.GetInfo());
      Console.WriteLine(artur.GetInfo());
      Console.WriteLine("======================");
      Console.WriteLine(lancelot.GetInfo());
      Console.WriteLine(berserk.GetInfo());

      // Этап 2: Демонстрация расходников

      Console.WriteLine("\n==========================================");
      Console.WriteLine("ПРИВАЛ. Время расходников.");
      Console.WriteLine("==========================================\n");

      Archetype target;

      Console.WriteLine("До: " + lancelot.GetInfo());
      target = lancelot;
      target += new HealthPotion(40);
      Console.WriteLine("После HealthPotion(40): " + lancelot.GetInfo() + "\n");

      Console.WriteLine("До: " + artur.GetInfo());
      target = artur;
      target += new ManaPotion(30);
      Console.WriteLine("После ManaPotion(30): " + artur.GetInfo() + "\n");

      Console.WriteLine("До: " + berserk.GetInfo());
      target = berserk;
      target += new AmmoPack(5);
      Console.WriteLine("После AmmoPack(5): " + berserk.GetInfo() + "\n");

      Console.WriteLine("До: " + lancelot.GetInfo());
      target = lancelot;
      target *= new CoffeeCup(3);
      Console.WriteLine("После CoffeeCup(3): " + lancelot.GetInfo());
      Console.WriteLine("(тройной эспрессо. Руки дрожат, но крит-шанс утроен.)");


      interface ICanUseSkill {
        void UseSkill()
      }
      Console.ReadKey();
    }
  }
}
