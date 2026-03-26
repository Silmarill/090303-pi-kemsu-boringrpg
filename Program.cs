using System;

namespace BoringRPG {
  internal class Program {
    static void Main(string[] args) {
      string critText;
      int beforeHP, damage;

      DummyClass lancelot = new DummyClass("Ланселот Ловкий");
      DummyClass artur =    new DummyClass("Артур Пендрагон");
      BerserkerClass berserk = new BerserkerClass("Berserker");

      Console.WriteLine("НАЧАЛО БИТВЫ. Исходное состояние: \n" +
                        "==================\n" +
                        lancelot.GetInfo() + "\n" +
                        artur.GetInfo() + "\n" +
                        berserk.GetInfo() + "\n");

      Console.WriteLine(lancelot.Name + " атакует " + artur.Name + "!");
      Console.WriteLine(berserk.Name + " атакует " + lancelot.Name);

      beforeHP = artur.HP;
      lancelot.Hit(artur);
      damage = beforeHP - artur.HP;
      Console.WriteLine("======================");
      beforeHP = lancelot.HP;
      berserk.Hit(lancelot);
      damage = beforeHP - lancelot.HP;

      critText = lancelot.LastHitWasCrit ? " - критический удар!" : "";
      Console.WriteLine("Нанесено " + damage + " урона" + critText + "\n");

      Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:\n" +
                        "======================\n" +
                        lancelot.GetInfo() + "\n" +
                        artur.GetInfo() + "\n" +
                        "======================\n" +
                        lancelot.GetInfo() + "\n" +
                        berserk.GetInfo() + "\n");

      // ======================================================
      // ЭТАП 2: Демонстрация расходников
      // ======================================================
      Console.WriteLine("\n==========================================");
      Console.WriteLine("ПРИВАЛ. Время расходников.");
      Console.WriteLine("==========================================\n");

      Archetype target;

      Console.WriteLine("До: " + lancelot.GetInfo());
      target = lancelot;
      target += new HealthPotion(40);
      Console.WriteLine("После HealthPotion(40): " + lancelot.GetInfo() + "\n");

      Console.WriteLine("До: " + artur.GetInfo());
      target = artur;
      target += new ManaPotion(30);
      Console.WriteLine("После ManaPotion(30): " + artur.GetInfo() + "\n");

      Console.WriteLine("До: " + berserk.GetInfo());
      target = berserk;
      target += new AmmoPack(5);
      Console.WriteLine("После AmmoPack(5): " + berserk.GetInfo() + "\n");

      Console.WriteLine("До: " + lancelot.GetInfo());
      target = lancelot;
      target *= new CoffeeCup(3);
      Console.WriteLine("После CoffeeCup(3): " + lancelot.GetInfo());
      Console.WriteLine("(тройной эспрессо. Руки дрожат, но крит-шанс утроен.)\n");

      // ======================================================
      // ЭТАП 3: Демонстрация навыков
      // ======================================================
      Console.WriteLine("\n==========================================");
      Console.WriteLine("ЭТАП 3: НАВЫКИ");
      Console.WriteLine("==========================================\n");

      // SoulLink — уравнивает HP между героями
      Console.WriteLine("--- SoulLink ---");
      Console.WriteLine("До: " + lancelot.GetInfo());
      Console.WriteLine("До: " + artur.GetInfo());
      Skill soulLink = new SoulLink();
      lancelot.UseSkill(soulLink, artur);
      Console.WriteLine("После: " + lancelot.GetInfo());
      Console.WriteLine("После: " + artur.GetInfo() + "\n");

      // Taunt — снижает крит-шанс противника на 50%
      Console.WriteLine("--- Taunt ---");
      Console.WriteLine("До: " + berserk.GetInfo());
      Taunt taunt = new Taunt();
      lancelot.UseSkill(taunt, berserk);
      Console.WriteLine("После Taunt: " + berserk.GetInfo());
      taunt.Restore(berserk);
      Console.WriteLine("После восстановления: " + berserk.GetInfo() + "\n");

      // DramaAction — случайный эффект (может переименовать или вывести фразу)
      Console.WriteLine("--- DramaAction (x3 броска) ---");
      Skill drama = new DramaAction();
      artur.UseSkill(drama, lancelot);
      artur.UseSkill(drama, lancelot);
      artur.UseSkill(drama, lancelot);

      Console.ReadKey();
    }
  }
}
