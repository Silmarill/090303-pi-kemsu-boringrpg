using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG
{
  internal class Heal : ConsumableItem
  {
    public Heal(int value = 30) : base(value)
    {
    }
  }
}
