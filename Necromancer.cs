using System;

namespace BoringRPG {
  internal class Necromancer : Archetype, ICanUseSkill {

    // Поле для хранения бонуса от скелетов
    private int skeletonBonus = 0;

    public Necromancer(string name) : base(name, 55, 90, 0, 30, 0.1) {
    }

    // Реализация интерфейса ICanUseSkill
    public string UseSkill(Skill skill, Archetype target) {

      // Использование навыка
      return skill.Use(this, target);
    }

    // Перегрузка "!"
    public static bool operator !(Necromancer hero) {
      // true (смерть), если Здоровье <= 0
      return hero.HP <= 0;
    }

    // Герой жив? (Здоровья > 0)
    public static bool operator true(Necromancer hero) {
      return hero.HP > 0;
    }

    // Герой мёртв? (Здоровья <= 0)
    public static bool operator false(Necromancer hero) {
      return hero.HP <= 0;
    }

    // Перегрузка (+ Здоровье)
    public static Necromancer operator +(Necromancer hero, int amount) {
      hero.HP += amount;
      return hero;
    }

    // Перегрузка (- Здоровье)
    public static Necromancer operator -(Necromancer hero, int amount) {
      hero.HP -= amount;
      return hero;
    }

    public override void Hit(Archetype target) {
      // Если маны достаточно для использования навыка, то условие выполняется
      if (MP >= 15) {
        MP -= 15;

        // Урон = стандартный урон + бонус от скелетов
        int currentDamage = Damage + skeletonBonus;
        int hpBefore = target.HP;

        target.HP -= currentDamage;

        // Если урон нанесён, призыв нового скелета (+5 к следующему инстансу)
        if (target.HP < hpBefore) {
          skeletonBonus += 5;
          Console.WriteLine($"{Name} бьёт магией! Был вызван скелет..");
        }
      }
      // Если маны мало, она наносит обычный урон
      else {
        target.HP -= Damage;
        Console.WriteLine($"{Name}: Маны недостаточно! Удары стандартным посохом.");
      }
    }

    // Переопределение GetInfo для отображения информации о герое
    public override string GetInfo() {
      return $"{Name} (Necromancer): HP {HP}, MP {MP}, Скелетный бонус +{skeletonBonus}, Текущий магический урон {Damage + skeletonBonus}";
    }
  }
}