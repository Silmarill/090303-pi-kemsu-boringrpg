using System;

namespace BoringRPG {
  internal class DummyClass : Archetype, ICanUseSkill {

    // Пример использования рандома
    private static Random random = new Random();
    public bool LastHitWasCrit;


    // Конструкторы с дефолтными параметрами
    public DummyClass(string name, int hp, int mp, int ammo, int dmg, double crit) : base(name, 100, 50, 10, 20, 0.3) {
      // Здоровья = 100, Маны = 50, Аммуниции = 10, Урон = 20, Шанс крита = 0.3 (30%)
    }

    public DummyClass(string name) : base(name, 100, 50, 10, 20, 0.3) {
    }

    // Реализация интерфейса ICanUseSkill
    public string UseSkill(Skill skill, Archetype target) {
      return skill.Use(this, target);
    }

    public override string Hit(Archetype target) {
      string result = "";
      int damage = Damage;

      // Метод NextDouble() - Возвращает вещественное число в диапазоне от 0.0 до 1.0
      LastHitWasCrit = random.NextDouble() < CritChance;

      // Если удар критический, то наносится двойной урон
      if (LastHitWasCrit) {
        damage *= 2;
        result = $"КРИТИЧЕСКИЙ УДАР! {Name} влетает с двух ног и наносит {damage} урона по {target.Name}!\n";
      } else {
        result = $"{Name} наносит стандартный удар: {damage} урона по {target.Name}.\n";
      }

      target.HP -= damage;

      return result;
    }

    // Переопределение метода GetInfo для отображения информации о персонаже
    public override string GetInfo() {
      return $"{Name} (Груша): Здоровье {HP}, Мана {MP}, Аммуниция {Ammo}, Шанс крита {CritChance * 100}%.\n";
    }
  }
}
