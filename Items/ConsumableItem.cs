namespace BoringRPG {
  internal abstract class ConsumableItem {
    public int Value;

    protected ConsumableItem(int value) {
      Value = value;
    }

    // Метод, который изменяет характеристики конкретного героя
    public abstract void Apply(Archetype hero);
  }
}