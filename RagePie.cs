using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG
{
  internal class RagePie : ConsumableItem
  {
    public int IncreaseAll { get; set; }
    public RagePie(int value) : base(value)
    {
      IncreaseAll = value;
    }
  }
}
