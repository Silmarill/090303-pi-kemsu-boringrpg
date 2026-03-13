using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG {
  internal class BugPotion : ConsumableItem {
    private static Random random = new Random();

    public BugPotion() : base(0) {
      Value = random.Next(1, 11);
    }

    public override string GetDescription() {
      return $"Зелье-баг (случайный эффект: {Value})";
    }
  }
}