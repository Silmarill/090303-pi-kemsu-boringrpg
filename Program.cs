using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      string critText;
      int beforeHP, damage;
      
      Cleric lancelot = new Cleric("Чел");
      DummyClass artur =    new DummyClass("Артур Пендрагон");
            
      Console.WriteLine($"НАЧАЛО БИТВЫ1. Исходное состояние: \n" +
                        $"==================\n" +
                        $"{lancelot.GetInfo()}\n" +
                        $"{artur.GetInfo()}\n");
           
      Console.WriteLine($"{lancelot.Name} атакует {artur.Name}!");

      beforeHP = artur.HP;
      lancelot.Hit(artur);
      damage = beforeHP - artur.HP;

      HealthPotion healthPotion = new HealthPotion(100, "Зелье хп");
      ManaPotion manaPotion = new ManaPotion(100, "Зелье Маны");;
      CoolPotion coolPotion = new CoolPotion(1, "Крутое зелье");

      critText = lancelot.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");
      Console.WriteLine($"Тест перегрузки:\n" + $"ХП {lancelot.Name} уменьшено на 10\n");
      
      lancelot -= 10;
      Console.WriteLine($"Текущее ХП {lancelot.Name}: {lancelot.HP}\n" + $"ХП {lancelot.Name} увеличено на 100:\n");

      lancelot += 100;
      Console.WriteLine($"Текущее ХП {lancelot.Name}: {lancelot.HP}\n");

      Console.WriteLine("Проверка на хилки:");

      Console.WriteLine($"Текущее ХП {lancelot.Name}: {lancelot.HP}\n");
      lancelot += healthPotion;
      Console.WriteLine($"выпил {healthPotion.Name} ХП теперь - {lancelot.HP}");

      Console.WriteLine($"Текущее МП {lancelot.Name}: {lancelot.MP}\n");
      lancelot += manaPotion;
      Console.WriteLine($"выпил {manaPotion.Name} МП теперь - {lancelot.MP}");

      Console.WriteLine($"Текущее ХП {lancelot.Name}: {lancelot.HP}\n");
      lancelot += coolPotion;
      Console.WriteLine($"выпил {coolPotion.Name} ХП {lancelot.Name} теперь - {lancelot.HP}");

      Console.Write("Нажмите любую клавишу, чтобы продолжить.");
      Console.ReadKey();
    }
  }
}
