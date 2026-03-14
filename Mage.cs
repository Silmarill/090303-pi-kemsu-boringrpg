using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BoringRPG.ConsumableItem;

namespace BoringRPG {
  internal class Mage : Archetype {
    private static Random random = new Random();
    public bool LastHitWasCrit;

    public Mage(string name, int hp, int mp, int ammo, int dmg, double crit) : base(name, 60, 100, 0, 35, 0.05) {

    }
    public Mage(string name) : base(name, 60, 100, 0, 35, 0.05) {

    }
    public override void Hit(Archetype target) {
      int damage = Damage;

      if (MP >= 10) {
        MP -= 10;
        LastHitWasCrit = random.NextDouble() < CritChance;

        if (LastHitWasCrit) {
          damage *= 2;
        }

        target.HP -= damage;
      }

    }
    public static Mage operator +(Mage mage, int value) {
      mage.HP += value;
      return mage;
    }

    public static Mage operator -(Mage mage, int value) {
      mage.HP -= value;
      return mage;
    }
    public static bool operator true(Mage mage) {
      return mage.HP > 0;
    }

    public static bool operator false(Mage mage) {
      return mage.HP <= 0;
    }

    public static Mage operator +(Mage mage, ConsumableItem consumable) {
      if (consumable is HealthPotion) {
        mage.HP += consumable.Value;
        Console.WriteLine($"{mage.Name} использовал зелье здоровья(+HP).\n");
      }
      else if (consumable is ManaPotion) {
        mage.MP += consumable.Value;
        Console.WriteLine($"{mage.Name} использовал зелье маны(-MP).\n");
      }
      else if (consumable is AmmoPack) {
        mage.Ammo += consumable.Value;
        Console.WriteLine($"{mage.Name} увеличил боезапас(+Ammo).\n");
      }

      return mage;
    }

    public static Mage operator -(Mage mage, ConsumableItem consumable) {
      mage.HP -= consumable.Value;
      mage.MP = 0;
      mage.CritChance *= 5;
      Console.WriteLine($"{mage.Name} активировал безумный артефакт(-HP, -MP, CritChance * 5).\n");
      return mage;
    }
    public override string GetInfo() {
      return $"{Name} (Mage): HP {HP}, MP {MP}, Ammo {Ammo}, Crit Chance {CritChance * 100}%\n";
    }
  }
}
