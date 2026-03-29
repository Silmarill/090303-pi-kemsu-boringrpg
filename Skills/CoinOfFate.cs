using System;

namespace BoringRPG {
  internal class CoinOfFate : Skill {
    static Random random = new Random();
    int chance;
    int firstChancePoint = 30;
    int secondChancePoint = 60;

    public CoinOfFate() : base("CoinOfFate") { 
    }

    public override void Use(Archetype caster, Archetype target) {

      chance = random.Next(100);

      if (chance < firstChancePoint) {
        target.HP = 0;
      } else if (chance < secondChancePoint) {
        caster.HP = 0;
      }
    }
  }
}
