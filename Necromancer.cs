using System;

namespace BoringRPG {
  internal class Necromancer : Archetype {

    // Поле для хранения бонуса от скелетов
    private int skeletonBonus = 0;

    public Necromancer(string name) : base(name, 55, 90, 0, 30, 0.1) {
    }

    // Перегрузка оператора (+ HP)
    public static Necromancer operator +(Necromancer hero, int amount) {
      hero.HP += amount;
      return hero;
    }

    // Перегрузка оператора (- HP)
    public static Necromancer operator -(Necromancer hero, int amount) {
      hero.HP -= amount;
      return hero;
    }

    public override void Hit(Archetype target) {
      // Если мана есть
      if (MP >= 15) {
        MP -= 15;

        // Урон = дефолтный урон + накопленные скелеты
        int currentDamage = Damage + skeletonBonus;
        int hpBefore = target.HP;

        target.HP -= currentDamage;

        // Если урон нанесен, призыв нового скелета (+5 к следующему разу)
        if (target.HP < hpBefore) {
          skeletonBonus += 5;
          Console.WriteLine($"{Name} бьет магией! Призван скелет.");
        }
      }
      // Если маны мало, обычный дамаг
      else {
        target.HP -= Damage;
        Console.WriteLine($"{Name}: Мало маны! Удар обычным посохом.");
      }
    }

    public override string GetInfo() {
      return $"{Name} (Necromancer): HP {HP}, MP {MP}, Бонус скелетов +{skeletonBonus}, Текущий маг. урон {Damage + skeletonBonus}";
    }
  }
}