using System;

// A humorous skill that changes character names
namespace BoringRPG {
  internal class DramaAction : Skill {
    private static Random random = new Random();

    public DramaAction() {
      Name = "Drama Action";
    }

    public override string Use(Archetype caster, Archetype target) {
      string result = $"[{caster.Name}] кастует {Name}!\n";
      int roll = random.Next(1, 101);

      // Swap names with a 1% chance
      if (roll == 100) {
        string tempName = caster.Name;
        caster.Name = target.Name;
        target.Name = tempName;

        result += "КРИТИЧЕСКАЯ ДРАМА! Герои обменялись именами!";
      }
      // 30% rename target
      else if (roll <= 30) {
        target.Name = "Trolled " + target.Name;
        result += $"Враг затроллен! Теперь он {target.Name}.";
      }

      // 30% rename caster
      else if (roll <= 60) {
        caster.Name = "Bruh " + caster.Name;
        result += $"Caster tried to troll {target.Name}, but the target had a... Flip-card??? The caster is now named {caster.Name}.";
      }

      // 39% Show message
      else {
        result += $"[{caster.Name}] столкнулся с 'Техническими шоколадками'";
      }

      return result;
    }
  }
}