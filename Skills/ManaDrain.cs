using System;

namespace BoringRPG {
	internal class ManaDrain : Skill {
		public ManaDrain() : base("ManaDrain") {
		}

		public override void Use(Archetype caster, Archetype target) {
			int drainAmount = Math.Min(10, target.MP);
			target.MP -= drainAmount;
			caster.MP += drainAmount;
		}
	}
}