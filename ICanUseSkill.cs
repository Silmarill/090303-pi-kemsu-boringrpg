using System;

namespace BoringRPG
{
    internal interface ICanUseSkill
    {
      public void UseSkill(Skill skill, Archetype target);
    }
}