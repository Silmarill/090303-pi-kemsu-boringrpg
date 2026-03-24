using System;

namespace BoringRPG {
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

    public override void Use(Archetype caster, Archetype target)
    {
      int randomValue;

      randomValue = RandomGenerator.Next(MinRandomValue, MaxRandomValue);

      Console.WriteLine($"{caster.Name} использует {Name}!");

      if (randomValue <= RenameTargetChance)
      {
        string oldName;

        oldName = target.Name;
        target.Name = DefeatedLegendary;
        Console.WriteLine($"Драматичный поворот! {oldName} теперь называется '{target.Name}'!");
      }
      else if (randomValue <= RenameTargetChance + RenameSelfChance)
      {
        string oldName;

        oldName = caster.Name;
        caster.Name = LegendaryDefeated;
        Console.WriteLine($"Драматичный поворот! {oldName} теперь называется '{caster.Name}'!");
      }
      else
      {
        Console.WriteLine($"{caster.Name} дарит розу {target.Name}. Как восхетительно!");
      }
    }
  }
}