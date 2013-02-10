using System;

namespace EverCraft {

	public enum Alignment {
		Good,
		Evil,
		Neutral
	}

	public class Character {

		#region Constructors

		public Character (int armorClass = 10, int hitPoints = 5, int strength = 10, int dexterity = 10,
		                  int constitution = 10, int wisdom = 10, int intelligence = 10, int charisma = 10) {
			Helpers.ValidateD20Value("roll", strength);
			Helpers.ValidateD20Value("roll", dexterity);
			Helpers.ValidateD20Value("roll", constitution);
			Helpers.ValidateD20Value("roll", wisdom);
			Helpers.ValidateD20Value("roll", intelligence);
			Helpers.ValidateD20Value("roll", charisma);

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

		public int HitPoints { get; set; }
		public int Strength { get; private set; }
		public int Dexterity { get; private set; }
		public int Constitution { get; private set; }
		public int Wisdom { get; private set; }
		public int Intelligence { get; private set; }
		public int Charisma { get; private set; }

		#endregion

		#region Methods

		public bool IsDead() {
			return this.HitPoints < 1;
		}

		#endregion
	}
}

