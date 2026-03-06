using System;

namespace BoringRPG {
  internal class Druid : Archetype {

    private static Random random = new Random();
    public bool LastHitWasCrit;

    public Druid(string name) : base(name, 90, 60, 0, 20, 0.10)
    {
    }

    public static Druid operator +(Druid druid, int amount)
    {
      druid.HP += amount;
      return druid;
    }

    public static Druid operator -(Druid druid, int amount)
    {
      druid.HP -= amount;
      return druid;
    }

    public static bool operator true(Druid druid)
    {
      return druid.HP > 0;
    }

    public static bool operator false(Druid druid)
    {
      return druid.HP <= 0;
    }

    public override void Hit(Archetype target)
    {

    }

  
