using System;

namespace BoringRPG {
	internal class ManaDrain : Skill {
		public ManaDrain() : base("ManaDrain") {
		}

		public override void Use (Archetype caster, Archetype target) {
			int drainAmount = Math.Min(10, target.MP);
			target.MP -= drainAmount;
			caster.MP += drainAmount;

			Console.WriteLine($"{caster.Name} использует {Name} и забирает {drainAmount} MP у {target.Name}. Теперь у {caster.Name} {caster.MP} MP, у {target.Name} {target.MP} MP.");
		}
	}
}