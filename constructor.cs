//using System;

//namespace work
//{
//  internal class DummyClass : Warrior
//  {

//    //пример для работы со случайными числами
//    private static Random random = new Random();
//    public bool LastHitWasCrit;

//    public DummyClass(string name, int hp, int mp, int ammo, int dmg, double crit) : base(name, 120, 20, 0, 25, 0.1)
//    {

//    }
//    public override void Hit(Warrior target)
//    {
//      int damage = Damage + 5;

//      // Метод NextDouble() - возвращает double в диапазоне [0.0; 1.0)
//      LastHitWasCrit = random.NextDouble() < CritChance;

//      if (LastHitWasCrit)
//      {
//        damage *= 2;
//      }

//      target.HP -= damage;
//    }

//    public override string GetInfo()
//    {
//      return $"{Name} (Dummy): HP {HP}, MP {MP}, Ammo {Ammo}, Шанс крита {CritChance * 100}%";
//    }
//  }
//}
