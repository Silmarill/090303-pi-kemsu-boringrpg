using System;

namespace BoringRPG
{
    internal class DestinyShuffle : Skill
    {

        private static Random randomParameters = new Random();

        public DestinyShuffle(string name, int mana) : base(name, mana)
        {
        }

        public override void Use(Archetype caster, Archetype target)
        {
            double[] statsCaster = { caster.Ammo, caster.CritChance, caster.Damage, caster.HP, caster.MP };
            double[] statsTarget = { target.Ammo, target.CritChance, target.Damage, target.HP, target.MP };

            /*double[] randomParamCaster = randomParameters.GetItems(parametersCaster, 3);
            double[] randomParamTarget = randomParameters.GetItems(parametersTarget, 3);

            int randomRND;*/

            int indexCaster;
            int indexTarget;
            double temp;

            for (int randomIteration = 0; randomIteration < 3; ++randomIteration)
            {
                indexCaster = randomParameters.Next(0, 5);
                indexTarget = randomParameters.Next(0, 5);

                temp = statsCaster[indexCaster];
                statsCaster[indexCaster] = statsTarget[indexTarget];
                statsTarget[indexTarget] = temp;

                /*parametersCaster[randomRND] = randomParamTarget[randomRND];
                parametersTarget[randomRND] = randomParamCaster[randomRND];*/
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