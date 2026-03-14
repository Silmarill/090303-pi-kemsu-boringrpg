using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG {
  internal class HealthPotion : ConsumableItem {
    public HealthPotion(int value) : base(value) {
    }
  }
}