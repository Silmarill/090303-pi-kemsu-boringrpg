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
      int halfHP;
      halfHP = totalHP / 2;

      Console.WriteLine(
        $"\n{caster.Name} применяет навык {Name}!" +
        $"\nСвязывает свою жизнь с {target.Name}!" +
        $"\nОбщее HP: {totalHP}, каждый получает по {halfHP}"
        );

      caster.HP = halfHP;
      target.HP = halfHP;
    }
  }
}