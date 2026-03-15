using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG
{
    internal class HealthPotion : ConsumableItem
    {
        public int Heal { get; set; }
        public HealthPotion(int value) : base(value)
        {
            Heal = value;
        }
    }
}
