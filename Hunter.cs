using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG
{
    internal class Hunter : Archetype
    {

        protected Hunter(string name, int hp, int mp, int ammo, int dmg, double crit)
            : base("Divad", 85, 20, 15, 25, 0.2)
        {
            public private int operator -(int hitPoint, int dephens, int damage)
        {

            if (HP > 0)
            {
                hitPoint -= (Damage - Ammo);
                if (HP < 0)
                {
                    return hitPoint = 0;
                }
            }
            return hitPoint;

        }
    }

}
}
