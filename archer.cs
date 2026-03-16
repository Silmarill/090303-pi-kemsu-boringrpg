using System;

namespace BoringRPG {
  internal class Archer : Archetype {

    //пример для работы со случайными числами
    private static Random random = new Random();
    public bool LastHitWasCrit;
    public bool IsAlive => HP > 0;
    public int Healing = 20;
    public Archer(string name, int hp, int mp, int ammo, int dmg, double crit) : base(name, 80, 30, 20, 20, 0.25) {
      // HP=100, MP=50, Ammo=10, Damage=20, CritChance=0.3 (30%)
    }
    
    public Archer (string name) : base(name, 80, 30, 20, 20, 0.25) {
    }

    public static bool operator true (Archer archer) {
      return archer.HP > 0;
    }

    public static bool operator false (Archer archer) {
      return archer.HP <= 0;
    } 

    public static Archer operator+ (Archer archer, int healing) {
      archer.HP = Math.Min(archer.HP + healing, 100);
      return archer;
    }
    public static Archer operator + (Archer archer, HealthPotion point) { 
      archer.HP = Math.Min(archer.HP + point.Value, 100);
      Console.WriteLine($"\n{archer.Name} пополнил здоровье зельем + {point.Value} HP\n");
      return archer;
    }

    public static Archer operator + (Archer archer, ManaPoint point) { 
      archer.MP = Math.Min(archer.MP + point.Value, 50);
      Console.WriteLine($"\n{archer.Name} съел манго + {point.Value} MP\n");
      return archer;
    }

    public static Archer operator + (Archer archer, AmmoPack ammo) { 
      archer.Ammo += ammo.Value;
      Console.WriteLine($"\n{archer.Name} взял стрелу + {ammo.Value} Ammo\n");
      return archer;
    }
    
    public static Archer operator + (Archer archer, LitEnergy taurine) { 
      archer.HP += taurine.Value * 2;
      archer.MP += taurine.Value;
      Console.WriteLine($"\n{archer.Name} выпил Лит энерджи и набрался кондиций + {taurine.Value} MP + {taurine.Value * 2} HP\n");
      return archer;
    }
    public static Archer operator - (Archer archer, int damage) {
      archer.HP = Math.Max(archer.HP - damage,0);
      return archer;
    }

    public override void Hit(Archetype target) {
      if (Ammo >0) {
        Ammo --;
      
        int damage = Damage;
      
      // Метод NextDouble() - возвращает double в диапазоне [0.0; 1.0)
        LastHitWasCrit = random.NextDouble() < CritChance;
      
        if (LastHitWasCrit) {
          damage *= 2;
        }

        target.HP -= damage;
        } else {
          Console.WriteLine("нет патронов");
        }
      }

    public override string GetInfo() {
      return $"{Name} (Archer): HP {HP}, MP {MP}, Ammo {Ammo}, Шанс крита {CritChance * 100}%";
    }
  }
}
