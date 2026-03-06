using System;

namespace BoringRPG {
  internal class BerserkerClass : Archetype {
    private static Random random = new Random();
    private bool LastHitWasCrit;

    public BerserkerClass(string name, int hp, int mp, int ammo, int dmg, double crit) : base(name, 140, 0, 0, 30, 0.15) {
     }

    public BerserkerClass(string name) : base(name, 100, 50, 10, 20, 0.3) {
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
      return $"{Name} (Dummy): HP {HP}, MP {MP}, Ammo {Ammo}, Шанс крита {CritChance * 100}%";
    }
   }
}
