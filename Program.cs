using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      // Создание персонажа и цели для битвы
      Necromancer necro = new Necromancer("Артур");
      DummyClass target = new DummyClass("Кузьмин Слава");

      Console.WriteLine("--- НАЧАЛО ТЕСТА ---");
      Console.WriteLine(necro.GetInfo());
      Console.WriteLine(target.GetInfo());
      Console.WriteLine("--------------------\n");

      // Удары для проверки маны и бонуса скелетов
      for (int hitInFight = 1; hitInFight <= 3; ++hitInFight) {
        int beforeHP = target.HP;

        Console.WriteLine($"Удар №{hitInFight}: {necro.Name} атакует!");
        necro.Hit(target);

        int damageDealt = beforeHP - target.HP;
        Console.WriteLine($"Нанесено урона: {damageDealt}");
        Console.WriteLine(necro.GetInfo());
        Console.WriteLine($"HP цели: {target.HP}\n");
      }

      Console.WriteLine("--------------------\n");

      // Тест перегрузки операторов + и -
      Console.WriteLine("--- ТЕСТ ПЕРЕГРУЗКИ ---");
      Console.WriteLine($"Было HP: {necro.HP}");

      necro = necro + 20; // Хилл на 20 хп
      Console.WriteLine($"После +20 HP: {necro.HP}");

      necro = necro - 10; // Урон 10 хп
      Console.WriteLine($"После -10 HP: {necro.HP}\n");

      // (true / false)
      Console.WriteLine("--- ПРОВЕРКА СТАТУСА (ЖИВ/МЕРТВ) ---");

      // Используем перегруженный оператор true
      if (!necro) {
        Console.WriteLine($"{necro.Name} еще жив, продолжаем бой!");
      }

      Console.WriteLine("Наносим смертельный урон...");

      // Смерть
      necro = necro - 200;

      // Перегруженный оператор false
      if (necro) {
        Console.WriteLine($"{necro.Name} пал в бою. Конец игры.");
      }

      Console.WriteLine("\nТест полностью завершен. Нажми любую клавишу...");
      Console.ReadKey();
    }
  }
}