using System;
using static BoringRPG.ConsumableItem;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      string critText;
      int beforeHP, damage;

      Mage mage = new Mage("Маг");
      DummyClass artur = new DummyClass("Артур Пендрагон");

      Console.WriteLine($"НАЧАЛО БИТВЫ. Исходное состояние: \n" +
                        $"==================\n" +
                        $"{mage.GetInfo()}\n" +
                        $"{artur.GetInfo()}\n");

      Console.WriteLine($"{mage.Name} атакует !");

      beforeHP = artur.HP;
      mage.Hit(artur);
      damage = beforeHP - artur.HP;

      critText = mage.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");

      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(mage.GetInfo());
      Console.WriteLine(artur.GetInfo());
      Console.WriteLine();

      Skill lastStand = new LastStand();
      mage.UseSkill(lastStand, artur);
      Console.WriteLine($"{mage.Name} использовал LastStand.\n");

      Console.WriteLine(mage.GetInfo());

      Skill manaDrain = new ManaDrain();
      mage.UseSkill(manaDrain, artur);
      Console.WriteLine($"{mage.Name} использовал ManaDrain. {artur.Name} потерял MP.\n");

      Console.WriteLine(mage.GetInfo());
      Console.WriteLine(artur.GetInfo());

      Skill destinyShuffle = new DestinyShuffle();
      mage.UseSkill(destinyShuffle, artur);
      Console.WriteLine($"{mage.Name} запускает Destiny Shuffle! Характеристики целей перемешаны.\n");

      Console.WriteLine(mage.GetInfo());
      Console.WriteLine(artur.GetInfo());

      Console.ReadKey();
    }
  }
}
