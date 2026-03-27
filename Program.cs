using System;
using BoringRPG.Models;
using BoringRPG.Items;
using BoringRPG.Skills;

namespace BoringRPG {
  public class Program {
    static void Main(string[] args)
    {
      string critText;
      int beforeHP;
      int damage;
      string skillResult;

      int maxRounds;
      int healthPotionValue;
      int manaPotionValue;
      int ammoPackValue;
      int breadValue;
      int breadMpPenalty;
      int breadAmmoPenalty;
      int healAmount;
      int damageAmount;
      int soulLinkHp1;
      int soulLinkHp2;
      int critMultiplier;
      int dramaActionRepeatCount;

      Monk shiYan;
      Monk jackieChan;

      maxRounds = 4;
      healthPotionValue = 50;
      manaPotionValue = 30;
      ammoPackValue = 10;
      breadValue = 40;
      breadMpPenalty = 10;
      breadAmmoPenalty = 5;
      healAmount = 10;
      damageAmount = 5;
      soulLinkHp1 = 80;
      soulLinkHp2 = 20;
      critMultiplier = 100;
      dramaActionRepeatCount = 3;

      shiYan = new Monk("Ши Янь");
      jackieChan = new Monk("Джеки Чан");

      Console.WriteLine($"НАЧАЛО БИТВЫ. Исходное состояние: \n" +
                        $"==================\n" +
                        $"{shiYan.GetInfo()}\n" +
                        $"{jackieChan.GetInfo()}\n");

      for (int roundIndex = 1; roundIndex <= maxRounds; ++roundIndex)
      {
        Console.WriteLine($"\n--- Раунд {roundIndex} ---");
        Console.WriteLine($"{shiYan.Name} атакует {jackieChan.Name}!");

        beforeHP = jackieChan.HP;
        shiYan.Hit(jackieChan);
        damage = beforeHP - jackieChan.HP;

        critText = shiYan.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";
        Console.WriteLine($"Нанесено {damage} урона{critText}");
      }

      Console.WriteLine("\nИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(shiYan.GetInfo());
      Console.WriteLine(jackieChan.GetInfo());

      Console.WriteLine($"\n--- Демонстрация расходников ---");

      Console.WriteLine($"\n>>> Волшебные предметы:");
      jackieChan = jackieChan + new HealthPotion(healthPotionValue);
      shiYan = shiYan + new ManaPotion(manaPotionValue);
      shiYan = shiYan + new AmmoPack(ammoPackValue);

      Console.WriteLine("\nПосле использования волшебных предметов:");
      Console.WriteLine(shiYan.GetInfo());
      Console.WriteLine(jackieChan.GetInfo());

      Console.WriteLine($"\n>>> Безумный предмет:");
      FatBread bread;

      bread = new FatBread(breadValue);

      Console.WriteLine($"{jackieChan.Name} съел хлеб! +{bread.Value} HP, но -{breadMpPenalty} MP, -{breadAmmoPenalty} патронов");
      jackieChan = jackieChan + bread;

      Console.WriteLine("\nПосле хлеба:");
      Console.WriteLine(shiYan.GetInfo());
      Console.WriteLine(jackieChan.GetInfo());

      Console.WriteLine($"\n--- Демонстрация других операторов ---");
      Console.WriteLine($"Здоровье {jackieChan.Name} до лечения: {jackieChan.HP}");
      jackieChan = jackieChan + healAmount;
      Console.WriteLine($"Здоровье {jackieChan.Name} после лечения (+{healAmount}): {jackieChan.HP}");
      jackieChan = jackieChan - damageAmount;
      Console.WriteLine($"Здоровье {jackieChan.Name} после урона (-{damageAmount}): {jackieChan.HP}");

      if (jackieChan)
      {
        Console.WriteLine($"{jackieChan.Name} жив и здоров (HP > 0).");
      }
      else
      {
        Console.WriteLine($"{jackieChan.Name} повержен (HP <= 0).");
      }

      Console.WriteLine("\n\n--- Демонстрация навыков ---");

      Skill soulLinkSkill;
      Skill tauntSkill;
      Skill dramaSkill;

      soulLinkSkill = new SoulLink();
      tauntSkill = new Taunt();
      dramaSkill = new DramaAction();

      Console.WriteLine("\n--- Применяем навык Soul Link ---");
      shiYan.HP = soulLinkHp1;
      jackieChan.HP = soulLinkHp2;
      Console.WriteLine($"До использования: {shiYan.Name} HP = {shiYan.HP}, {jackieChan.Name} HP = {jackieChan.HP}");
      skillResult = shiYan.UseSkill(soulLinkSkill, jackieChan);
      Console.WriteLine(skillResult);
      Console.WriteLine($"После использования: {shiYan.Name} HP = {shiYan.HP}, {jackieChan.Name} HP = {jackieChan.HP}");

      Console.WriteLine("\n--- Применяем навык Taunt ---");
      Console.WriteLine($"До использования: Шанс крита {jackieChan.Name} = {jackieChan.CritChance * critMultiplier}%");
      skillResult = shiYan.UseSkill(tauntSkill, jackieChan);
      Console.WriteLine(skillResult);
      Console.WriteLine($"После использования: Шанс крита {jackieChan.Name} = {jackieChan.CritChance * critMultiplier}%");

      Console.WriteLine("\n--- Применяем навык Drama Action (несколько раз) ---");

      for (int actionIndex = 0; actionIndex < dramaActionRepeatCount; ++actionIndex)
      {
        skillResult = jackieChan.UseSkill(dramaSkill, shiYan);
        Console.WriteLine(skillResult);
      }

      Console.WriteLine("\nФинальное состояние после навыков:");
      Console.WriteLine(shiYan.GetInfo());
      Console.WriteLine(jackieChan.GetInfo());

      Console.ReadKey();
    }
  }
}