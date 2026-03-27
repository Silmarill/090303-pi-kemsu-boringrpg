using System;

namespace BoringRPG {
  internal class CoinOfFate : Skill {

    // Используется только для генерации случайного числа при использовании навыка
    private static Random random = new Random();

    public CoinOfFate() {
      // Очень креативное название :D
      Name = "Монета судьбы";
    }

    // Логика навыка
    public override string Use(Archetype caster, Archetype target) {
      string result = $"\n[{caster.Name}] подкидывает {Name}...";
      int roll = random.Next(1, 101);

      // 30% - Враг умирает
      if (roll <= 30) {
        target.HP = 0;
        result += $"Решка! [{target.Name}] мгновенно умирает!";
      }
      // 60% - Заклинатель умирает
      else if (roll <= 60) {
        caster.HP = 0;
        result += $"Орёл! [{caster.Name}] мгновенно умирает!";
      }
      // 30% - Ничего не происходит (на самом деле, это выглядит очень неожиданно)
      else {
        result += $"{Name} упала на ребро. Ничего не случилось, но все удивлены...";
      }

      return result;
    }
  }
}