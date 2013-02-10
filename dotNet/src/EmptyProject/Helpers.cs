using System;

namespace EverCraft {
	public static class Helpers {

		/// <summary>
		/// Any value from a 20-sided die must be from 1-20.
		/// </summary>
		/// <param name='param'>
		/// The name of the parameter to include in the exception message.
		/// </param>
		/// <param name='value'>
		/// The value of the D20 roll.
		/// </param>
		public static void ValidateD20Value(string param, int value) {
			if(value < 1 || value > 20) {
				throw new ArgumentException(String.Format("{0} must be from 1-20", param));
			}

		}

	}
}

