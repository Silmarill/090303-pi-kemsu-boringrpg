namespace BoringRPG {
  internal abstract class ConsumableItem {
    public int Value;

    protected ConsumableItem(int value) {
      Value = value;
    }

    // A method that will modify the characteristics of a specific hero
    public abstract void Apply(Archetype hero);
  }
}