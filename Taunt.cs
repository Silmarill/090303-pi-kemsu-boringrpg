namespace BoringRPG {
  // CritChance противника уменьшается на 50% на один ход.
  // Полноценный откат требовал бы системы ходов — здесь эффект
  // применяется сразу, восстановление нужно вызвать вручную через Restore().
  internal class Taunt : Skill {
    private double savedCrit;

    public Taunt() { Name = "Taunt"; }

    public override void Use(Archetype caster, Archetype target) {
      savedCrit = target.CritChance;
      target.CritChance *= 0.5;
    }

    // Вызвать после того, как противник походил — восстанавливает крит-шанс
    public void Restore(Archetype target) {
      target.CritChance = savedCrit;
    }
  }
}
