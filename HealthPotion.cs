using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoringRPG {
  public class HealthPotion : ConsumableItem {
    private const int MAX_HP = 140; 
    private const int HEAL_AMOUNT = 50; 

    public HealthPotion() : base(HEAL_AMOUNT) { }

    public HealthPotion(int value) : base(value) {
    }

    public override string GetDescription() {
      return $"Зелье здоровья (+{HEAL_AMOUNT} HP)";
    }

    public int ApplyTo(int currentHP) {
      int newHP = currentHP + HEAL_AMOUNT;

      if (newHP > MAX_HP) {
        Console.WriteLine($" Превышение максимума! HP будет установлено на {MAX_HP}");
        return MAX_HP;
      }

      return newHP;
    }
  }
}