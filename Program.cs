using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {

      string critText;
      int beforeHP, damage;
      
      RogueClass lancelot = new RogueClass("Ланселот Ловкий");
      RogueClass rapfael = new RogueClass("Рафаэль Могучий");
            
      Console.WriteLine($"НАЧАЛО БИТВЫ\nИсходное состояние:\n" +
                        $"==================\n" +
                        $"{lancelot.GetInfo()}\n" +
                        $"{rapfael.GetInfo()}\n");

      HealthPotion healthPotion = new HealthPotion(20);
      ManaPotion manaPotion = new ManaPotion(10);
      AmmoPack ammoPack = new AmmoPack(5);
      GoldApple goldApple = new GoldApple(10);

      Skill dramaAction = new DramaAction();
      Skill coinOfFate = new CoinOfFate();
      Skill soulLink = new SoulLink();
      
      rapfael += ammoPack;
      Console.WriteLine($"\n{rapfael.Name} подобрал патроны! +{ammoPack.Value} Ammo\n");
      
      string oldRapfaelsName = rapfael.Name;
      string oldLancelotsName = lancelot.Name;
      Console.WriteLine($"\n{rapfael.Name} использует навык {dramaAction.Name} на {lancelot.Name}");
      rapfael.UseSkill(dramaAction, lancelot);

      if (oldRapfaelsName == rapfael.Name && oldLancelotsName != lancelot.Name) {
        Console.WriteLine($"{oldLancelotsName} переименован в {lancelot.Name}");
      } else if (oldLancelotsName == lancelot.Name && oldRapfaelsName != rapfael.Name) {
        Console.WriteLine($"{oldRapfaelsName} переименован в {rapfael.Name}");
      } else {
        Console.WriteLine($"{rapfael.Name} дарит розу {lancelot.Name}");
      }

      Console.WriteLine($"{rapfael.Name} атакует {lancelot.Name}!");

      beforeHP = lancelot.HP;
      rapfael.Hit(lancelot);
      damage = beforeHP - lancelot.HP;

      critText = rapfael.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");

      if (lancelot) { 
        Console.WriteLine($"{lancelot.Name} чудом выжил!\n");
      } else {
        Console.WriteLine($"{lancelot.Name} пал смертью храбрых!\n");
                        
        Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:\n" +
                          "======================\n" +
                          $"{lancelot.GetInfo()}\n" +
                          $"{rapfael.GetInfo()}\n" +
                          $"{lancelot.Name} выбывает!\n" +
                          $"Поздравляем {rapfael.Name} с победой!\n");

        return;
      }

      lancelot += healthPotion;
      Console.WriteLine($"\n{lancelot.Name} выпил зелье здоровья! +{healthPotion.Value} HP\n");

      lancelot += manaPotion;
      Console.WriteLine($"\n{lancelot.Name} выпил зелье маны! +{manaPotion.Value} MP\n");
      
      int totalHP;
      Console.WriteLine($"\n{lancelot.Name} использует навык {soulLink.Name} на {rapfael.Name}");
      totalHP = lancelot.HP + rapfael.HP;
      lancelot.UseSkill(soulLink, rapfael);
      Console.WriteLine($"Общее здоровье {totalHP} ушло поровну каждому");

      Console.WriteLine($"{lancelot.Name} атакует {rapfael.Name}!");
      beforeHP = rapfael.HP;
      lancelot.Hit(rapfael);
      damage = beforeHP - rapfael.HP;

      critText = lancelot.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");

      if (rapfael) { 
        Console.WriteLine($"{rapfael.Name} чудом выжил!\n");
      } else {
        Console.WriteLine($"{rapfael.Name} пал смертью храбрых!\n");

        Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:\n" +
                        "======================\n" +
                        $"{lancelot.GetInfo()}\n" +
                        $"{rapfael.GetInfo()}\n\n" +
                        $"{rapfael.Name} выбывает!\n\n" +
                        $"Поздравляем {lancelot.Name} с победой!\n");

        return;
      }

      rapfael += goldApple;
      Console.WriteLine($"\n{rapfael.Name} съел золотое яблоко! +{goldApple.Value} +{goldApple.Value * 3}\n");

      Console.WriteLine($"\n{rapfael.Name} подбрасывает Монету судьбы! :О");
      rapfael.UseSkill(coinOfFate, lancelot);

      if (lancelot.HP == 0) {
        Console.WriteLine($"Монета решила, что {lancelot.Name} умрет!" +
                          $"\n{lancelot.Name} умирает . . .");
      } else if (rapfael.HP == 0) {
        Console.WriteLine($"Монета решила, что {rapfael.Name} умрет!" +
                          $"\n{rapfael.Name} умирает . . .");
      } else {
        Console.WriteLine("Ничего не произошло: монета упала ребром!");
      }

      if (rapfael.HP > 0 && lancelot.HP <= 0) {

        Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:\n" +
                        "======================\n" +
                        $"{lancelot.GetInfo()}\n" +
                        $"{rapfael.GetInfo()}\n\n" +
                        $"{lancelot.Name} выбывает!\n\n" +
                        $"Поздравляем {rapfael.Name} с победой!\n");

        return;

      } else if (lancelot.HP > 0 && rapfael.HP <= 0) {

        Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:\n" +
                        "======================\n" +
                        $"{lancelot.GetInfo()}\n" +
                        $"{rapfael.GetInfo()}\n\n" +
                        $"{rapfael.Name} выбывает!\n\n" +
                        $"Поздравляем {lancelot.Name} с победой!\n");

        return;

      } else {

        Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:\n" +
                        "======================\n" +
                        $"{lancelot.GetInfo()}\n" +
                        $"{rapfael.GetInfo()}\n\n");

        Console.WriteLine("БОЙ ОКОНЧЕН НИЧЬЕЙ!");
      }
    }
  }
}
