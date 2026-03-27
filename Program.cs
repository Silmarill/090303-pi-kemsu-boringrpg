using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      string critText;
      int beforeHP, damage;

      Heal hPotion = new Heal(42);
      ManaRestore mPotion = new ManaRestore(42);
      AmmoPack aPotion = new AmmoPack(5);
      FatBurger burger = new FatBurger(50);
      Rogue torfin = new Rogue("Торфин Безопасный");
      DummyClass killer = new DummyClass("Скрытный убийца");
      Skill soulLink = new SoulLink();
      Skill manaDrain = new ManaDrain();
      Skill giveUp = new GiveUp();

      Console.WriteLine($"НАЧАЛО БИТВЫ. Исходное состояние: \n" +
                        $"{torfin.GetInfo()}\n" + $"{killer.GetInfo()}\n");

      killer.Hit(torfin);
      Console.WriteLine($"Убийца наносит Торфину {killer.Damage} урона и у Торфина остаётся {torfin.HP} хп");
           
      Console.WriteLine($"\n{torfin.Name} хилится на {hPotion.value}");
      torfin += hPotion;

      Console.WriteLine($"\n{torfin.Name} хилит ману на {hPotion.value}");
      torfin += mPotion;

      Console.WriteLine($"\n{torfin.Name} Взял {aPotion.value} патронов");
      torfin += aPotion;

      Console.WriteLine($"\n{torfin.Name} После хила решил перекусить и потолстел на -{burger.value}, но при этом увеличил свой урон {burger.value}");
      torfin -= burger;

      Console.WriteLine($"Чтобы не проиграть, Торфин использует способность SoulLink и уравнивает своё хп с хп противника\n");
      torfin.UseSkill(soulLink, killer);
      Console.WriteLine($"Торфин Использует SoulLink на скрытный убийца");
      Console.WriteLine();

      Console.WriteLine($"Торфина решил, что раз ему не нужна мана, то и его сопернику она ни к чему, поэтому применил ManaDrain");
      torfin.UseSkill(manaDrain, killer);
      Console.WriteLine($"Торфин Использует ManaDrain на скрытный убийца");
      Console.WriteLine();

      Console.WriteLine($"Даже когда у Торфина преимущество он не уверен в своей победе, а потому решает избрать самый безопасный способ окончания битвы и использует свой коронный приём GiveUp");
      torfin.UseSkill(giveUp, torfin);
      Console.WriteLine($"Торфин сдаётся с позором");
      Console.WriteLine();
      
      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(torfin.GetInfo());
      Console.WriteLine(killer.GetInfo());
      Console.ReadKey();
    }
  }
}
