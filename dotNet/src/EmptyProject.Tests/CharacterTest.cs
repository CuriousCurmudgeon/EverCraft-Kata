using System;
using NUnit.Framework;
using Should.Extensions.AssertExtensions;

namespace EverCraft.Tests {
	[TestFixture()]
	public class CharacterTest {

		private Character character;

		#region Setup/Teardown

		[SetUp]
		public void Setup() {
			character = new Character();
		}

		#endregion

		[Test()]
		public void can_set_and_read_name () {
			character = new Character { Name = "Test" };
			character.Name.ShouldEqual("Test");
		}

		[Test]
		public void can_get_and_set_alignment() {
			character = new Character { Alignment = Alignment.Evil };
			character.Alignment.ShouldEqual(Alignment.Evil);
		}

		#region ArmorClass

		[Test]
		public void ArmorClass_defaults_to_10() {
			character.ArmorClass.ShouldEqual(10);
		}

		[Test]
		public void ArmorClass_can_be_initialized_to_a_different_value() {
			character = new Character(armorClass: 5);
			character.ArmorClass.ShouldEqual(5);
		}

		#endregion

		#region HitPoints

		[Test]
		public void HitPoints_defaults_to_5() {
			character.HitPoints.ShouldEqual(5);
		}

		[Test]
		public void HitPoints_can_be_initialized_to_a_different_value() {
			character = new Character(hitPoints: 10);
			character.HitPoints.ShouldEqual(10);
		}

		#endregion

		#region Attack

		[Test]
		public void Attack_hits_if_base_attack_equals_armor_class() {
			var opponent = new Character(armorClass: 5);
			character.Attack(opponent, 5).ShouldEqual(AttackResult.Hit);
		}

		[Test]
		public void Attack_misses_if_base_attack_is_less_than_armor_class() {
			var opponent = new Character(armorClass: 5);
			character.Attack(opponent, 4).ShouldEqual(AttackResult.Miss);
		}

		[Test]
		public void Attack_hits_if_base_attack_is_greater_than_armor_class() {
			var opponent = new Character(armorClass: 5);
			character.Attack(opponent, 6).ShouldEqual(AttackResult.Hit);
		}

		[Test]
		[ExpectedException(typeof(ArgumentException))]
		public void Attack_throws_exception_if_opponent_is_null() {
			character.Attack(null, 6);
		}

		[Test]
		[ExpectedException(typeof(ArgumentException))]
		public void Attack_throws_exception_if_roll_is_less_than_1() {
			var opponent = new Character();
			character.Attack(opponent, 0);
		}

		[Test]
		[ExpectedException(typeof(ArgumentException))]
		public void Attack_throws_exception_if_roll_is_greater_than_20() {
			var opponent = new Character();
			character.Attack(opponent, 21);
		}

		#endregion
	}
}

