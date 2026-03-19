using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG {
  internal abstract class ConsumableItem {
    public int Value { get; set; }

    protected ConsumableItem(int value) {
      Value = value;
    }

    // A method that will modify the characteristics of a specific hero
    public abstract void Apply(Archetype hero);
  }
}