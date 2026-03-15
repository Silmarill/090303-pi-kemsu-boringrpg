using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG
{
  internal class AmmoPack : ConsumableItem
  {
    public int AmmoRefill { get; set; }
    public AmmoPack(int value) : base(value)
    {
      AmmoRefill = value;
    }
  }
}
