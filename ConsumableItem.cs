using BoringRPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG
{
  public abstract class ConsumableItem
  {
    private static Random random = new Random();
    public int Value;

    public ConsumableItem(int value)
    {
      Value = value;
    }
    public abstract void Use(Nekromaster necromancer);
  }
}

public class HealthPotion : ConsumableItem
{
  public HealthPotion(int value) : base(value)
  {
    public override void Use(Nekromaster necromancer)
    {
    Nekromaster.hp += Value;
    } 
  }
}