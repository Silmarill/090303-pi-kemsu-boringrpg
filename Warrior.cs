using System;

namespace BoringRPG {
  internal class Warrior : Archetype {

    private static Random random = new Random();
    public bool LastHitWasCrit;

    public Warrior(string name) : base(name, 120, 20, 0, 25, 0.1) {
    }

    public override void Hit(Archetype target) {
      int damage = Damage;

      if (HP <= 5) {
        return;
      }

      HP -= 5;
      damage = Damage + 5;

      LastHitWasCrit = random.NextDouble() < CritChance;

      if (LastHitWasCrit) {
        damage *= 2;
      }

      target.HP -= damage;
    }

    public override string GetInfo() {
      return $"{Name} (Warrior): HP {HP}, MP {MP}, Ammo {Ammo}, Шанс крита {CritChance * 100}%";
    }
  }
}
