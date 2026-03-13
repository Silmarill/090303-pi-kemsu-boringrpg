using System;

namespace BoringRPG {
  internal class DummyClass : Archetype {

    //пример для работы со случайными числами
    private static Random random = new Random();
    public bool LastHitWasCrit;
    public bool IsAlive => HP > 0;
    public DummyClass(string name, int hp, int mp, int ammo, int dmg, double crit) : base(name, 100, 50, 10, 20, 20, 0.3) {
      // HP=100, MP=50, Ammo=10, Damage=20, CritChance=0.3 (30%)
    }
    
    public DummyClass(string name) : base(name, 100, 50, 10, 20, 20, 0.3) {
    }
    public static bool operator true(DummyClass dummy) {
      return dummy.HP > 0;
    }

    public static bool operator false(DummyClass dummy) {
      return dummy.HP <= 0;
    }


    public static DummyClass operator + (DummyClass dummy, int healing) {
      dummy.HP = Math.Min(dummy.HP + healing, 100);
      return dummy;
    } 

    public static DummyClass operator - (DummyClass dummy, int damage) {
      dummy.HP = Math.Max(dummy.HP - damage,0);
      return dummy;
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
