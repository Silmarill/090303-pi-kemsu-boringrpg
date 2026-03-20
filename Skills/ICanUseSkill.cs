using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG.Skills
{
    interface ICanUseSkill
    {
        void UseSkill(Skill skill, Archetype target);
    }
}
