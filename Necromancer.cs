using System;

namespace BoringRPG {
  internal class Necromancer : Archetype {

    //пример для работы со случайными числами
    private static Random random = new Random();
    public bool LastHitWasCrit;

    private int _skeletonBonus;

    public Necromancer(string name, int hp, int mp, int ammo, int dmg, double crit) : base("necromancer", 55, 90, 0, 30, 0.1) {
      _skeletonBonus = 0;
    }

    public Necromancer(string name) : base("necromancer", 55, 90, 0, 30, 0.1) {
    }

    public static Necromancer operator +(Necromancer necromancer, int amount) {
      necromancer.HP += amount;
      return necromancer;
    }

    public static Necromancer operator -(Necromancer necromancer, int amount) {
      necromancer.HP -= amount;
      return necromancer;
    }

    public static bool operator true(Necromancer necromancer) {
      return necromancer.HP > 0;
    }

    public static bool operator false(Necromancer necromancer) {
      return necromancer.HP <= 0;
    }
      
    public override void Hit(Archetype target) {

      if (this.MP >= 15) { 

        this.MP -= 15;
        int damage = Damage + _skeletonBonus;

        LastHitWasCrit = random.NextDouble() < CritChance;
      
        if (LastHitWasCrit) {
          damage *= 2;
          Console.WriteLine($"{Name}:Critical hit!");
        }

        int targetHpBefore = target.HP;
                
        
        target.HP -= damage;
                
                
        if (targetHpBefore > target.HP) {
                    
          _skeletonBonus += 5;
          Console.WriteLine($"{Name}:Skeleton Summoned! Current Bonus:+{_skeletonBonus}");
        }
                
        Console.WriteLine($"{Name} attacks {target.Name} and applies {damage} damage!");
      } else {
        Console.WriteLine($"{Name}:Not enough mana to attack! (15 MP needed)");
      }
    }  

    public override string GetInfo() {
      return $"{Name} (necromancer): HP {HP}, MP {MP}, Ammo {Ammo}, Crit chance {CritChance * 100}%";
    }
  }
}
