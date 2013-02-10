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
			var opponent = new Character(armorClass: 5);
			calculator.Attack(opponent, 5).ShouldEqual(AttackResult.Hit);
		}

		[Test]
		public void Attack_misses_if_roll_is_less_than_opponent_armor_class() {
			var opponent = new Character(armorClass: 5);
			calculator.Attack(opponent, 4).ShouldEqual(AttackResult.Miss);
		}

		[Test]
		public void Attack_hits_if_roll_is_greater_than_opponent_armor_class() {
			var opponent = new Character(armorClass: 5);
			calculator.Attack(opponent, 6).ShouldEqual(AttackResult.Hit);
		}

		[Test]
		public void Attack_returns_critical_hit_if_roll_is_20() {
			var opponent = new Character();
			calculator.Attack(opponent, 20).ShouldEqual(AttackResult.CriticalHit);
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

		#endregion

	}
}

