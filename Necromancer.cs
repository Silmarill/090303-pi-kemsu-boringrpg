using System;

namespace BoringRPG {
  internal class Necromancer : Archetype {

    //пример для работы со случайными числами
    private static Random random = new Random();
    public bool LastHitWasCrit;

    private int _skeletonBonus;

    public Necromancer(string name, int hp, int mp, int ammo, int dmg, double crit) : base(name, 55, 90, 0, 30, 0.1) {
      _skeletonBonus = 0;
    }

    public Necromancer(string name) : base(name, 55, 90, 0, 30, 0.1) {
      _skeletonBonus = 0;
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
          Console.WriteLine($"{Name}:Критический удар!");
        }

        int targetHpBefore = target.HP;
                
        
        target.HP -= damage;
                
                
        if (targetHpBefore > target.HP) {
                    
          _skeletonBonus += 5;
          Console.WriteLine($"{Name}:Скелет призван! Текущий бонус:+{_skeletonBonus}");
        }
                
        Console.WriteLine($"{Name} атаки {target.Name} и наносит  {damage} урона!");
      } else {
        Console.WriteLine($"{Name}:Недостаточно маны для атаки! (15 MP needed)");
      }
    }  

    public override string GetInfo() {
      string bonusInfo = _skeletonBonus > 0 ? $" | Skeleton bonus: +{_skeletonBonus}" : "";
      return $"{Name} (necromancer): HP {HP}, MP {MP}, Ammo {Ammo}, Damage {Damage}{bonusInfo},  Crit chance {CritChance * 100}%";
    }
  }
}
