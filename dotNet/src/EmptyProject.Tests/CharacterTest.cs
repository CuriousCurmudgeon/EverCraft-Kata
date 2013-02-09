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

		#region Strength

		[Test]
		public void Strength_defaults_to_10() {
			character.Strength.ShouldEqual(10);
		}

		[Test]
		public void Strength_can_be_initialized_to_a_different_value() {
			character = new Character(strength: 5);
			character.Strength.ShouldEqual(5);
		}

		[Test]
		[ExpectedException(typeof(ArgumentException))]
		public void Strength_cannot_be_less_than_1() {
			new Character(strength: 0);
		}

		[Test]
		[ExpectedException(typeof(ArgumentException))]
		public void Strength_cannot_be_greater_than_20() {
			new Character(strength: 21);
		}

		#endregion

		#region Dexterity

		[Test]
		public void Dexterity_defaults_to_10() {
			character.Dexterity.ShouldEqual(10);
		}

		[Test]
		public void Dexterity_can_be_initialized_to_a_different_value() {
			character = new Character(dexterity: 5);
			character.Dexterity.ShouldEqual(5);
		}

		[Test]
		[ExpectedException(typeof(ArgumentException))]
		public void Dexterity_cannot_be_less_than_1() {
			new Character(dexterity: 0);
		}

		[Test]
		[ExpectedException(typeof(ArgumentException))]
		public void Dexterity_cannot_be_greater_than_20() {
			new Character(dexterity: 21);
		}

		#endregion

		#region Constitution

		[Test]
		public void Constitution_defaults_to_10() {
			character.Constitution.ShouldEqual(10);
		}

		[Test]
		public void Constitution_can_be_initialized_to_a_different_value() {
			character = new Character(constitution: 5);
			character.Constitution.ShouldEqual(5);
		}

		[Test]
		[ExpectedException(typeof(ArgumentException))]
		public void Constitution_cannot_be_less_than_1() {
			new Character(constitution: 0);
		}

		[Test]
		[ExpectedException(typeof(ArgumentException))]
		public void Constitution_cannot_be_greater_than_20() {
			new Character(constitution: 21);
		}

		#endregion

		#region Wisdom

		[Test]
		public void Wisdom_defaults_to_10() {
			character.Wisdom.ShouldEqual(10);
		}

		[Test]
		public void Wisdom_can_be_initialized_to_a_different_value() {
			character = new Character(wisdom: 5);
			character.Wisdom.ShouldEqual(5);
		}

		[Test]
		[ExpectedException(typeof(ArgumentException))]
		public void Wisdom_cannot_be_less_than_1() {
			new Character(wisdom: 0);
		}

		[Test]
		[ExpectedException(typeof(ArgumentException))]
		public void Wisdom_cannot_be_greater_than_20() {
			new Character(wisdom: 21);
		}

		#endregion

		#region Intelligence

		[Test]
		public void Intelligence_defaults_to_10() {
			character.Intelligence.ShouldEqual(10);
		}

		[Test]
		public void Intelligence_can_be_initialized_to_a_different_value() {
			character = new Character(intelligence: 5);
			character.Intelligence.ShouldEqual(5);
		}

		[Test]
		[ExpectedException(typeof(ArgumentException))]
		public void Intelligence_cannot_be_less_than_1() {
			new Character(intelligence: 0);
		}

		[Test]
		[ExpectedException(typeof(ArgumentException))]
		public void Intelligence_cannot_be_greater_than_20() {
			new Character(intelligence: 21);
		}

		#endregion

		#region Charisma

		[Test]
		public void Charisma_defaults_to_10() {
			character.Charisma.ShouldEqual(10);
		}

		[Test]
		public void Charisma_can_be_initialized_to_a_different_value() {
			character = new Character(charisma: 5);
			character.Charisma.ShouldEqual(5);
		}

		[Test]
		[ExpectedException(typeof(ArgumentException))]
		public void Charisma_cannot_be_less_than_1() {
			new Character(charisma: 0);
		}

		[Test]
		[ExpectedException(typeof(ArgumentException))]
		public void Charisma_cannot_be_greater_than_20() {
			new Character(charisma: 21);
		}

		#endregion

		#region Attack

		[Test]
		public void Attack_hits_if_roll_equals_opponent_armor_class() {
			var opponent = new Character(armorClass: 5);
			character.Attack(opponent, 5).ShouldEqual(AttackResult.Hit);
		}

		[Test]
		public void Attack_misses_if_roll_is_less_than_opponent_armor_class() {
			var opponent = new Character(armorClass: 5);
			character.Attack(opponent, 4).ShouldEqual(AttackResult.Miss);
		}

		[Test]
		public void Attack_hits_if_roll_is_greater_than_opponent_armor_class() {
			var opponent = new Character(armorClass: 5);
			character.Attack(opponent, 6).ShouldEqual(AttackResult.Hit);
		}

		[Test]
		public void Attack_returns_critical_hit_if_roll_is_20() {
			var opponent = new Character();
			character.Attack(opponent, 20).ShouldEqual(AttackResult.CriticalHit);
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

		[Test]
		public void Attacks_deals_one_damage_to_opponent_on_hit() {
			var opponent = new Character(armorClass: 5, hitPoints: 5);
			character.Attack(opponent, 6);
			opponent.HitPoints.ShouldEqual(4);
		}

		[Test]
		public void Attacks_deals_one_damage_to_opponent_on_critical_hit() {
			var opponent = new Character(armorClass: 5, hitPoints: 5);
			character.Attack(opponent, 20);
			opponent.HitPoints.ShouldEqual(3);
		}

		#endregion

		#region IsDead

		[Test]
		public void IsDead_returns_false_if_hit_points_greater_than_0() {
			var character = new Character(hitPoints: 5);
			character.IsDead().ShouldEqual(false);
		}

		[Test]
		public void IsDead_returns_true_if_hit_points_equals_0() {
			var character = new Character(hitPoints: 0);
			character.IsDead().ShouldEqual(true);
		}

		#endregion
	}
}

