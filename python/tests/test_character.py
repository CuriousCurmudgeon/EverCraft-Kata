#!/usr/bin/python
import sys
sys.path.append('src/')

import unittest
import random
from d_and_d import Character
from d_and_d import Alignment

class TestCharacter(unittest.TestCase):

    def test_constructor_can_set_name(self):
        expectedName = "Mordo"
        character = Character(name=expectedName)
        self.assertEquals(character.name, expectedName)

    def test_constructor_can_set_alignment(self):
        expectedAlignment = Alignment.Evil
        character = Character(alignment=expectedAlignment)
        self.assertEquals(character.alignment, expectedAlignment)

    def test_character_starts_with_5_hit_points(self):
        character = Character()
        self.assertEqual(character.hit_points, 5)

    def test_character_starts_with_an_armor_class_of_10(self):
        character = Character()
        self.assertEqual(character.armor_class, 10)

    def test_attack_hits_if_roll_equal_to_armor_class(self):
        random.seed(1) # Will give a roll of 3
        attacker = Character()
        defender = Character(armor_class=3)
        damage = attacker.attack(defender)
        self.assertTrue(damage > 0)

    def test_attack_hits_if_roll_greater_than_armor_class(self):
        random.seed(1) # Will give a roll of 3
        attacker = Character()
        defender = Character(armor_class=2)
        damage = attacker.attack(defender)
        self.assertTrue(damage > 0)

    def test_successful_attack_deals_one_damage(self):
        random.seed(1) # Will give a roll of 3
        self._test_successful_attack(3, 1)

    def test_critical_attack_deals_two_damage(self):
        random.seed(2) # Will give a roll of 20
        self._test_successful_attack(3, 2)

    def _test_successful_attack(self, armor_class, expected_damage):
        attacker = Character()
        defender = Character(armor_class=3)
        damage = attacker.attack(defender)
        self.assertEqual(damage, expected_damage)

    def test_character_is_dead_if_hit_points_equals_zero(self):
        character = Character(hit_points=0)
        self.assertTrue(character.is_dead)

    def test_character_is_dead_if_hit_points_less_than_zero(self):
        character = Character(hit_points=-1)
        self.assertTrue(character.is_dead)

if __name__ == '__main__':
    unittest.main()
