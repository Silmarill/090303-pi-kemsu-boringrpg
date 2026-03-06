using System;

namespace BoringRPG {
  internal class archerClass : Archetype {

    //пример для работы со случайными числами
    private static Random random = new Random();
    public bool LastHitWasCrit;

    public archerClass(string name, int hp, int mp, int ammo, int dmg, double crit) : base(name, 80, 30, 20, 20, 0.25) {
      // HP=100, MP=50, Ammo=10, Damage=20, CritChance=0.3 (30%)
    }
    
    public archerClass(string name) : base(name, 80, 30, 20, 20, 0.25) {
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
    public static archerClass operator+ (archerClass left, int Value) {
      if (left.HP > 0) { 
        left.HP = Math.Min(left.HP + Value, 100);
      }
      return left;
    }
    
    public static archerClass operator- (archerClass left, int Value) {
      left.HP = Math.Min(left.HP - Value, 0);
      return left;
    }
  }
}
