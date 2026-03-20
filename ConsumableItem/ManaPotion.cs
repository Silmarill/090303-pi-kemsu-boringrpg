using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG {
   public class ManaPotion : ConsumableItem {
    public ManaPotion(int value) : base(value) { }

    public override string GetDescription() {
      return $"Зелье маны (+{Value} MP)";
    }
  }
}

