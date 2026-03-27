using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG {
  public class ManaDrain : Skill {
    private static Random random = new Random();

    public ManaDrain() {
      Name = "ManaDrain";
    }

    internal override void Use(Archetype caster, Archetype target) {
      int drainValue = random.Next(10, 31);

      target.MP -= drainValue;
      caster.MP += drainValue;
    }
  }
}


