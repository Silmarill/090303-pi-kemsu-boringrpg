using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      var artur = new Necromancer("Артур");
      Console.WriteLine("ДО ПРИМЕНЕНИЯ ПРЕДМЕТОВ:");
      Console.WriteLine(artur.GetInfo());

      // Используются стандартные предметы через оператор +
      artur = (Necromancer)(artur + new HealthPotion(50));
      artur = (Necromancer)(artur + new ManaPotion(30));

      /*
      A Mad Item (Coffee) is consumed via the * operator
      Critical hit chance is multiplied by 1.5x, at the cost of 10 HP
      */
      artur = (Necromancer)(artur * 1.5);

      Console.WriteLine("\nПОСЛЕ ПРИМЕНЕНИЯ ПРЕДМЕТОВ (Зелья + Кофе):");
      // In the Necromancer's GetInfo, the critical hit chance should be displayed for better clarity
      Console.WriteLine($"{artur.GetInfo()}, Шанс крита: {artur.CritChance:P0}");

      Console.WriteLine("\nТест завершен. Нажми любую клавишу...");
      Console.ReadKey();
    }
  }
}