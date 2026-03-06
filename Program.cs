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

      // Удары для урона
      for (int hitInFight = 1; hitInFight <= 3; ++hitInFight) {
        int beforeHP = target.HP;

        Console.WriteLine($"Удар №{hitInFight}: {necro.Name} атакует!");

        // -15 маны, и если некромант попадает, то получает бонус
        necro.Hit(target);

        int damageDealt = beforeHP - target.HP;
        Console.WriteLine("--- ТЕСТ УРОНА ---");
        Console.WriteLine($"Нанесено урона: {damageDealt}");
        Console.WriteLine(necro.GetInfo());
        Console.WriteLine($"HP цели: {target.HP}\n");
      Console.WriteLine("--------------------\n");

      // Перегрузка операторов + и -
      Console.WriteLine("--- ТЕСТ ПЕРЕГРУЗКИ ---");
      Console.WriteLine($"Было HP: {necro.HP}");
      
      // Хилл на 20 хп
      necro = necro + 20;
      Console.WriteLine($"После +20 HP: {necro.HP}");

        // Урон 10 хп
        necro = necro - 10;
      Console.WriteLine($"После -10 HP: {necro.HP}");

      Console.WriteLine("\nТест завершен. Нажми любую клавишу...");
      Console.ReadKey();
      }
    }
  }
}