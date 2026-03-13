using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG {
  public class HealthPotion : ConsumableItem {
    public HealthPotion(int value) : base(value) { }

    public override string GetDescription() {
      return $"Зелье здоровья (+{Value} HP)";
    }
  }
}
