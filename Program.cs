using BoringRPG.Skills;
using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      // Инициализация персонажей
      var artur = new Necromancer("Артур");
      var dummy = new DummyClass("Груша");

      // Инициализация безумного кофе
      var espresso = new Coffee(2);

      Console.WriteLine("Перед боем\n" +
        $"{artur.GetInfo()}\n" +
        $"{dummy.GetInfo()}\n"
        );

      Console.WriteLine("Раунд начался!\n");

      // Использование кофе
      Console.WriteLine($"{artur} использует кофе!");
      artur.UseItem(espresso);

      // Инициализация навыков
      Skill soulLink = new SoulLink();
      Skill drama = new DramaAction();
      Skill coin = new CoinOfFate();

      // Связь душ
      Console.WriteLine(artur.UseSkill(soulLink, dummy));
      Console.WriteLine("--------------------------------");

      // Драма
      Console.WriteLine(dummy.UseSkill(drama, artur));
      Console.WriteLine("--------------------------------");

      // Монета судьбы
      Console.WriteLine(artur.UseSkill(coin, dummy));
      Console.WriteLine("--------------------------------");

      Console.WriteLine("\nПосле использования навыка\n\n" +
      $"{artur.GetInfo()}\n" +
      $"{dummy.GetInfo()}\n"
      );

      Console.WriteLine("Тест окончен. Нажмите любую кнопку...");
      Console.ReadKey();
    }
  }
}