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
        Console.WriteLine($"Нанесено урона: {damageDealt}");
        Console.WriteLine(necro.GetInfo());
        Console.WriteLine($"HP цели: {target.HP}\n");
      }
    }
  }
}