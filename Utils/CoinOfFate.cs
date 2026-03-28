using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG {
  internal class CoinOfFate : Skill {
    private static Random random = new Random();

    public CoinOfFate() : base("CoinOfFate") { }

    public override void Use(Archetype caster, Archetype target) {
      int chance = random.Next(100);

      if (chance < 30) {
        target.HP = 0;
      } else if (chance < 60) {
        caster.HP = 0;
      }
    }
  }
}
