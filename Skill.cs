using System;
using BoringRPG.Models;

namespace BoringRPG.Skills {
  public abstract class Skill {
    public string Name;
    public abstract string Use(Archetype caster, Archetype target);
  }
}