using System;

namespace BoringRPG {
  internal class Hunter : Archetype {
     double critChance = 0.2;


    private static Random random = new Random();
    public bool LastHitWasCrit;

    protected Hunter(string name, int hp, int mp, int ammo, int dmg, double crit)
        : base(name, 85, 20, 15, 25, 0.2) { 
    }

    public Hunter(string name) 
      : base(name, 85, 20, 15, 25, 0.2) {
    }

    public static bool operator true(Hunter hun1) {
          return hun1.HP > 0;
    }
    public static bool operator false(Hunter hun1) {
            return hun1.HP <= 0;
    }

    public static Hunter operator +(Hunter man, int regain) {
      int maxHP = 85;

      if (man.HP < maxHP) {
        man.HP = man.HP + regain;
        if (man.HP > maxHP) {
          man.HP = maxHP;
          return man;
        }
      }
      return man;

    }

    public static Hunter operator +(Hunter hun, HealthPotion firstAidKit) {
      hun.HP += firstAidKit.Value;
      return hun;
    }
    public static Hunter operator +(Hunter hun, ManaPotion firstAidKit) {
      hun.HP += firstAidKit.Value;
      return hun;
    }

    public static Hunter operator +(Hunter hun, AmmoPack firstAidKit) {
      hun.HP += firstAidKit.Value;
      return hun;
    }

    public static Hunter operator -(Hunter man, int damage) {
      int minHP = 0;

      if (man.HP > minHP) {
        man.HP -= damage;
        if (man.HP < minHP) {
          man.HP = minHP;
          return man;
        }
      }
      return man;

    }

    public override void Hit(Archetype target) {
      int minAmmo = 0;
      int lostAmmo = 1;
      int damageBonus = 10;
      int critDamageBonus = 2;

      int damage = Damage;
      if (this.Ammo > minAmmo) {
        this.Ammo -= lostAmmo;
      }

      LastHitWasCrit = random.NextDouble() < critChance;

      if (this.HP < target.HP) {
        damage += damageBonus; 
      }
      if (LastHitWasCrit) {
        damage *= critDamageBonus;
      }

      target.HP -= damage;

    }

    public override string GetInfo() {
      return $"{Name} (Hunter): HP {HP}, MP {MP}, Ammo {Ammo}, Crit Chance: {CritChance * 100}%";
    }
  }

}

