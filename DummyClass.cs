using System;

namespace BoringRPG {
  internal class DummyClass : Archetype, ICanUseSkill {

    // example for using random
    private static Random random = new Random();
    public bool LastHitWasCrit;

    public DummyClass(string name, int hp, int mp, int ammo, int dmg, double crit) : base(name, 100, 50, 10, 20, 0.3) {
      // HP=100, MP=50, Ammo=10, Damage=20, CritChance=0.3 (30%)
    }

    public DummyClass(string name) : base(name, 100, 50, 10, 20, 0.3) {
    }

    // ICanUseSkill interface realisation
    public void UseSkill(Skill skill, Archetype target) {
      skill.Use(this, target);
    }

    public override void Hit(Archetype target) {
      int damage = Damage;

      // Method NextDouble() - return double in range [0.0; 1.0)
      LastHitWasCrit = random.NextDouble() < CritChance;

      if (LastHitWasCrit) {
        damage *= 2;
      }

      target.HP -= damage;
    }

    public override string GetInfo() {
      return $"{Name} (Dummy): HP {HP}, MP {MP}, Ammo {Ammo}, Crit chanse {CritChance * 100}%";
    }
  }
}
