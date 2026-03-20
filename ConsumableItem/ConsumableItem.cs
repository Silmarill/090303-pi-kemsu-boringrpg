using System;

namespace BoringRPG {
  public abstract class ConsumableItem {
    public int Value { get; protected set; }
    public string Name { get; protected set; }

    protected ConsumableItem(string name, int value) {
      Name = name;
      Value = value;
    }

    public abstract string GetDescription();
  }
}