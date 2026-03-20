using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      string critText;
      int beforeHP, damage;
      
      Necromancer necro = new Necromancer("Дэвид Харрис");
      DummyClass artur =  new DummyClass("Артур Пендрагон");
            
      Console.WriteLine($"НАЧАЛО БИТВЫ. Исходное состояние: \n" +
                        $"==================\n" +
                        $"{necro.GetInfo()}\n" +
                        $"{artur.GetInfo()}\n");
           
      Console.WriteLine($"{necro.Name} атакует {artur.Name}!");

      beforeHP = artur.HP;
      necro.Hit(artur);
      damage = beforeHP - artur.HP;

      critText = necro.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");

      if (necro) {  
        Console.WriteLine($"{necro.Name} жив и может быть исцелен!");
        necro += 10;  
        Console.WriteLine($"После исцеления: {necro.GetInfo()}");
    }
                        
      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(necro.GetInfo());
      Console.WriteLine(artur.GetInfo());
      Console.ReadKey();

      Console.WriteLine("\n=== ДЕМОНСТРАЦИЯ ПРЕДМЕТОВ-РАСХОДНИКОВ ===");
            
      HealthPotion hpPotion = new HealthPotion(30);
      ManaPotion mpPotion = new ManaPotion(25);
      BugPotion bugPotion = new BugPotion(20);

      Skill soulLink = new SoulLink();
      Skill drama = new DramaAction();
      Skill coin = new CoinOfFate();
  
      Console.WriteLine($"\nТекущее состояние некроманта:");
      Console.WriteLine(necro.GetInfo());
            
      // Используем HealthPotion
      Console.WriteLine($"\nИспользуем HealthPotion +{hpPotion.Value}:");
      necro += hpPotion;
      Console.WriteLine(necro.GetInfo());
            
      // Используем ManaPotion
      Console.WriteLine($"\nИспользуем ManaPotion +{mpPotion.Value}:");
      necro += mpPotion;
      Console.WriteLine(necro.GetInfo());

      // Используем BugPotion (безумный предмет)
      Console.WriteLine($"\nИспользуем BugPotion (безумный предмет!):");
      necro += bugPotion;
      Console.WriteLine(necro.GetInfo());

      // 1. SoulLink - перераспределение HP
      Console.WriteLine("\n--- Навык 1: SoulLink ---");
      necro.UseSkill(soulLink, artur);
      Console.WriteLine("\nПосле SoulLink:");
      Console.WriteLine(necro.GetInfo());
      Console.WriteLine(artur.GetInfo());

      // 2. DramaAction - шуточный навык
      Console.WriteLine("\n--- Навык 2: DramaAction ---");
      artur.UseSkill(drama, necro);
      Console.WriteLine("\nПосле DramaAction:");
      Console.WriteLine(necro.GetInfo());
      Console.WriteLine(artur.GetInfo());

      // 3. CoinOfFate - рискованный навык
      Console.WriteLine("\n--- Навык 3: CoinOfFate ---");
      necro.UseSkill(coin, artur);
      Console.WriteLine("\nПосле CoinOfFate:");
      Console.WriteLine(necro.GetInfo());
      Console.WriteLine(artur.GetInfo());

      Console.WriteLine("\nНажмите любую клавишу для выхода...");
      Console.ReadKey();
    }
  }
}
