using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      string critText;
      int beforeHP, damage;

      Heal hPotion = new Heal(42);
      ManaRestore mPotion = new ManaRestore(42);
      AmmoPack aPotion = new AmmoPack(5);
      FatBurger burger = new FatBurger(100);
      Rogue torfin = new Rogue("Торфин Безопасный");
      DummyClass killer = new DummyClass("Скрытный убийца");
      
            
      Console.WriteLine($"НАЧАЛО БИТВЫ. Исходное состояние: \n" +
                        $"{torfin.GetInfo()}\n");
           
      Console.WriteLine($"\n{torfin.Name} хилится на {hPotion.value}");
      Console.WriteLine($"\n{torfin.Name} хилит ману на {hPotion.value}");
      Console.WriteLine($"\n{torfin.Name} Взял {aPotion.value} патронов");
      Console.WriteLine($"\n{torfin.Name} После хила решил перекусить и потолстел на -{burger.value}, но при этом увеличил свой урон {burger.value}");

      torfin += hPotion;
      torfin += mPotion;
      torfin += aPotion;
      torfin -= burger;
                       
      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(torfin.GetInfo());
      Console.ReadKey();
    }
  }
}
