using System;

namespace EverCraft {

	public enum Alignment {
		Good,
		Evil,
		Neutral
	}

	public class Character {

		public Character (int armor_class = 10, int hit_points = 5) {
			this.ArmorClass = armor_class;
			this.HitPoints = hit_points;
		}

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
	}
}

