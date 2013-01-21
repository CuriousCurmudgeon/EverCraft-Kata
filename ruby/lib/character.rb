class Character

  ALIGNMENTS = [:good, :evil, :neutral]

  attr_accessor :name, :armor_class, :hit_points
  attr_reader :alignment

  def initialize
    @armor_class = 10
    @hit_points = 5
  end

  # Only values in ALIGNMENT are valid
  def alignment= value
    raise unless ALIGNMENTS.any? {|a| a == value }
    @alignment = value
  end

  # Attack an opponent.
  # @param opponent Who is being attacked.
  # @param die_roll Value from the roll of a d20.
  def attack opponent, die_roll
    result = :miss

    if die_roll == 20
      result = :critical_hit
      opponent.hit_points -= 2
    elsif die_roll >= opponent.armor_class
      result = :hit
      opponent.hit_points -= 1
    end

    result
  end

  # A character is dead when they have 0 hit points.
  def dead?
    @hit_points <= 0
  end

end
