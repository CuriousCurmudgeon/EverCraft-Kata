class Character

  ALIGNMENTS = [:good, :evil, :neutral]

  attr_accessor :name
  attr_reader :alignment

  # Only values in ALIGNMENT are valid
  def alignment= value
    raise unless ALIGNMENTS.any? {|a| a == value }
    @alignment = value
  end

end
