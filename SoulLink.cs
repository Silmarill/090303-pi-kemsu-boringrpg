using System;

namespace BoringRPG
{
  class SoulLink : Skill
  {
    public override void Use(Archetype dungeonMaster, Archetype artur)
    {
      int totalHP = dungeonMaster.HP + artur.HP;
      dungeonMaster.HP = totalHP / 2;
      artur.HP = totalHP / 2;
    }
  }
}