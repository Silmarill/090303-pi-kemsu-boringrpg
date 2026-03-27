using System;

namespace BoringRPG
{
  internal abstract class ConsumableItem
  {
    public int Value;
  
    public ConsumableItem(int value)
    {
      Value = value;
    }
  }
}