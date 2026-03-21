using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG {

  public abstract class ConsumableItem {
    public int value;

    public ConsumableItem(int value) {
      this.value = value;
    }
  }
}