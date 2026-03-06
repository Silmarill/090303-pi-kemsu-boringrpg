using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG {
  internal class Monk : Archetype {

    public int _hitCounter;

    public Monk(string name) : base(name, 95, 0, 0, 22, 0.12)
    {
      _hitCounter = 0;
    }

    public static Monk operator +(Monk monk, int pink)
    {
      monk.HP += pink;
      return monk;
    }
    public static Monk operator -(Monk monk, int pink)
    {
      monk.HP -= pink;
      return monk;
    }
    public static bool operator true(Monk monk)
    {
      return monk.HP > 0;
    }
    public static bool operator false(Monk monk)
    {
      return monk.HP <= 0;
    }
  }
}
