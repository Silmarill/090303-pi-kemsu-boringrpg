using System;

namespace BoringRPG {
  internal class Druid : Archetype {
    private int maxHealth = 90;
    private int maxMana = 60;
    private int manaCost = 5; 
    private int hpThreshold = 45; 
    private int damageBonus = 0; 
    private double critBonus = 0; 

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

    public static Druid operator +(Druid druid, HealthPotion potion) {
      int oldHP = druid.HP;
      druid.HP += potion.Value;
      if (druid.HP > druid.maxHealth) {
        druid.HP = druid.maxHealth;
      }
      int healed = druid.HP - oldHP;
      Console.WriteLine($"{druid.Name} выпил зелье здоровья и восстановил {healed} HP!");
      return druid;
    }

    public static Druid operator +(Druid druid, ManaPotion potion) {
      int oldMP = druid.MP;
      druid.MP += potion.Value;
      if (druid.MP > druid.maxMana) {
        druid.MP = druid.maxMana;
      }
      int recovered = druid.MP - oldMP;
      Console.WriteLine($"{druid.Name} выпил зелье маны и восстановил {recovered} MP!");
      return druid;
    }

    public static Druid operator +(Druid druid, NaturePotion potion) {
      druid.damageBonus += potion.Value;
      Console.WriteLine($"{druid.Name} использовал зелье природы! Урон увеличен на {potion.Value} (текущий бонус: {druid.damageBonus})");
      return druid;
    }

    public static Druid operator +(Druid druid, MoonBerry berry) {
      druid.critBonus = berry.Value / 100.0; 
      Console.WriteLine($"{druid.Name} съел лунную ягоду! Шанс крита временно увеличен на {berry.Value}%!");
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

    public static Druid operator *(Druid druid, MoonBerry berry) {
      druid.damageBonus += 20;
      Console.WriteLine($"{druid.Name} съел две лунные ягоды! Урон увеличен на 20!");
      return druid;
    }

    public override void Hit(Archetype target) {
      int minMana = 0;
      int minHp = 0;

      int damage = this.Damage + damageBonus;

      double currentCritChance = CritChance + critBonus;

      if (this.MP >= manaCost) {
        this.MP -= manaCost;

        if (target.HP > hpThreshold) {
          damage *= 2; 
          LastHitWasCrit = true;
        }
        else {
          LastHitWasCrit = random.NextDouble() < currentCritChance;
          if (LastHitWasCrit) {
            damage *= 2; 
          }
        }

        Console.WriteLine($"{Name} атакует и наносит {damage} урона! (Крит: {LastHitWasCrit})");

        target.HP -= damage;

        if (target.HP < minHp) {
          target.HP = minHp;
        }
      }
      else {
        Console.WriteLine($"{Name} не хватает маны для атаки! Нужно {manaCost} MP, а есть {MP}");
        LastHitWasCrit = false;
      }
    }

    public override string GetInfo() {
      double totalCritChance = (CritChance + critBonus) * 100;
      return $"{Name} (Druid): HP {HP}/{maxHealth}, MP {MP}/{maxMana}, Damage {Damage + damageBonus} (Base: {Damage} + Bonus: {damageBonus}), Crit Chance: {totalCritChance:F1}%";
    }
  }
}