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
            double[] parametersCaster = { caster.Ammo, caster.CritChance, caster.Damage, caster.HP, caster.MP };
            double[] parametersTarget = { target.Ammo, target.CritChance, target.Damage, target.HP, target.MP };

            double[] randomParamCaster = randomParameters.GetItems(parametersCaster, 3);
            double[] randomParamTarget = randomParameters.GetItems(parametersTarget, 3);

            int randomRND;

            for (int randomIteration = 0; randomIteration < 3; ++randomIteration)
            {
                randomRND = randomParameters.Next(0, 3);

                parametersCaster[randomRND] = randomParamTarget[randomRND];
                parametersTarget[randomRND] = randomParamCaster[randomRND];
            }

            Console.WriteLine(string.Join(", ", parametersCaster));
            Console.WriteLine(string.Join(", ", parametersTarget));

            caster.Ammo = (int)parametersCaster[0];
            caster.CritChance = parametersCaster[1];
            caster.Damage = (int)parametersCaster[2];
            caster.HP = (int)parametersCaster[3];
            caster.MP = (int)parametersCaster[4];

            target.Ammo = (int)parametersTarget[0];
            target.CritChance = parametersTarget[1];
            target.Damage = (int)parametersTarget[2];
            target.HP = (int)parametersTarget[3];
            target.MP = (int)parametersTarget[4];

        }
    }
}