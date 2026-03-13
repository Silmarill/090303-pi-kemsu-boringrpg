using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG
{
    internal class ManaPotion : ConsumableItem
    {
        public int ManaRegen { get; private set; }
        public ManaPotion(int value, int manaRegen) : base(value)
        {
            ManaRegen = manaRegen;
        }
    }
}
