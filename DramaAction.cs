using System;
using BoringRPG.Models;

namespace BoringRPG.Skills {
  public class DramaAction : Skill {
    public int RenameTargetChance;
    public int RenameSelfChance;
    public int GiveRoseChance;
    public int MaxRandomValue;
    public int MinRandomValue;

    public string DefeatedLegendary;
    public string LegendaryDefeated;

    public Random RandomGenerator;

    public DramaAction()
    {
      Name = "Drama Action";
      RenameTargetChance = 30;
      RenameSelfChance = 30;
      GiveRoseChance = 40;
      MaxRandomValue = 101;
      MinRandomValue = 1;
      DefeatedLegendary = "Побеждённый / Легендарный";
      LegendaryDefeated = "Легендарный / Побежденный";
      RandomGenerator = new Random();
    }

    public override string Use(Archetype caster, Archetype target)
    {
      int randomValue;
      string result;

      randomValue = RandomGenerator.Next(MinRandomValue, MaxRandomValue);

      if (randomValue <= RenameTargetChance)
      {
        string oldName;

        oldName = target.Name;
        target.Name = DefeatedLegendary;
        result = $"{caster.Name} использует {Name}!\nДраматичный поворот! {oldName} теперь называется '{target.Name}'!";
      }
      else if (randomValue <= RenameTargetChance + RenameSelfChance)
      {
        string oldName;

        oldName = caster.Name;
        caster.Name = LegendaryDefeated;
        result = $"{caster.Name} использует {Name}!\nДраматичный поворот! {oldName} теперь называется '{caster.Name}'!";
      }
      else
      {
        result = $"{caster.Name} использует {Name}!\n{caster.Name} дарит розу {target.Name}. Как мило!";
      }

      return result;
    }
  }
}