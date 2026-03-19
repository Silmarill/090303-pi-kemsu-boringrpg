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

      //HealthPotion potion = new HealthPotion(30);
      //artur - potion;

      //Console.WriteLine($"{artur.Name} использует зелье\n");
      //Console.WriteLine($"{artur.GetInfo()}\n");

      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(lancelot.GetInfo());
      Console.WriteLine(artur.GetInfo());
      Console.ReadKey();
    }
  }
}
