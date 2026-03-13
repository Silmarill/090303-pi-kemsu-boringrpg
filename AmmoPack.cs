using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG
{
    internal class AmmoPack : ConsumableItem
    {
        public int Ammo { get; private set; }
        public AmmoPack(int value, int ammo) : base(value)
        {
            Ammo = ammo;
        }
    }
}
