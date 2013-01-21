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
    die_roll >= opponent.armor_class
  end

end
