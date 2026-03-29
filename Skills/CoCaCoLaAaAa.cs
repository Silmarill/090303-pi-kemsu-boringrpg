using System;

namespace BoringRPG
{
  class CoCaCoLaAaAa : Skill
  {
    Random rand = new Random();

    public override void Use(Archetype caster, Archetype target)
    {

      int drainAmount = rand.Next(10, 31);

      if (target.MP >= drainAmount)
      {
        target.MP -= drainAmount;
        caster.MP += drainAmount;
      }
      else
      {
        Console.WriteLine($" Неудача! У {target.Name} недостаточно маны");
      }
    }
  }
}