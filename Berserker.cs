using System;

namespace BoringRPG {
  internal class Berserker : Archetype {
    private static Random random = new Random();
    public bool LastHitWasCrit;

    public Berserker(string name, int hp, int mp, int ammo, int dmg, double crit)
      : base(name, hp, mp, ammo, dmg, crit) {
    }

    public Berserker(string name) : base(name, 140, 0, 0, 30, 0.15) {
    }

    public static Berserker operator +(Berserker berserker, int amount) {
      berserker.HP += amount;
      return berserker;
    }

    public static Berserker operator -(Berserker berserker, int amount) {
      berserker.HP -= amount;
      return berserker;
    }

    public static bool operator true(Berserker berserker) {
      return berserker.HP > 0;
    }
    public static bool operator false(Berserker berserker) {
      return berserker.HP <= 0;
    }

    public override void Hit(Archetype target) {
      int damage = Damage;

      int rageBonus = (140 - HP) / 2;
      damage += rageBonus;

      LastHitWasCrit = random.NextDouble() < CritChance;
      if (LastHitWasCrit) {
        damage *= 2;
      }

      target.HP -= damage;
    }

    public override string GetInfo() {
      return $"{Name} (Berserker): HP {HP}/{140}, MP {MP}, Ammo {Ammo}, " +
             $"Урон {Damage}, Шанс крита {CritChance * 100}%, " +
             $"Бонус ярости: {(140 - HP) / 2}";
    }
    // ПЕРЕГРУЗКА 1: оператор + с разными предметами
    public static Berserker operator +(Berserker berserker, HealthPotion potion) {
      berserker.HP += potion.Value;
      Console.WriteLine($"❤️ {berserker.Name} +{potion.Value} HP");
      return berserker;
    }

    public static Berserker operator +(Berserker berserker, ManaPotion potion) {
      berserker.MP += potion.Value;
      Console.WriteLine($"💙 {berserker.Name} +{potion.Value} MP");
      return berserker;
    }

    public static Berserker operator +(Berserker berserker, AmmoPack ammo) {
      berserker.Ammo += ammo.Value;
      Console.WriteLine($"🔫 {berserker.Name} +{ammo.Value} Ammo");
      return berserker;
    }

    public static Berserker operator ++(Berserker berserker) {
      int effect = new Random().Next(1, 5);

      switch (effect) {
        case 1:
          berserker.HP += 20;
          Console.WriteLine($"🍄 Баг: +20 HP! (теперь {berserker.HP})");
          break;
        case 2:
          berserker.Damage += 10;
          Console.WriteLine($"⚡ Баг: +10 к урону! (теперь {berserker.Damage})");
          break;
        case 3:
          berserker.HP -= 15;
          Console.WriteLine($"💔 Баг: -15 HP! (теперь {berserker.HP})");
          break;
        case 4:
          berserker.CritChance += 0.1;
          Console.WriteLine($"🍀 Баг: +10% к криту! (теперь {berserker.CritChance * 100}%)");
          break;
      }

      return berserker;
    }
  }
} 