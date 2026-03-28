using System;
using BoringRPG.Skills.Interfaces;

namespace BoringRPG {
  public abstract class Skill {
    public string Name;
    public int ManaCost;

    public Skill(string name, int manaCost)
    {
      Name = name;
      ManaCost = manaCost;
    }

    public abstract string Use(Archetype user, Archetype target);

    public bool Chance(int percent)
    {
      Random rand = new Random();
      return rand.Next(100) < percent;
    }
  }
}