using BoringRPG;

internal class EnergyDrink: ConsumableItem {
  public EnergyDrink(int value) : base(value) { }
  public static Warrior operator +(Warrior hero, EnergyDrink energyDrink) {
    if (hero.MP >= energyDrink.Value) {
      hero.MP -= energyDrink.Value / 2;
    }
    else {
      int remainingCost;
      remainingCost = energyDrink.Value - hero.MP;
      hero.MP = 0;
      hero.HP -= remainingCost;
    }
    hero.Damage += energyDrink.Value;
    return hero;
  }
  public static DummyClass operator +(DummyClass hero, EnergyDrink energyDrink) {
    if (hero.MP >= energyDrink.Value) {
      hero.MP -= energyDrink.Value / 2;
    }
    else {
      int remainingCost;
      remainingCost = energyDrink.Value - hero.MP;
      hero.MP = 0;
      hero.HP -= remainingCost;
    }
    hero.Damage += energyDrink.Value;
    return hero;
  }
}
