class Character

  ALIGNMENTS = [:good, :evil, :neutral]
  ABILITY_MODIFIERS = [-5, -4, -4, -3, -3,
                       -2, -2, -1, -1,  0,
                        0, +1, +1, +2, +2,
                       +3, +3, +4, +4, +5]

  attr_accessor :name, :armor_class, :hit_points
  attr_reader :alignment, :strength, :dexterity, :constitution,
              :wisdom, :intelligence, :charisma

  def initialize params = {}
    @armor_class = params[:armor_class] || 10
    @hit_points = params[:hit_points] || 5

    [:strength, :dexterity, :constitution, :wisdom, :intelligence, :charisma].each do |attribute|
      value = params[attribute] || 10
      raise if value < 1 || value > 20
      instance_variable_set("@#{attribute}", value)
    end
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
