using System;
using BoringRPG.Items;
using BoringRPG.Skills;

namespace BoringRPG
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("ТРЕТИЙ ЭТАП: СИСТЕМА НАВЫКОВ\n");

      Berserker berserker1 = new Berserker("Конан-варвар");
      Berserker berserker2 = new Berserker("Артур-король");

      Console.WriteLine("Начальное состояние:");
      Console.WriteLine(berserker1.GetInfo());
      Console.WriteLine(berserker2.GetInfo());

      Skill soulLink = new SoulLink();
      Skill dramaAction = new DramaAction();
      Skill coinOfFate = new CoinOfFate();

      Console.WriteLine("\nНАВЫК 1: SoulLink (перераспределение HP)");
      int beforeHP1 = berserker1.HP;
      int beforeHP2 = berserker2.HP;
      berserker1.UseSkill(soulLink, berserker2);
      int afterHP1 = berserker1.HP;
      int afterHP2 = berserker2.HP;
      Console.WriteLine($"До применения: HP {beforeHP1} и {beforeHP2}");
      Console.WriteLine($"После применения: HP {afterHP1} и {afterHP2}");

      Console.WriteLine("\nНАВЫК 2: DramaAction (переименование)");
      string beforeNameCaster = berserker2.Name;
      string beforeNameTarget = berserker1.Name;
      berserker2.UseSkill(dramaAction, berserker1);
      string afterNameCaster = berserker2.Name;
      string afterNameTarget = berserker1.Name;

      if (beforeNameCaster != afterNameCaster)
      {
        Console.WriteLine($"{beforeNameCaster} теперь называется {afterNameCaster}!");
      }
      else if (beforeNameTarget != afterNameTarget)
      {
        Console.WriteLine($"{beforeNameTarget} теперь называется {afterNameTarget}!");
      }
      else
      {
        Console.WriteLine($"{beforeNameCaster} дарит розу {beforeNameTarget}!");
      }

      Console.WriteLine("\nНАВЫК 3: CoinOfFate");
      int beforeCasterHP = berserker1.HP;
      int beforeTargetHP = berserker2.HP;
      berserker1.UseSkill(coinOfFate, berserker2);
      int afterCasterHP = berserker1.HP;
      int afterTargetHP = berserker2.HP;

      if (afterTargetHP <= 0 && beforeTargetHP > 0)
      {
        Console.WriteLine($"{berserker2.Name} повержен!");
      }
      else if (afterCasterHP <= 0 && beforeCasterHP > 0)
      {
        Console.WriteLine($"{berserker1.Name} повержен!");
      }
      else
      {
        Console.WriteLine("Ничего не произошло.");
      }

      Console.WriteLine("\nИТОГОВОЕ СОСТОЯНИЕ");
      Console.WriteLine(berserker1.GetInfo());
      Console.WriteLine(berserker2.GetInfo());

      Console.ReadKey();
    }
  }
}