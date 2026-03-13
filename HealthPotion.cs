using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG
{
    internal class HealthPotion : ConsumableItem
    {
        public int Heal { get; private set; }
        public HealthPotion(int value, int heal) : base(value)
        {
            Heal = heal;
        }
    }
}
