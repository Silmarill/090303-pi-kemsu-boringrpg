using System;

namespace BoringRPG {
  internal class Necromancer : Archetype {

    // Поле для хранения бонуса от скелетов
    private int skeletonBonus = 0;

    // Конструктор
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
      // Проверка наличия 15 единиц маны перед тратой
      if (MP >= 15) {
        MP -= 15;

        // Текущий урон = базовый + бонус от скелетов
        int currentDamage = Damage + skeletonBonus;

        int hpBefore = target.HP;

        // Урон по цели
        target.HP -= currentDamage;

        // Если цель получила урон, увеличиваем бонус для следующего раза
        if (target.HP < hpBefore) {
          skeletonBonus += 5;
        }
      } else {
        Console.WriteLine($"{Name}: Недостаточно маны!");
      }
    }

    public override string GetInfo() {
      return $"{Name} (Necromancer): HP {HP}, MP {MP}, Бонус скелетов +{skeletonBonus}";
    }
  }
}