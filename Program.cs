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

      // 1. SoulLink
      Console.WriteLine("\n--- Навык 1: SoulLink ---");
      Console.WriteLine($"{necro.Name} использует SoulLink на {artur.Name}!");
            
      int beforeHpNecro = necro.HP;
      int beforeHpArtur = artur.HP;
            
      necro.UseSkill(soulLink, artur);
            
      Console.WriteLine($"   HP {necro.Name}: {beforeHpNecro} → {necro.HP}");
      Console.WriteLine($"   HP {artur.Name}: {beforeHpArtur} → {artur.HP}");

      // 2. DramaAction
      Console.WriteLine("\n--- Навык 2: DramaAction ---");
      Console.WriteLine($"{artur.Name} использует DramaAction на {necro.Name}!");
            
      string oldNecroName = necro.Name;
      string oldArturName = artur.Name;
            
      artur.UseSkill(drama, necro);
            
      if (necro.Name != oldNecroName) {
        Console.WriteLine($"   {oldNecroName} теперь называется {necro.Name}!");
      } else if (artur.Name != oldArturName) {
        Console.WriteLine($"   {oldArturName} теперь называется {artur.Name}!");
      } else {
        Console.WriteLine($"   {artur.Name} дарит розу {necro.Name}!");
      }

      // 3. CoinOfFate
      Console.WriteLine("\n--- Навык 3: CoinOfFate ---");
      Console.WriteLine($"{necro.Name} использует CoinOfFate на {artur.Name}!");
            
      beforeHpNecro = necro.HP;
      beforeHpArtur = artur.HP;
            
      necro.UseSkill(coin, artur);
            
      if (necro.HP == 0 && beforeHpNecro > 0) {
        Console.WriteLine($"Несчастный случай! {necro.Name} погибает!");
      } else if (artur.HP == 0 && beforeHpArtur > 0) {
        Console.WriteLine($"Судьба жестока! {artur.Name} погибает!");
      } else {
        Console.WriteLine($"Ничего не произошло. Повезло!");
      }

      Console.WriteLine("\n=== ИТОГОВОЕ СОСТОЯНИЕ ===");
      Console.WriteLine(necro.GetInfo());
      Console.WriteLine(artur.GetInfo());

      Console.WriteLine("\nНажмите любую клавишу для выхода...");
      Console.ReadKey();
    }
  }
}
