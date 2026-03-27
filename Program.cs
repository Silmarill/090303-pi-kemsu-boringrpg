using System;

namespace BoringRPG{
    internal class Program{
        static void Main(string[] args){
            int beforeHP, damage;
            int beforeMP;

            // Создаем двух друидов
            Druid merlin = new Druid("Мерлин");
            Druid morrigan = new Druid("Морриган");

            Console.WriteLine($"НАЧАЛО. Исходное состояние: \n" +
            $"======================\n" +
            $"{merlin.GetInfo()}\n" +
            $"{morrigan.GetInfo()}\n");

            // ДЕМОНСТРАЦИЯ ПРЕДМЕТОВ
            Console.WriteLine($"\n=== ДЕМОНСТРАЦИЯ ПРЕДМЕТОВ ===\n");

            Console.WriteLine($"{merlin.Name} использует зелье здоровья.");
            HealthPotion healthPotion = new HealthPotion(15);
            beforeHP = merlin.HP;
            merlin += healthPotion;
            Console.WriteLine();

            Console.WriteLine($"{merlin.Name} использует зелье маны.");
            ManaPotion manaPotion = new ManaPotion(20);
            beforeMP = merlin.MP;
            merlin += manaPotion;
            Console.WriteLine();

            Console.WriteLine($"{merlin.Name} использует зелье природы.");
            NaturePotion naturePotion = new NaturePotion(5);
            merlin += naturePotion;
            Console.WriteLine();

            Console.WriteLine($"{merlin.Name} съедает лунную ягоду.");
            MoonBerry berry = new MoonBerry(15);
            merlin += berry;
            Console.WriteLine();

            Console.WriteLine($"Состояние после предметов:");
            Console.WriteLine(merlin.GetInfo());
            Console.WriteLine();

            // ДЕМОНСТРАЦИЯ НАВЫКОВ
            Console.WriteLine($"=== ДЕМОНСТРАЦИЯ НАВЫКОВ ===\n");

            // Навык 1: SoulLink
            Skill soulLink = new SoulLink();
            merlin.UseSkill(soulLink, morrigan);
            Console.WriteLine($"После SoulLink:");
            Console.WriteLine(morrigan.GetInfo());
            Console.WriteLine(merlin.GetInfo());
            Console.WriteLine();

            // Навык 2: ManaDrain
            Skill manaDrain = new ManaDrain();
            merlin.UseSkill(manaDrain, morrigan);
            Console.WriteLine($"После ManaDrain:");
            Console.WriteLine(morrigan.GetInfo());
            Console.WriteLine(merlin.GetInfo());
            Console.WriteLine();

            // БИТВА
            Console.WriteLine($"=== БИТВА ===\n");
            Console.WriteLine($"{merlin.Name} атакует {morrigan.Name}!");

            beforeHP = morrigan.HP;
            merlin.Hit(morrigan);
            damage = beforeHP - morrigan.HP;

            string critText = merlin.LastHitWasCrit ? " – КРИТИЧЕСКИЙ УДАР!" : "";
            Console.WriteLine($"Нанесено {damage} урона{critText}\n");

            // Навык 3: DramaAction
            Skill drama = new DramaAction();
            morrigan.UseSkill(drama, merlin);
            Console.WriteLine($"После DramaAction:");
            Console.WriteLine(morrigan.GetInfo());
            Console.WriteLine(merlin.GetInfo());
            Console.WriteLine();

            // ИТОГОВОЕ СОСТОЯНИЕ
            Console.WriteLine("ИТОГОВОЕ СОСТОЯНИЕ:");
            Console.WriteLine("==========================");
            Console.WriteLine(morrigan.GetInfo());
            Console.WriteLine(merlin.GetInfo());

            Console.ReadKey();
        }
    }
}