using System;

namespace BoringRPG
{
  internal class Program
  {
    static void Main(string[] args)
    {
      string critText;
      int beforeHP, damage;

      DummyClass lancelot = new DummyClass("Ланселот Ловкий");
      HunterClass amogus = new HunterClass("Амогус Гус");

      int healPackage;
      healPackage = 15;

      Console.WriteLine("\n----- ИСПОЛЬЗОВАНИЕ ПРЕДМЕТОВ -----");

      HealthPotion healthPotion = new HealthPotion(30);
      ManaPotion manaPotion = new ManaPotion(20);
      AmmoPack ammoPack = new AmmoPack(8);
      EnergyDrink energyDrink = new EnergyDrink(24);

      CharacterWithItems wrappedLancelot = new CharacterWithItems(lancelot);
      CharacterWithItems wrappedAmogus = new CharacterWithItems(amogus);

      Console.WriteLine($"\n{amogus.Name} находит зелье здоровья ({healthPotion.Value} ед.)!");
      wrappedAmogus = wrappedAmogus + healthPotion;

      Console.WriteLine($"\n{lancelot.Name} находит зелье маны ({manaPotion.Value} ед.)!");
      wrappedLancelot = wrappedLancelot + manaPotion;

      Console.WriteLine($"\n{amogus.Name} находит патроны ({ammoPack.Value} шт.)!");
      wrappedAmogus = wrappedAmogus + ammoPack;

      Console.WriteLine($"\n{amogus.Name} выпивает энергетик!");
      wrappedAmogus = wrappedAmogus + energyDrink;

      Console.WriteLine($"\n{amogus.Name} находит второй энергетик и смешивает их!");
      ++energyDrink;
      wrappedAmogus = wrappedAmogus + energyDrink;

      Console.WriteLine(
        "\n----- СОСТОЯНИЕ ПОСЛЕ ПРЕДМЕТОВ -----" +
        "\n" + lancelot.GetInfo() + "" +
        "\n" + amogus.GetInfo() + "" +
        "\n\n----- ПРОДОЛЖЕНИЕ БИТВЫ -----"
        );

      Console.WriteLine("Амогус находит аптечку и лечится!");
      amogus = amogus + healPackage;

      if (amogus ? false : true)
      {
        Console.WriteLine("О нет! Амогус слишком слаб для битвы!");
        return;
      }

      Console.WriteLine(
        "НАЧАЛО БИТВЫ. Исходное состояние: " +
        "\n==================" +
        "\n{lancelot.GetInfo()}" +
        "\n{amogus.GetInfo()}\n"
        );

      Console.WriteLine($"{amogus.Name} атакует {lancelot.Name}");

      beforeHP = lancelot.HP;
      amogus.Hit(lancelot);
      damage = beforeHP - lancelot.HP;

      critText = amogus.LastHitWasCrit ? " - КРИТИЧЕСКИЙ УДАР!" : "";

      Console.WriteLine($"Нанесено {damage} урона{critText}\n");

      int counterDamage = 10;

      if (lancelot.HP > 0)
      {
        Console.WriteLine($"{lancelot.Name} контратакует!");
        amogus = amogus - counterDamage;
      }

      Console.WriteLine(
        "ИТОГОВОЕ СОСТОЯНИЕ:" +
        "\n======================" +
        "\n" + lancelot.GetInfo() + "" +
        "\n" + amogus.GetInfo()
        );

      Console.WriteLine(
        "\n\n===== ДЕМОНСТРАЦИЯ НАВЫКОВ =====" +
        "\nТекущее состояние персонажей:" +
        "\n" + lancelot.GetInfo() + "" +
        "\n" + amogus.GetInfo()
        );

      SoulLink soulLink = new SoulLink();
      Taunt taunt = new Taunt();
      CoinOfFate coin = new CoinOfFate();

      Console.WriteLine(
        "\n1. Применяем SoulLink:" +
        "\n   " + amogus.Name + 
        " связывает свою жизнь с " + 
        lancelot.Name
        );
      amogus.UseSkill(soulLink, lancelot);
      Console.WriteLine(
        "   После SoulLink:" +
        "\n   " + lancelot.Name + 
        ": HP " + lancelot.HP + 
        "\n   " + amogus.Name + 
        ": HP " + amogus.HP
        );

      Console.WriteLine(
        "\n2. Применяем Taunt:" +
        "\n   " + amogus.Name + 
        " насмехается над " + lancelot.Name
        );
      amogus.UseSkill(taunt, lancelot);

      Console.WriteLine(
        "\n3. Применяем CoinOfFate:" +
        "\n   " + amogus.Name + 
        " подбрасывает монетку судьбы над " + lancelot.Name
        );
      amogus.UseSkill(coin, lancelot);

      Console.WriteLine(
        "\n===== ИТОГОВОЕ СОСТОЯНИЕ ПОСЛЕ НАВЫКОВ =====" +
        "\n" + lancelot.GetInfo() + 
        "\n" + amogus.GetInfo()
        );

      Console.ReadKey();
    }
  }
}