using System;

namespace BoringRPG
{
    internal class DestinyShuffle : Skill
    {

        private static Random randomStats = new Random();

        public DestinyShuffle(string name, int mana) : base(name, mana)
        {
        }

        public override void Use(Archetype caster, Archetype target)
        {
            double[] statsCaster = { caster.Ammo, caster.CritChance, caster.Damage, caster.HP, caster.MP };
            double[] statsTarget = { target.Ammo, target.CritChance, target.Damage, target.HP, target.MP };
            int[] indexStatCaster = { 0, 1, 2, 3, 4};
            int[] indexStatTarget = { 0, 1, 2, 3, 4};

            double temp;
            int indexCaster;
            int indexTarget;

            // Перемешивание массивов для выбора первых трёх индексов
            randomStats.Shuffle(indexStatCaster);
            randomStats.Shuffle(indexStatTarget);

            for (int randomIndex = 0; randomIndex < 3; ++randomIndex)
            {
                indexCaster = indexStatCaster[randomIndex];
                indexTarget = indexStatTarget[randomIndex];

                temp = statsCaster[indexCaster];
                statsCaster[indexCaster] = statsTarget[indexTarget];
                statsTarget[indexTarget] = temp;
            }

            caster.Ammo = (int)statsCaster[0];
            caster.CritChance = statsCaster[1];
            caster.Damage = (int)statsCaster[2];
            caster.HP = (int)statsCaster[3];
            caster.MP = (int)statsCaster[4];

            target.Ammo = (int)statsTarget[0];
            target.CritChance = statsTarget[1];
            target.Damage = (int)statsTarget[2];
            target.HP = (int)statsTarget[3];
            target.MP = (int)statsTarget[4];

        }
    }
}