namespace BoringRPG
{
  public abstract class Skill
  {
    public string Name;

    public Skill(string name)
    {
      Name = name;
    }
    public abstract void Use(Archetype caster, Archetype target);
  }
}
