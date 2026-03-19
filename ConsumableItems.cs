using System;

namespace BoringRPG {

  // Базовый абстрактный класс расходника
  internal abstract class ConsumableItem {
    public int Value;

    protected ConsumableItem(int value) {
      Value = value;
    }

    public abstract void Apply(Archetype target);
  }

  // Восстанавливает HP
  internal class HealthPotion : ConsumableItem {
    public HealthPotion(int value) : base(value) { }

    public override void Apply(Archetype target) {
      target.HP += Value;
    }
  }

  // Восстанавливает MP
  internal class ManaPotion : ConsumableItem {
    public ManaPotion(int value) : base(value) { }

    public override void Apply(Archetype target) {
      target.MP += Value;
    }
  }

  // Восстанавливает Ammo
  internal class AmmoPack : ConsumableItem {
    public AmmoPack(int value) : base(value) { }

    public override void Apply(Archetype target) {
      target.Ammo += Value;
    }
  }

  // БЕЗУМНЫЙ ПРЕДМЕТ: CoffeeCup — умножает CritChance на Value.
  // Используется через оператор *, потому что кофе УМНОЖАЕТ концентрацию.
  // CoffeeCup(2) удвоит шанс крита. CoffeeCup(3) утроит. Осторожно с передозом.
  internal class CoffeeCup : ConsumableItem {
    public CoffeeCup(int multiplier) : base(multiplier) { }

    public override void Apply(Archetype target) {
      target.CritChance = Math.Min(1.0, target.CritChance * Value);
    }
  }
}
