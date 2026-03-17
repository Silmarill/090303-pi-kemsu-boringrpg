using System;

namespace BoringRPG
{
  internal abstract class ConsumableItem
  {
    public int Value { get; protected set; }

    protected ConsumableItem(int value)
    {
      Value = value;
    }

    public abstract void ApplyEffect(Archetype target);
  }

  internal class HealthPotion : ConsumableItem
  {
    public HealthPotion(int value) : base(value) { }

    public override void ApplyEffect(Archetype target)
    {
      target.HP += Value;
      Console.WriteLine($"{target.Name} восстановил {Value} HP!");
    }
  }

  internal class ManaPotion : ConsumableItem
  {
    public ManaPotion(int value) : base(value) 
    { 
    }

    public override void ApplyEffect(Archetype target)
    {
      target.MP += Value;
      Console.WriteLine($"{target.Name} восстановил {Value} MP!");
    }
  }

  internal class AmmoPack : ConsumableItem
  {
    public AmmoPack(int value) : base(value) { }

    public override void ApplyEffect(Archetype target)
    {
      target.Ammo += Value;
      Console.WriteLine($"{target.Name} получил {Value} патронов!");
    }
  }

  internal class EnergyDrink : ConsumableItem
  {
    public EnergyDrink(int value) : base(value) { }

    public override void ApplyEffect(Archetype target)
    {
      target.Damage += Value / 2;
      target.HP -= Value / 3;

      Console.WriteLine($"⚡ {target.Name} выпил энергетик! Урон увеличен на {Value / 2}, но потеряно {Value / 3} HP!");
    }

    public static EnergyDrink operator ++(EnergyDrink drink)
    {
      drink.Value *= 2;
      Console.WriteLine($"☢️ Энергетик стал еще крепче! Теперь его величина {drink.Value}");
      return drink;
    }
  }

  internal static class ConsumableHelper
  {
    public static void UseItem(this Archetype character, ConsumableItem item)
    {
      item.ApplyEffect(character);
    }
  }

  internal class CharacterWithItems
  {
    public Archetype Character { get; set; }

    public CharacterWithItems(Archetype character)
    {
      Character = character;
    }

    public static CharacterWithItems operator +(CharacterWithItems wrapper, ConsumableItem item)
    {
      item.ApplyEffect(wrapper.Character);
      return wrapper;
    }
  }
}