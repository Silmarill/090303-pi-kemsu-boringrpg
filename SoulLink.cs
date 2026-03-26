namespace BoringRPG {
  // HP пользователя и цели складываются и делятся поровну
  internal class SoulLink : Skill {
    public SoulLink() { Name = "SoulLink"; }

    public override void Use(Archetype caster, Archetype target) {
      int total = caster.HP + target.HP;
      caster.HP = total / 2;
      target.HP = total / 2;
    }
  }
}
