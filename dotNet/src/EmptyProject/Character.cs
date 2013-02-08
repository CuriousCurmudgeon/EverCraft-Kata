using System;

namespace EverCraft {

	public enum Alignment {
		Good,
		Evil,
		Neutral
	}

	public class Character {

		public Character () {
		}

		public string Name { get; set; }
		public Alignment Alignment { get; set; }
	}
}

