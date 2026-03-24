using System;

namespace BoringRPG.Skills
{
  internal class CoinOfFate : Skill
  {
    private static Random random = new Random();

    public CoinOfFate() : base("CoinOfFate")
    {
    }

    public override void Use(Archetype caster, Archetype target)
    {
      int chance = random.Next(1, 11);

      if (chance <= 3)
      {
        target.HP = 0;
      }
      else if (chance <= 6)
      {
        caster.HP = 0;
      }
    }
  }
}