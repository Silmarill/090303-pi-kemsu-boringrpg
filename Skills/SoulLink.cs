using System;

namespace BoringRPG {
	class SoulLink : Skill {
		public SoulLink() : base("SoulLink") {
		}

		public override void Use (Archetype caster, Archetype target) {
			int totalHP = caster.HP + target.HP;
			int half = totalHP / 2;
			int remainder = totalHP % 2;

			caster.HP = half;
			target.HP = half + remainder; 

			Console.WriteLine($"{caster.Name} использует {Name}: Теперь у {caster.Name} {caster.HP} HP, у {target.Name} {target.HP} HP.");
		}
	}
}