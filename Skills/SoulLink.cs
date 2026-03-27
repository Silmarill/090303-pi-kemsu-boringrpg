using System;

namespace BoringRPG.Skills {
  internal class SoulLink : Skill {
    public SoulLink() {
      Name = "Связь душ";
    }

    // Этот навык связывает жизненные силы заклинателя и цели, уравняя их Здоровья
    public override string Use(Archetype caster, Archetype target) {
      string result = $"\n[{caster.Name}] использует {Name} на [{target.Name}]!\n";
      int totalHP;

      // Рассчёт среднего Здоровья и присвоение его для заклинателя и цели
      totalHP = caster.HP + target.HP;

      // Если Здоровье у любого из героев равен нулю, Связь душ не сработает
      caster.HP = totalHP / 2;
      target.HP = totalHP / 2;

      result += $"Жизненные силы уравнялись! Теперь у обоих героев по {caster.HP} Здоровья.\n";

      return result;
    }
  }
}
