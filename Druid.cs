using System;

namespace BoringRPG {
  internal class Druid : Archetype {
    private int maxHealth = 90;
    private int maxMana = 60;
    private int manaCost = 5; 
    private int hpThreshold = 45; 

    private static Random random = new Random();
    public bool LastHitWasCrit;

    public Druid(string name)
        : base(name, 90, 60, 0, 20, 0.10) {
    }

    public static bool operator true(Druid druid) {
      return druid.HP > 0;
    }

    public static bool operator false(Druid druid) {
      return druid.HP <= 0;
    }

    public static Druid operator +(Druid druid, int regain) {
      if (druid.HP < druid.maxHealth) {
        druid.HP = druid.HP + regain;
        if (druid.HP > druid.maxHealth) {
          druid.HP = druid.maxHealth;
        }
      }
      return druid;
    }

    public static Druid operator +(Druid druid, HealthPotion healthPotion) {
      druid.HP += healthPotion.Value;
      if (druid.HP > druid.maxHealth) {
        druid.HP = druid.maxHealth;
      }
      return druid;
    }

    public static Druid operator +(Druid druid, ManaPotion manaPotion) {
      druid.MP += manaPotion.Value;
      if (druid.MP > druid.maxMana) {
        druid.MP = druid.maxMana;
      }
      return druid;
    }

    public static Druid operator -(Druid druid, int damage) {
      int minHP = 0;

      if (druid.HP > minHP) {
        druid.HP -= damage;
        if (druid.HP < minHP) {
          druid.HP = minHP;
        }
      }
      return druid;
    }

    public override void Hit(Archetype target) {
      int minMana = 0;
      int minHp = 0;

      int damage = this.Damage;

      if (this.MP >= manaCost) {
        this.MP -= manaCost;

        if (target.HP > hpThreshold) {
          damage *= 2;
          LastHitWasCrit = true; 
        }
        else {
          LastHitWasCrit = false;
        }

        target.HP -= damage;

        if (target.HP < minHp) {
          target.HP = minHp;
        }
      }
      else {
        LastHitWasCrit = false;
        Console.WriteLine($"{Name} (Druid) Not enough mana to attack!");
      }
    }

    public override string GetInfo() {
      return $"{Name} (Druid): HP {HP}/{maxHealth}, MP {MP}/{maxMana}, Damage {Damage}, Crit Chance: {CritChance * 100}%";
    }
  }
}