using System;
using static System.Net.Mime.MediaTypeNames;
using System.Text;

namespace BoringRPG
{
  internal class Program
  {
    static void Main(string[] args)
    {
      string critText;
      int beforeHP, damage;

      DummyClass artur = new DummyClass("Артур Пендрагон");
      Nekromaster dungeonMaster = new Nekromaster("Данжен Мастер");


      HealPotion healPotion = new HealPotion(20);
      ManaPotion manaPotion = new ManaPotion(15);
      AmmoPack ammoPack = new AmmoPack(30);
      CocaCola coca = new CocaCola(5);

      Skill soulLink = new SoulLink();
      Skill manaDrain = new ManaDrain();
      Skill сoCaCoLaAaAa = new CoCaCoLaAaAa();

      Console.WriteLine($"\nТекущее состояние некроманта:");
      Console.WriteLine(dungeonMaster.GetInfo());

      Console.WriteLine("\nНажмите любую клавишу для выхода...");
      Console.ReadKey();

      Console.WriteLine($"\nДанжен Мастер находит в кармане холодную колу и выпивает 1её +{coca.Value}:");
      dungeonMaster +=coca;
      Console.WriteLine(dungeonMaster.GetInfo());

      Console.WriteLine($"НАЧАЛО БИТВЫ\n" + $"ПЕРВЫЙ РАУНД\n" +
                        $"Исходное состояние: \n" +
                        $"==================\n" +
                        $"{dungeonMaster.GetInfo()}\n" +
                        $"{artur.GetInfo()}\n");


      Console.WriteLine($"{dungeonMaster.Name} атакует {artur.Name}!");

      beforeHP = artur.HP;
      dungeonMaster.Hit(artur);
      damage = beforeHP - artur.HP;

      critText = dungeonMaster.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");

      Console.WriteLine("SoulLink");
      Console.WriteLine($"HP Данденмастера: {dungeonMaster.HP}, HP Артура: {artur.HP}");
      dungeonMaster.UseSkill(soulLink, artur);
      Console.WriteLine($"HP Данденмастера: {dungeonMaster.HP}, HP Артура: {artur.HP}");
      Console.WriteLine();

      Console.WriteLine("сoCaCoLaAaAa");
      artur.UseSkill(сoCaCoLaAaAa, dungeonMaster);
      Console.WriteLine();

      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(dungeonMaster.GetInfo());
      Console.WriteLine(artur.GetInfo());
      Console.ReadKey();

      /////////////////////////////////////////

      Console.WriteLine("ManaDrain");
      Console.WriteLine($"MP Данденмастера: {artur.MP}, MP Артура: {dungeonMaster.MP}");
      artur.UseSkill(manaDrain, dungeonMaster);
      Console.WriteLine($"MP Данденмастера: {artur.MP}, MP Артура: {dungeonMaster.MP}");
      Console.WriteLine();

      Console.WriteLine("SoulLink");
      Console.WriteLine($"HP Данденмастера: {dungeonMaster.HP}, HP Артура: {artur.HP}");
      dungeonMaster.UseSkill(soulLink, artur);
      Console.WriteLine($"HP Данденмастера: {dungeonMaster.HP}, HP Артура: {artur.HP}");
      Console.WriteLine();

      Console.WriteLine($"\nВТОРОЙ РАУНД.");

      Console.WriteLine($"{artur.Name} атакует {dungeonMaster.Name}!");

      beforeHP = dungeonMaster.HP;
      artur.Hit(dungeonMaster);
      damage = beforeHP - artur.HP;

      critText = artur.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");

      Console.WriteLine($"\nИспользуем ManaPotion +{manaPotion.Value}:");
      dungeonMaster += manaPotion;
      Console.WriteLine(dungeonMaster.GetInfo());

      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(dungeonMaster.GetInfo());
      Console.WriteLine(artur.GetInfo());
      Console.ReadKey();

      /////////////////////////////////////////////////////

      Console.WriteLine($"\nТРЕТИЙ РАУНД.");

      Console.WriteLine($"{dungeonMaster.Name} атакует {artur.Name}!");

      beforeHP = artur.HP;
      dungeonMaster.Hit(artur);
      damage = beforeHP - artur.HP;

      critText = dungeonMaster.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");

      Console.WriteLine($"\nИспользуем HealthPotion +{healPotion.Value}:");
      dungeonMaster += healPotion;
      Console.WriteLine(dungeonMaster.GetInfo());


      Console.WriteLine("сoCaCoLaAaAa");
      dungeonMaster.UseSkill(сoCaCoLaAaAa, artur);
      Console.WriteLine();

      Console.WriteLine("SoulLink");
      Console.WriteLine($"HP Данденмастера: {artur.HP}, HP Артура: {dungeonMaster.HP}");
      artur.UseSkill(soulLink, dungeonMaster);
      Console.WriteLine($"HP Данденмастера: {artur.HP}, HP Артура: {dungeonMaster.HP}");
      Console.WriteLine();

      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(dungeonMaster.GetInfo());
      Console.WriteLine(artur.GetInfo());
      Console.ReadKey();


    }
  }
}