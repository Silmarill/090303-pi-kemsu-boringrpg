using System;
using System.Xml.Linq;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      string critText;
      int beforeHP, damage;
      
      Cleric lancelot = new Cleric("Чел");
      DummyClass artur =    new DummyClass("Артур Пирожков");
            
      Console.WriteLine($"НАЧАЛО БИТВЫ1. Исходное состояние: \n" +
                        $"==================\n" +
                        $"{lancelot.GetInfo()}\n" +
                        $"{artur.GetInfo()}\n");
           
      Console.WriteLine($"{lancelot.Name} атакует {artur.Name}!");

      beforeHP = artur.HP;
      lancelot.Hit(artur);
      damage = beforeHP - artur.HP;

      HealthPotion healthPotion = new HealthPotion(100, "Зелье хп");
      ManaPotion manaPotion = new ManaPotion(100, "Зелье Маны");
      CoolPotion coolPotion = new CoolPotion(1, "Крутое зелье");

      Skill lastStand = new LastStandSkill("Абузер", 10, artur);
      Skill manaDrain = new ManaDrainSkill("Вор манки", 2, artur);
      Skill chance = new ChanceSkill("РАНДОМЕР", 20, artur);

      critText = lancelot.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");
      Console.WriteLine($"Тест перегрузки:\n" + $"ХП {lancelot.Name} уменьшено на 10\n");
      
      lancelot -= 10;
      Console.WriteLine($"Текущее ХП {lancelot.Name}: {lancelot.HP}\n" + $"ХП {lancelot.Name} увеличено на 100:\n");

      lancelot += 100;
      Console.WriteLine($"Текущее ХП {lancelot.Name}: {lancelot.HP}\n");

      Console.WriteLine("Проверка способок:");

      Console.WriteLine($"Текущее ХП {lancelot.Name}: {lancelot.HP}, DMG: {artur.Damage}\n");
      lancelot.UseSkill(lastStand, artur);
      Console.WriteLine($"{lancelot.Name} использовал {lastStand.Name} на {artur.Name}.ХП {lancelot.Name} теперь - {lancelot.HP}");

      Console.WriteLine($"Текущее МП {lancelot.Name}: {lancelot.MP}\n");
      artur.UseSkill(manaDrain, lancelot);
      Console.WriteLine($"{artur.Name} использовал {manaDrain.Name} на {lancelot.Name}. МП {artur.Name} теперь - {artur.MP}");
      Console.WriteLine($"Текущее МП {lancelot.Name}: {lancelot.MP}\n");

      Console.WriteLine($"Состояние: \n" +
                        $"==================\n" +
                        $"{lancelot.GetInfo()}\n" +
                        $"{artur.GetInfo()}\n");
      lancelot.UseSkill(chance, artur);
      Console.WriteLine($"{lancelot.Name} использовал {chance.Name} на {artur.Name}. все рандоминизированно!!!!!");
      Console.WriteLine($"Состояние: \n" +
                        $"==================\n" +
                        $"{lancelot.GetInfo()}\n" +
                        $"{artur.GetInfo()}\n");

      Console.Write("Нажмите любую клавишу, чтобы продолжить.");
      Console.ReadKey();
    }
  }
}
