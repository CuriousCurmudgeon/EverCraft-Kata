using System;

namespace EverCraft {

	public enum AttackResult {
		Miss,
		Hit,
		CriticalHit
	}

	/// <summary>
	/// Handles combat between characters.
	/// </summary>
	public class CombatCalculator {

		#region Instance Variables

		/// <summary>
		/// Character abilities are modified according to this table.
		/// </summary>
		private int[] modifierTable = new int[20] {-5, -4, -4, -3, -3,
		                               			   -2, -2, -1, -1,  0,
		                                            0, +1, +1, +2, +2,
			                                       +3, +3, +4, +4, +5};

		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="EverCraft.CombatCalculator"/> class.
		/// </summary>
		/// <param name='attacker'>
		/// The attacking character.
		/// </param>
		public CombatCalculator (Character attacker) {
			this.Attacker = attacker;
		}

		#region Properties

		public Character Attacker { get; private set; }

		#endregion

		/// <summary>
		/// Attack another character. Hits if our role is greater than the
		/// opponent's armor class.
		/// </summary>
		/// <param name='opponent'>Whom we are attacking.</param>
		/// <param name='roll'>An int from 1-20.</param>
		public AttackResult Attack(Character opponent, int roll) {
			if(opponent == null) {
				throw new ArgumentException("opponent cannot be null");
			}
			Helpers.ValidateD20Value("roll", roll);

			var result = AttackResult.Miss;

			if(roll == 20) {
				result = AttackResult.CriticalHit;
				opponent.HitPoints -= 2;
			}
			else if(roll >= opponent.ArmorClass) {
				result = AttackResult.Hit;
				opponent.HitPoints -= 1;
			}
			return result;
		}

	}
}

