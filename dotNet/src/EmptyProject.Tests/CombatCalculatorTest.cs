using System;
using NUnit.Framework;
using Should.Extensions.AssertExtensions;

namespace EverCraft.Tests {

	[TestFixture()]
	public class CombatCalculatorTest {

		private CombatCalculator calculator;

		[SetUp]
		public void Setup() {
			calculator = new CombatCalculator(new Character());
		}

		#region Attack

		[Test]
		public void Attack_hits_if_roll_equals_opponent_armor_class() {
			var opponent = new Character(armorClass: 10);
			calculator.Attack(opponent, 10).ShouldEqual(AttackResult.Hit);
		}

		[Test]
		public void Attack_misses_if_roll_is_less_than_opponent_armor_class() {
			var opponent = new Character(armorClass: 10);
			calculator.Attack(opponent, 9).ShouldEqual(AttackResult.Miss);
		}

		[Test]
		public void Attack_hits_if_roll_is_greater_than_opponent_armor_class() {
			var opponent = new Character(armorClass: 10);
			calculator.Attack(opponent, 11).ShouldEqual(AttackResult.Hit);
		}

		[Test]
		public void Attack_returns_critical_hit_if_roll_is_20() {
			var opponent = new Character();
			calculator.Attack(opponent, 20).ShouldEqual(AttackResult.CriticalHit);
		}

		[Test]
		public void Attack_does_not_return_critical_hit_if_roll_plus_strength_modifier_is_20() {
			// +1 for strength
			var opponent = new Character(strength: 11);
			calculator.Attack(opponent, 19).ShouldNotEqual(AttackResult.CriticalHit);
		}

		[Test]
		[ExpectedException(typeof(ArgumentException))]
		public void Attack_throws_exception_if_opponent_is_null() {
			calculator.Attack(null, 6);
		}

		[Test]
		[ExpectedException(typeof(ArgumentException))]
		public void Attack_throws_exception_if_roll_is_less_than_1() {
			var opponent = new Character();
			calculator.Attack(opponent, 0);
		}

		[Test]
		[ExpectedException(typeof(ArgumentException))]
		public void Attack_throws_exception_if_roll_is_greater_than_20() {
			var opponent = new Character();
			calculator.Attack(opponent, 21);
		}

		[Test]
		public void Attacks_deals_one_damage_to_opponent_on_hit() {
			var opponent = new Character(armorClass: 5, hitPoints: 5);
			calculator.Attack(opponent, 6);
			opponent.HitPoints.ShouldEqual(4);
		}

		[Test]
		public void Attacks_deals_one_damage_to_opponent_on_critical_hit() {
			var opponent = new Character(armorClass: 5, hitPoints: 5);
			calculator.Attack(opponent, 20);
			opponent.HitPoints.ShouldEqual(3);
		}

		[Test]
		public void attackers_strength_modifier_adds_to_roll_when_attacking() {
			// +1 strength modifier
			calculator = new CombatCalculator(new Character(strength: 12));

			var opponent = new Character(armorClass: 10);
			calculator.Attack(opponent, 9).ShouldEqual(AttackResult.Hit);
		}

		[Test]
		public void attackers_strength_modifier_adds_to_damage_dealt_when_attacking() {
			// +1 strength modifier
			calculator = new CombatCalculator(new Character(strength: 12));

			var opponent = new Character(armorClass: 10, hitPoints: 5);
			calculator.Attack(opponent, 10);
			opponent.HitPoints.ShouldEqual(3);
		}

		[Test]
		public void minimum_damage_on_hit_when_attacking_is_1() {
			// -5 strength modifier
			calculator = new CombatCalculator(new Character(strength: 1));

			var opponent = new Character(armorClass: 10, hitPoints: 5);
			calculator.Attack(opponent, 15);
			opponent.HitPoints.ShouldEqual(4);
		}

		[Test]
		public void opponents_dexterity_modifier_is_added_to_armor_class_when_attacking() {
			// A strength of 10 will give no bonus;
			calculator = new CombatCalculator(new Character(strength: 10));

			// A dexterity of 12 will give a +1 bonus.
			var opponent = new Character(armorClass: 10, dexterity: 12);
			calculator.Attack(opponent, 10).ShouldEqual(AttackResult.Miss);
		}

		#endregion

	}
}

