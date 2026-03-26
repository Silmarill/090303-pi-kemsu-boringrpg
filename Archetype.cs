using System;
using System.Collections.Generic;

namespace BoringRPG {
  internal abstract class Archetype : ICanUseSkill {

    public string Name;
    public int HP;
    public int MP;
    public int Ammo;
    public int Damage;
    public double CritChance;

    protected Archetype(string name, int hp, int mp, int ammo, int dmg, double crit) {
      Name = name;
      HP = hp;
      MP = mp;
      Ammo = ammo;
      Damage = dmg;
      CritChance = crit;
    }

    public abstract void Hit(Archetype target);
    public abstract string GetInfo();

    // Реализация ICanUseSkill — все наследники получают автоматически
    public void UseSkill(Skill skill, Archetype target) {
      skill.Use(this, target);
    }

    // Расходники: hero += new HealthPotion(50)
    public static Archetype operator +(Archetype hero, ConsumableItem item) {
      item.Apply(hero);
      return hero;
    }

    // Безумный расходник: hero *= new CoffeeCup(3)
    public static Archetype operator *(Archetype hero, CoffeeCup cup) {
      cup.Apply(hero);
      return hero;
    }
  }
}
