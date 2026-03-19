using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      string critText;
      int beforeHP, damage;
      
      Warrior lancelot = new Warrior("Ланселот Ловкий");
      DummyClass artur = new DummyClass("Артур Пендрагон");
            
      Console.WriteLine($"НАЧАЛО БИТВЫ. Исходное состояние: \n" +
                        $"==================\n" +
                        $"{lancelot.GetInfo()}\n" +
                        $"{artur.GetInfo()}\n");
           
      Console.WriteLine($"{lancelot.Name} атакует {artur.Name}!");

      beforeHP = artur.HP;
      //lancelot.Hit(artur);
      lancelot = lancelot - artur;
      damage = beforeHP - artur.HP;

      critText = lancelot.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");
      Console.WriteLine($"После атаки: {artur.GetInfo()}\n");

      Console.WriteLine($"{artur.Name} использует предметы");
      HealthPotion healtPotion = new HealthPotion(20);
      artur += healtPotion;
      AmmoPack ammoPack = new AmmoPack(40);
      artur += ammoPack;
      Console.WriteLine($"После исользования: {artur.GetInfo()}\n");

      Console.WriteLine($"{lancelot.Name} использует предметы");
      ManaPotion manaPotion = new ManaPotion(10);
      lancelot += manaPotion;
      EnergyDrink energyDrink = new EnergyDrink(50);
      lancelot += energyDrink;
      Console.WriteLine($"После исользования: {lancelot.GetInfo()}\n");

      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(lancelot.GetInfo());
      Console.WriteLine(artur.GetInfo());
      Console.ReadKey();
    }
  }
}
