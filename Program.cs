using BoringRPG.Skills;
using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      var artur = new Necromancer("Артур");
      var dummy = new DummyClass("Груша");

      Console.WriteLine("Перед боем\n" +
        $"{artur.GetInfo()}\n" +
        $"{dummy.GetInfo()}\n"
        );

      Console.WriteLine("!!! Бой !!! >:)\n");

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