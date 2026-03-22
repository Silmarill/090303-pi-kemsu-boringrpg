namespace BoringRPG {
  internal abstract class Archetype {

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

    // Overload the + operator for applying any ConsumableItem
    public static Archetype operator +(Archetype hero, ConsumableItem item) {
      item.Apply(hero);
      return hero;
    }

    /*
    Insane Item: Coffee. Multiplies critical hit chance, but drains HP
    The * operator is used here, as this represents an amplification rather than a simple addition
    */
    public static Archetype operator *(Archetype hero, double caffeineLevel) {
      hero.CritChance *= caffeineLevel;
      hero.HP -= 10;
      return hero;
    }

    public abstract void Hit(Archetype target);
    public abstract string GetInfo();
  }

}
