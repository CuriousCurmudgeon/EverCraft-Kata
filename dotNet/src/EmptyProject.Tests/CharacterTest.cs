using System;
using NUnit.Framework;
using Should.Extensions.AssertExtensions;

namespace EverCraft.Tests {
	[TestFixture()]
	public class CharacterTest {

		[Test()]
		public void can_set_and_read_name () {
			var character = new Character { Name = "Test" };
			character.Name.ShouldEqual("Test");
		}

		[Test]
		public void can_get_and_set_alignment() {
			var character = new Character { Alignment = Alignment.Evil };
			character.Alignment.ShouldEqual(Alignment.Evil);
		}

		#region ArmorClass

		[Test]
		public void ArmorClass_defaults_to_10() {
			var character = new Character();
			character.ArmorClass.ShouldEqual(10);
		}

		[Test]
		public void ArmorClass_can_be_initialized_to_a_different_value() {
			var character = new Character(armor_class: 5);
			character.ArmorClass.ShouldEqual(5);
		}

		#endregion

		#region HitPoints

		[Test]
		public void HitPoints_defaults_to_5() {
			var character = new Character();
			character.HitPoints.ShouldEqual(5);
		}

		[Test]
		public void HitPoints_can_be_initialized_to_a_different_value() {
			var character = new Character(hit_points: 10);
			character.HitPoints.ShouldEqual(10);
		}

		#endregion
	}
}

