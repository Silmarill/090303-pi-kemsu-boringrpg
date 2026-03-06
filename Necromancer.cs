using System;

namespace BoringRPG {
  internal class Necromancer : Archetype {

    //пример для работы со случайными числами
    private static Random random = new Random();
    public bool LastHitWasCrit;

    public Necromancer(string name, int hp, int mp, int ammo, int dmg, double crit) : base("necromancer", 55, 90, 0, 30, 0.1) {
    }

    public Necromancer(string name) : base("necromancer", 55, 90, 0, 30, 0.1) {
    }

    public static Necromancer operator +(Necromancer necromancer, int amount) {
      necromancer.HP += amount;
      return amount;
    }

    public static Necromancer operator -(Necromancer necromancer, int amount) {
      necromancer.HP -= amount;
      return amount;
    }

    public static bool operator true(Necromancer necromancer) {
      return necromancer.HP > 0;
    }

    public static bool operator false(Necromancer necromancer) {
      return necromancer.HP <= 0;
    }
      
    public override void Hit(Archetype target) {
      int damage = Damage;
      
      // Метод NextDouble() - возвращает double в диапазоне [0.0; 1.0)
      LastHitWasCrit = random.NextDouble() < CritChance;
      
      if (LastHitWasCrit) {
        damage *= 2;
      }

      target.HP -= damage;
    }

    public override string GetInfo() {
      return $"{Name} (Dummy): HP {HP}, MP {MP}, Ammo {Ammo}, Шанс крита {CritChance * 100}%";
    }
  }
}
