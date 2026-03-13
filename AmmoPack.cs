using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG {
   public class AmmoPack : ConsumableItem {
    public AmmoPack(int value) : base(value) { }

    public override string GetDescription() {
      return $"Патроны (+{Value} Ammo)";
    }
  }
}

