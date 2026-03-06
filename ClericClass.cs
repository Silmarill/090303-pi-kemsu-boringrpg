using System;

namespace BoringRPG {
    internal class Cleric : Archetype {
        public Cleric(string name) : base(name, 75, 80, 0, 15, 0.05) {
            // HP=75, MP=80, Ammo=0, Damage=15, CritChance=0.05 (5%)
        }
        public static Cleric operator +(Cleric cleric, int amount)
        {
            cleric.Hp += amount;
            if (cleric.Hp > 75) // MaxHp = 75
            {
                cleric.Hp = 75;
            } 
            return cleric;
        }
        public static Cleric operator -(Cleric cleric, int amount)
        {
            cleric.Hp -= amount;
            if (cleric.Hp < 0) // MinHP = 0
            {
                cleric.Hp = 0;
            }
            return cleric;
        }
         public override void Hit(Character target)
        {
            Random rand = new Random();
            int damage = 15;
           
            if (Mp >= 10)
            {
                Mp -= 10;
                
                bool isCritical = rand.NextDouble() < 0.05;
                int finalDamage = damage;
                
                if (isCritical)
                {
                    finalDamage *= 2;
                    Console.WriteLine($"{Name} наносит КРИТИЧЕСКИЙ удар!");
                }
                
                int targetHpBefore = target.Hp;
                
                target.Hp -= finalDamage;
                
                Console.WriteLine($"{Name} атакует {target.Name} и наносит {finalDamage} урона!");
                
                if (targetHpBefore > 0 && target.Hp <= 0)
                {
                    Hp += 10;
                    if (Hp > 75)
                        Hp = 75;
                        
                    Console.WriteLine($"{Name} восстанавливает 10 HP, так как цель погибла!");
                }
            }
            else
            {
                Console.WriteLine($"{Name} пытается атаковать, но не хватает MP! Урон 0.");
            }
        }
        public override string GetInfo()
        {
            return $"Cleric: {Name}\n" +
                   $"HP: {Hp}/75\n" +
                   $"MP: {Mp}/80\n" +
                   $"Урон: 15\n" +
                   $"Шанс крита: 5%\n" +
                   $"Особая способность: Тратит 10 MP, наносит Damage. Если цель умирает от этой атаки, герой восстанавливает 10 HP.";
        }
    }
}