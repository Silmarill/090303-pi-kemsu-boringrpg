using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG {
  abstract class ConsumableItem {
    public int Value;
    public ConsumableItem(int value) {
      Value = value;
    }

    public class HealthPotion : ConsumableItem {
      public HealthPotion(int value) : base(value) {
      }
    }

    public class ManaPotion : ConsumableItem {
      public ManaPotion(int value) : base(value) {
      }
    }
    public class AmmoPack : ConsumableItem {
      public AmmoPack(int value) : base(value) {
      }
    }

    public class CrazyArtifact : ConsumableItem {
      public CrazyArtifact(int value) : base(value) {
      }
    }
  }
}
