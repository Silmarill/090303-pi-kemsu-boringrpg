using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG
{
    internal abstract class ConsumableItem
    {
      public int Value { get; private set; }
    
      protected ConsumableItem(int value)
      {
            Value = value;
      }
    }
}
