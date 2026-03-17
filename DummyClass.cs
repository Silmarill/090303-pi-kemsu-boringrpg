using System;

namespace BoringRPG {
  public class DummyClass : Archetype {
    private static Random random = new Random();
    public bool LastHitWasCrit;

    public DummyClass(string name) : base(name, 100, 50, 10, 20, 0.3) {
    }

    public override void Hit(Archetype target) {
      int damage = Damage;

      LastHitWasCrit = random.NextDouble() < CritChance;

      if (LastHitWasCrit) {
        damage *= 2;
      }

      target.HP -= damage;
    }

    public override string GetInfo() {
      return $"{Name}: HP {HP}/100, MP {MP}/50, Ammo {Ammo}, Crit chance {CritChance * 100}%";
    }
  }
}