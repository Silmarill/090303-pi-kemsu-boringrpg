using BoringRPG.skills;
using BoringRPG.Skills;
using System;
using System.Runtime.ConstrainedExecution;

namespace BoringRPG
{
  class Program
  {
    static void Main(string[] args)
    {
      string critText;
      int beforeHP, damage, hill, hilAmmo;

      DummyClass artur = new DummyClass("Артур Пендрагон");
      Hunter cser = new Hunter("Красная линия");

      HealthPotion helthPotion = new HealthPotion(10);
      ManaPotion manaPotion = new ManaPotion(15);
      AmmoPack ammoPack = new AmmoPack(15);
      RagePotion rage = new RagePotion(50);

      Skill extreme = new Extreme();
      Skill manaDrain = new ManaDrain();
      Skill limonLime = new LimonLime();

      Console.WriteLine($"{cser.Name} использует зелье невидимости.\n");
      RagePotion newPotion = new RagePotion(1);
      cser += newPotion;

      Console.WriteLine($"Нынешнее состояние: \n" +
                         $"==================\n" +
                         $"{artur.GetInfo()}\n" +
                         $"{cser.GetInfo()}\n");
      Console.WriteLine($"{cser.Name} атакует {artur.Name}!");



      Console.WriteLine($"НАЧАЛО БИТВЫ. Исходное состояние: \n" +
                        $"==================\n" +
                        $"{cser.GetInfo()}\n" +
                        $"{artur.GetInfo()}\n");
      Console.WriteLine($"\n Красная линия подрубает рейдж +{rage.Value}:");
      cser += rage;
      Console.WriteLine(cser.GetInfo());

      Console.WriteLine($"{cser.Name} атакует {artur.Name}!");

      beforeHP = artur.HP;
      cser.Hit(artur);
      damage = beforeHP - artur.HP;

      critText = cser.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");

      Console.WriteLine("Extreme");
      Console.WriteLine($"HP красная линия: {cser.HP}, HP Артура: {artur.HP}");
      cser.UseSkill(extreme, artur);
      Console.WriteLine($"HP красная линия: {cser.HP}, HP Артура: {artur.HP}");
      Console.WriteLine();

      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(cser.GetInfo());
      Console.WriteLine(artur.GetInfo());
      Console.ReadKey();

      Console.WriteLine("ManaDrain");
      Console.WriteLine($"MP красная линия: {cser.MP}, MP Артура: {artur.MP}");
      cser.UseSkill(manaDrain, artur);
      Console.WriteLine($"MP красная линия: {cser.MP}, MP Артура: {artur.MP}");
      Console.WriteLine();

      if (cser)
      {
        Console.WriteLine($"{cser.Name} хорошая форма");
      }
      else
      {
        Console.WriteLine($"{cser.Name} на грани смерти!");
      }

      // ==================================================================

      Console.WriteLine($"\nВторой РАУНД.");

      Console.WriteLine($"{artur.Name} атакует {cser.Name}!");

      beforeHP = cser.HP;
      artur.Hit(cser);
      damage = beforeHP - artur.HP;

      critText = artur.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");

      Console.WriteLine($"\nИспользуется мана +{manaPotion.Value}:");
      cser += manaPotion;
      Console.WriteLine(cser.GetInfo());

      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(cser.GetInfo());
      Console.WriteLine(artur.GetInfo());
      Console.ReadKey();

      if (cser)
      {
        Console.WriteLine($"{cser.Name} хорошая форма");
      }
      else
      {
        Console.WriteLine($"{cser.Name} на грани смерти!");
      }

      // ===================================================================

      Console.WriteLine($"\nТретий раунд.");

      Console.WriteLine($"{cser.Name} атакует  {artur.Name}!");

      beforeHP = artur.HP;
      cser.Hit(artur);
      damage = beforeHP - artur.HP;

      critText = cser.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"\nИспользуется мана +{helthPotion.Value}:");
      cser += helthPotion;
      Console.WriteLine(cser.GetInfo());

      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
      Console.WriteLine("======================");
      Console.WriteLine(cser.GetInfo());
      Console.WriteLine(artur.GetInfo());
      Console.ReadKey();

      Console.WriteLine("limonnnnnLimeeeee");
      cser.UseSkill(limonLime, artur);
      Console.WriteLine();



      if (cser)
      {
        Console.WriteLine($"{cser.Name} хорошая форма");
      }
      else
      {
        Console.WriteLine($"{cser.Name} на грани смерти!");
      }


    }
  }
}
