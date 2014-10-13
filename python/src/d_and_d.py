import random
from enum import Enum
Alignment = Enum("Alignment", "Good Neutral Evil")

class Character:
    name = ""
    alignment = Alignment.Good
    char_class = "Human"
    hit_points = 5
    armor_class = 10

    def __init__(self, *args, **kwargs):
        for key in kwargs:
            if hasattr(self, key):
                setattr(self, key, kwargs[key])

    def attack(self, character):
        roll = random.randint(1,20)
        damage = 0
        if roll >= character.armor_class:
            damage = 1
        if roll == 20:
            damage = damage * 2
        character.hit_points -= damage
        return damage

    def is_dead(self):
        return hit_points <= 0

# class Combat:
#     attack

#     def __init__(self, attacker, defender):

if __name__ == "__main__":
    import doctest
    doctest.testmod()
