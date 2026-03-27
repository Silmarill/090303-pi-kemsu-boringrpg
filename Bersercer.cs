using BoringRPG;
using System;
using System.Security.AccessControl;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace BoringRPG {
  internal class Berserker : Archetype, ICanUseSkill {
    private static Random random = new Random();
    public bool LastHitWasCrit;

    public Berserker(string name, int hp, int mp, int ammo, int dmg, double crit) : base(name, 140, 0, 0, 30, 0.15) {

    }
    public Berserker(string name) : base(name, 140, 0, 0, 30, 0.15) {

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

    public static Berserker operator +(Berserker berserker, int value) {
      berserker.HP += value;
      return berserker;
    }

    public static Berserker operator -(Berserker berserker, int value) {
      berserker.HP -= value;
      return berserker;
    }

    public static bool operator true(Berserker berserker) {
      return berserker.HP > 0;
    }

    public static bool operator false(Berserker berserker) {
      return berserker.HP <= 0;
    }

    public static Berserker operator +(Berserker berserker, HealthPotion potion) {
      berserker.HP += potion.Value;
      Console.WriteLine($"{berserker.Name} использовал зелье здоровья (+HP).\n");
      return berserker;
    }

    public static Berserker operator +(Berserker berserker, ManaPotion potion) {
      berserker.MP += potion.Value;
      Console.WriteLine($"{berserker.Name} использовал зелье маны (+MP).\n");
      return berserker;
    }

    public static Berserker operator +(Berserker berserker, AmmoPack ammo) {
      berserker.Ammo += ammo.Value;
      Console.WriteLine($"{berserker.Name} увеличил боезапас (+Ammo).\n");
      return berserker;
    }

    public static Berserker operator +(Berserker berserker, CritPotion potion) {
      berserker.CritChance += potion.Value;
      Console.WriteLine($"{berserker.Name} использовал зелье критического удара (+{potion.Value * 100}% к шансу крита).\n");
      return berserker;
    }

    public override string GetInfo() {
      return $"{Name} (Berserker): HP {HP}, MP {MP}, Ammo {Ammo}, Crit Chance {CritChance * 100}%\n";
    }

    public void UseSkill(Skill skill, Archetype target) {
      skill.Use(this, target);
    }
  }
}
