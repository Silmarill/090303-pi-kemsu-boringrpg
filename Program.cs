using System;

namespace BoringRPG
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("СИСТЕМА ПРЕДМЕТОВ:");

      Berserker berserker = new Berserker("Конан-варвар");
      Console.WriteLine("Начальное состояние:");
      Console.WriteLine(berserker.GetInfo());
      Console.WriteLine(new string('-', 50));

      Console.WriteLine("ОБЫЧНЫЕ ПРЕДМЕТЫ:");

      ManaPotion manaPotion = new ManaPotion();
      berserker += manaPotion;

      AmmoPack ammoPack = new AmmoPack();
      berserker += ammoPack;

      BerserkerElixir elixir = new BerserkerElixir();
      berserker += elixir;

      Console.WriteLine("БЕЗУМНЫЙ ПРЕДМЕТ:");
      CrazyPotion crazyPotion = new CrazyPotion();
      berserker *= crazyPotion;

      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine(berserker.GetInfo());

      Console.ReadKey();
    }
  }
}