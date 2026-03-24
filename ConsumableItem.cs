using System;

namespace BoringRPG
{
  internal abstract class ConsumableItem
  {
    public int Value { get; set; }
  
    public ConsumableItem(int value)
    {
      Value = value;
    }
  }
}