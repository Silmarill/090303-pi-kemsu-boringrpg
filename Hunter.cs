using BoringRPG.Skills;
using System;

namespace BoringRPG {
  internal class Hunter : Archetype, ICanUseSkill {
    int maxHealth = 85;
    int maxMana = 20;
    int maxAmmo = 15;
    double critChance = 0.2;
    int isInvisible = 0;

    private static Random random = new Random();
    public bool LastHitWasCrit;

    protected Hunter(string name, int hp, int mp, int ammo, int dmg, double crit)
        : base(name, 85, 20, 15, 25, 0.2) {
    }

    public Hunter(string name)
      : base(name, 85, 20, 15, 25, 0.2) {
    }

    public void UseSkill(Skill skill, Archetype hun) {
      skill.Use(this, hun);
    }


    public static bool operator true(Hunter hun1) {
      return hun1.HP > 0;
    }
    public static bool operator false(Hunter hun1) {
      return hun1.HP <= 0;
    }

    public static Hunter operator +(Hunter hun, int regain) {

      if (hun.HP < hun.maxHealth) {
        hun.HP = hun.HP + regain;
        if (hun.HP > hun.maxHealth) {
          hun.HP = hun.maxHealth;
          return hun;
        }
      }
      return hun;

    }

    public static Hunter operator +(Hunter hun, HealthPotion firstAidKit) {
      hun.HP += firstAidKit.Value;
      if (hun.HP > hun.maxHealth) {
        hun.HP = hun.maxHealth;
      }
      return hun;
    }
    public static Hunter operator +(Hunter hun, ManaPotion manaPotion) {
      hun.MP += manaPotion.Value;
      if (hun.MP > hun.maxMana) {
        hun.MP = hun.maxMana;
      }
      return hun;
    }

    public static Hunter operator +(Hunter hun, AmmoPack ammoPack) {
      hun.Ammo += ammoPack.Value;
      if (hun.Ammo > hun.maxAmmo) {
        hun.Ammo = hun.maxAmmo;
      }
      return hun;
    }

    public static Hunter operator +(Hunter hun, InvisibilityPotion potion) {
      hun.isInvisible += 1;
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
      int minHp = 0;
      int lostAmmo = 1;
      int damageBonus = 10;
      int critDamageBonus = 2;

      int damage = Damage;
      if (this.Ammo > minAmmo) {
        this.Ammo -= lostAmmo;
      }

      if (isInvisible >= 1) {
        LastHitWasCrit = true;
        --isInvisible;
      } else {
        LastHitWasCrit = random.NextDouble() < critChance;
      }

      if (this.HP < target.HP) {
        damage += damageBonus;
      }
      if (LastHitWasCrit) {
        damage *= critDamageBonus;
      }

      target.HP -= damage;

      if (target.HP < minHp) {
        target.HP = minHp;
      }

    }

    public override string GetInfo() {
      return $"{Name} (Hunter): HP {HP}, MP {MP}, Ammo {Ammo}, Crit Chance: {CritChance * 100}%, Invisible {isInvisible}";
    }
  }
}