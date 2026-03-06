using System;

namespace BoringRPG {
  internal class DummyClass : Archetype {

    //пример для работы со случайными числами
    private static Random random = new Random();
    public bool LastHitWasCrit;

    public DummyClass(string name, int hp, int mp, int ammo, int dmg, double crit) : base(name, 80, 30, 20, 20, 0.25) {
      // HP=100, MP=50, Ammo=10, Damage=20, CritChance=0.3 (30%)
    }
   
    public DummyClass(string name) : base(name, 80, 30, 20, 20, 0.25) {
    }

    public override void Hit(Archetype target) {
      int damage = Damage;
      
      // Метод NextDouble() - возвращает double в диапазоне [0.0; 1.0)
      LastHitWasCrit = random.NextDouble() < CritChance;
      
      if (LastHitWasCrit) {
        damage *= 2;
      }

      Ammo--;
      target.HP -= damage;
    }

    public override string GetInfo() {
      return $"{Name} (Dummy): HP {HP}, MP {MP}, Ammo {Ammo}, Шанс крита {CritChance * 100}%";
    }
  }
}
