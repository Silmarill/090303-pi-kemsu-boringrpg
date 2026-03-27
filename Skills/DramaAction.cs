using System;

namespace BoringRPG {
	internal class DramaAction : Skill {
		private static Random random = new Random();

		public DramaAction() : base("DramaAction") {
		}

		public override void Use(Archetype caster, Archetype target) {
			int chance = random.Next(100);

			if (chance < 30) {
				target.Name = "Побеждённый " + target.Name;
			} else if (chance < 60) {
				caster.Name = "Легендарный " + caster.Name;
			} else {
			}
		}
	}
}