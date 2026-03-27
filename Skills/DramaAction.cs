using System;

// Юмористический навык, который меняет имена персонажей
namespace BoringRPG {
  internal class DramaAction : Skill {
    private static Random random = new Random();

    public DramaAction() {
      Name = "Драма";
    }

    // Этот навык с определёнными шансами может поменять имена заклинателя и цели, затроллить цель или даже затроллить самого заклинателя
    public override string Use(Archetype caster, Archetype target) {
      string result = $"[{caster.Name}] кастует {Name}!\n";
      int roll = random.Next(1, 101);

      // Обмен именами с шансом 1%
      if (roll == 100) {
        string tempName = caster.Name;
        caster.Name = target.Name;
        target.Name = tempName;

        result += "КРИТИЧЕСКАЯ ДРАМА! Герои обменялись именами!\n";
      }
      // 30% переименование цели
      else if (roll <= 30) {
        target.Name = "Тролль-" + target.Name;
        result += $"Враг затроллен! Теперь он {target.Name}.\n";
      }

      // 30% переименование заклинателя
      else if (roll <= 60) {
        caster.Name = "Вонючка-" + caster.Name;
        result += $"Кастер попытался затроллить {target.Name}, но у него... Флип-карта??? Заклинатель теперь называется {caster.Name}.\n";
      }

      // 39% ничего не происходит
      else {
        result += $"[{caster.Name}] столкнулся с 'Техническими шоколадками'.\n";
      }

      return result;
    }
  }
}