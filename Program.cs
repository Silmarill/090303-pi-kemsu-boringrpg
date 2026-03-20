using System;

namespace BoringRPG
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("СИСТЕМА ПРЕДМЕТОВ\n");

      Berserker berserker = new Berserker("Конан-варвар");
      Console.WriteLine("Начальное состояние:");
      Console.WriteLine(berserker.GetInfo());

      Console.WriteLine("\nОБЫЧНЫЕ ПРЕДМЕТЫ");

      ManaPotion manaPotion = new ManaPotion();
      berserker += manaPotion;

      AmmoPack ammoPack = new AmmoPack();
      berserker += ammoPack;

      BerserkerElixir elixir = new BerserkerElixir();
      berserker += elixir;

      Console.WriteLine("\nБЕЗУМНЫЙ ПРЕДМЕТ");
      CrazyPotion crazyPotion = new CrazyPotion();
      berserker += crazyPotion;

      Console.WriteLine("\nИТОГОВОЕ СОСТОЯНИЕ");
      Console.WriteLine(berserker.GetInfo());

      Console.ReadKey();
    }
  }
}