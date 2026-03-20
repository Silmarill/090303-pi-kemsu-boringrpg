namespace BoringRPG
{
    internal abstract class Skill
    {
        public string Name { get; set; } // Название навыка

        public abstract void Use(Archetype caster, Archetype target);
    }
}