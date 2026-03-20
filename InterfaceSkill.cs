using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG
{
  interface ISkill
  {
    void UseSkill(Skill skill, Archetype target);
  }

  abstract class Skill
  {
    public string Name;
    public abstract void Use(Archetype caster, Archetype target);
  }

  class SoulLink : Skill
  {
    public SoulLink() 
    {
      Name = "SoulLink";
    }

    public override void Use(Archetype caster, Archetype target)
    {
      int generalHealth;
      int healthDivider;

      healthDivider = 2;

      Console.WriteLine($"{caster.Name} using {Name} in {target.Name}!\n");

      generalHealth = caster.HP + target.HP;

      caster.HP = generalHealth / healthDivider;
      target.HP = generalHealth / healthDivider;

      Console.WriteLine($"health {caster.Name} = {caster.HP},health {target.Name} = {caster.HP}!\n");
    }
  }

  class CoinOfFate : Skill
  {
    private static Random random = new Random();

    public CoinOfFate()
    {
      Name = "CoinOfFate";
    }

    public override void Use(Archetype caster, Archetype target)
    {
      int ChangeRandom;

      ChangeRandom = random.Next(1, 11);

      Console.WriteLine($"{caster.Name} is using {Name} on {target.Name}!\n");

      if (ChangeRandom <= 3)
      {
        caster.HP = 0;
        Console.WriteLine($"{caster.Name} lost his health!\n");
      }

      else if (ChangeRandom > 3 && ChangeRandom < 7)
      {
        target.HP = 0;
        Console.WriteLine($"{target.Name} lost his health!\n");
      }

      else
      {
        Console.WriteLine("nothing happened!\n");
      }
    }
  }

  class ComplimentEnemy : Skill
  {
    public ComplimentEnemy()
    {
      Name = "ComplimentEnemy";
    }

    public override void Use(Archetype caster, Archetype target)
    {
      int damageMultiplier;
      int CritChangeMultiplier;

      CritChangeMultiplier = 2;
      damageMultiplier = 3;

      target.Damage *= damageMultiplier;
      target.CritChance *= CritChangeMultiplier;

      Console.WriteLine($"{target.Name} receives an improvement to critical chance and damage\n");
      Console.WriteLine($"Damage {target.Name} = {target.Damage}, critical chance = {target.CritChance}!\n");
    }
  }

}

