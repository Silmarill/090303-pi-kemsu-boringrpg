using System;
using BoringRPG.Interfaces;

namespace BoringRPG {
  public abstract class Skill {
    public string Name;
    public int ManaCost;

    public Skill(string name, int manaCost)
    {
      Name = name;
      ManaCost = manaCost;
    }

    public abstract void Use(ICanUseSkill user, ICanUseSkill target);

    public bool Chance(int percent)
    {
      Random rand = new Random();
      return rand.Next(100) < percent;
    }
  }
}