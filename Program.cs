using System;
using BoringRPG.Skills;

namespace BoringRPG {
  public class Program {
    static void Main(string[] args)
    {
      Console.WriteLine("=== ДЕМОНСТРАЦИЯ НАВЫКОВ И РАСХОДУЕМЫХ ПРЕДМЕТОВ ===\n");

      Druid cedric = new Druid("Кедрик Зелёный");
      Druid enemy = new Druid("Злобный Гоблин");

      Console.WriteLine("Начальное состояние:");
      Console.WriteLine(cedric.GetInfo());
      Console.WriteLine(enemy.GetInfo());
      Console.WriteLine();

      SoulLinkSkill soulLink = new SoulLinkSkill();
      CoinOfFateSkill coinOfFate = new CoinOfFateSkill();
      TauntSkill taunt = new TauntSkill();

      Console.WriteLine("1. ДЕМОНСТРАЦИЯ НАВЫКА 'СВЯЗЬ ДУШ':");
      Console.WriteLine("-------------------------------------");
      cedric.UseSkill(soulLink, enemy);
      Console.WriteLine();
      Console.WriteLine(cedric.GetInfo());
      Console.WriteLine(enemy.GetInfo());
      Console.WriteLine();

      Console.WriteLine("2. ДЕМОНСТРАЦИЯ НАВЫКА 'ПРОВОКАЦИЯ':");
      Console.WriteLine("-------------------------------------");
      cedric.UseSkill(taunt, enemy);
      Console.WriteLine();
      Console.WriteLine($"Шанс крита у врага: {enemy.CritChance * 100}%");
      Console.WriteLine();

      Console.WriteLine("3. ДЕМОНСТРАЦИЯ НАВЫКА 'МОНЕТА СУДЬБЫ':");
      Console.WriteLine("-------------------------------------");
      cedric.UseSkill(coinOfFate, enemy);
      Console.WriteLine();
      Console.WriteLine(cedric.GetInfo());
      Console.WriteLine(enemy.GetInfo());
      Console.WriteLine();

      Console.WriteLine("4. ДЕМОНСТРАЦИЯ РАСХОДУЕМЫХ ПРЕДМЕТОВ:");
      Console.WriteLine("-------------------------------------");

      cedric = new Druid("Кедрик Зелёный");
      Console.WriteLine(cedric.GetInfo());
      Console.WriteLine();

      HealthPotion healthPotion = new HealthPotion(30);
      cedric += healthPotion;
      Console.WriteLine($" {cedric.Name} восстанавливает {healthPotion.Value} здоровья!");
      Console.WriteLine(cedric.GetInfo());

      ManaPotion manaPotion = new ManaPotion(20);
      cedric += manaPotion;
      Console.WriteLine($" {cedric.Name} восстанавливает {manaPotion.Value} маны!");
      Console.WriteLine(cedric.GetInfo());

      AmmoPack ammoPack = new AmmoPack(15);
      cedric += ammoPack;
      Console.WriteLine($" {cedric.Name} получает {ammoPack.Value} боеприпасов!");
      Console.WriteLine(cedric.GetInfo());

      Console.WriteLine();

      DoubleEspresso espresso = new DoubleEspresso(10);
      if (cedric > espresso)
      {
        Console.WriteLine($" {cedric.Name} выпил двойной эспрессо! Урон + {espresso.Value}, " + $"здоровье - {espresso.Value / 2}, мана + {espresso.Value / 2}");
      }
      Console.WriteLine(cedric.GetInfo());

      Console.WriteLine("\nНажмите любую клавишу для выхода...");
      Console.ReadKey();
    }
  }
}