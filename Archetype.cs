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

    // Перегрузка оператора + для применение любого ConsumableItem
    public static Archetype operator +(Archetype hero, ConsumableItem item) {
      item.Apply(hero);
      return hero;
    }

    // Абстрактный метод для нанесения удара по цели
    public abstract string Hit(Archetype target);
    // Абстрактный метод для получения информации о персонаже
    public abstract string GetInfo();
  }

}
