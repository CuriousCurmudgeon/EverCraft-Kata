using System;

namespace EverCraft {

	public enum Alignment {
		Good,
		Evil,
		Neutral
	}

	public enum AttackResult {
		Miss,
		Hit,
		CriticalHit
	}

	public class Character {

		public Character (int armorClass = 10, int hitPoints = 5) {
			this.ArmorClass = armorClass;
			this.HitPoints = hitPoints;
		}

		#region Properties 
		public string Name { get; set; }

		/// <summary>
		/// The alignment guides the characters actions.
		/// </summary>
		/// <value>
		/// A value from the Alignment enum.
		/// </value>
		public Alignment Alignment { get; set; }

		/// <summary>
		/// Armor class is used to resist attacks from enemies.
		/// </summary>
		public int ArmorClass { get; private set; }

		/// <summary>
		/// 
		/// </summary>
		/// <value>
		/// 
		/// </value>
		public int HitPoints { get; private set; }

		#endregion

		#region Methods

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

			if(roll < 1 || roll > 20) {
				throw new ArgumentException("roll must be from 1-20");
			}

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

		public bool IsDead() {
			return this.HitPoints < 1;
		}

		#endregion
	}
}

