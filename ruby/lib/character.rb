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

end
