using System;

namespace BoringRPG
{
  internal class SoulLink : Skill
  {
    public SoulLink() : base("SoulLink") { }

    public override void Use(Archetype caster, Archetype target)
    {
      int totalHP;
      totalHP = caster.HP + target.HP;
      caster.HP = totalHP / 2;
      target.HP = totalHP / 2;
      Console.WriteLine($"{caster.Name} и {target.Name} связали души. HP стало {totalHP / 2}");
    }
  }
}
