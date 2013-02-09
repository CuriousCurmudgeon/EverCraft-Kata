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

		#region Constructors

		public Character (int armorClass = 10, int hitPoints = 5, int strength = 10, int dexterity = 10,
		                  int constitution = 10, int wisdom = 10, int intelligence = 10, int charisma = 10) {
			ValidateD20Value("roll", strength);
			ValidateD20Value("roll", dexterity);
			ValidateD20Value("roll", constitution);
			ValidateD20Value("roll", wisdom);
			ValidateD20Value("roll", intelligence);
			ValidateD20Value("roll", charisma);

			this.ArmorClass = armorClass;
			this.HitPoints = hitPoints;
			this.Strength = strength;
			this.Dexterity = dexterity;
			this.Constitution = constitution;
			this.Wisdom = wisdom;
			this.Intelligence = intelligence;
			this.Charisma = charisma;
		}

		#endregion

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

		public int HitPoints { get; private set; }
		public int Strength { get; private set; }
		public int Dexterity { get; private set; }
		public int Constitution { get; private set; }
		public int Wisdom { get; private set; }
		public int Intelligence { get; private set; }
		public int Charisma { get; private set; }

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
			ValidateD20Value("roll", roll);

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

		#region Private Methods

		/// <summary>
		/// Any value from a 20-sided die must be from 1-20.
		/// </summary>
		/// <param name='param'>
		/// The name of the parameter to include in the exception message.
		/// </param>
		/// <param name='value'>
		/// The value of the D20 roll.
		/// </param>
		private static void ValidateD20Value(string param, int value) {
			if(value < 1 || value > 20) {
				throw new ArgumentException(String.Format("{0} must be from 1-20", param));
			}

		}

		#endregion
	}
}

