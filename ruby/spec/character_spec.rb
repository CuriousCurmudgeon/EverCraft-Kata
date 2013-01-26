require 'character'

shared_examples "an ability score" do
  it "defaults to 10" do
    subject.send(ability).should == 10
  end

  it "can be initialized to a value from 1-20" do
    c = Character.new(ability => 1)
    c.send(ability).should == 1
  end

  it "cannot be initialized to a value < 1" do
    lambda { Character.new(ability => 0) }.should raise_error
  end

  it "cannot be initialized to a value > 20" do
    lambda { Character.new(ability => 21) }.should raise_error
  end
end

describe Character do

  describe "initialize" do
    it "can take a hash" do
      c = Character.new(:armor_class => 8)
      c.armor_class.should == 8
    end
  end

  describe "name" do
    it "can be set" do
      subject.name = "Test"
      subject.name.should == "Test"
    end

    it "can be read" do
      subject.name = "Test"
      subject.name.should == "Test"
    end
  end

  describe "alignment" do

    def test_valid_alignment alignment
      subject.alignment = alignment
      subject.alignment.should == alignment
    end

    it { test_valid_alignment(:good) }
    it { test_valid_alignment(:evil) }
    it { test_valid_alignment(:neutral) }

    it "cannot be set to an invalid value" do
      lambda { subject.alignment = :invalid }.should raise_error
    end

  end

  describe "ABILITY_MODIFIERS" do
    it "can be read" do
      Character::ABILITY_MODIFIERS.size.should == 20
    end
  end

  describe "strength" do
    let(:ability) { :strength }
    it_behaves_like "an ability score"
  end

  describe "dexterity" do
    let(:ability) { :dexterity }
    it_behaves_like "an ability score"
  end

  describe "constitution" do
    let(:ability) { :constitution }
    it_behaves_like "an ability score"
  end

  describe "wisdom" do
    let(:ability) { :wisdom }
    it_behaves_like "an ability score"
  end

  describe "intelligence" do
    let(:ability) { :intelligence }
    it_behaves_like "an ability score"
  end

  describe "charisma" do
    let(:ability) { :charisma }
    it_behaves_like "an ability score"
  end

  describe "armor_class" do
    it "defaults to 10" do
      subject.armor_class.should == 10
    end

    it "can be changed" do
      subject.armor_class = 5
      subject.armor_class.should == 5
    end
  end

  describe "hit_points" do
    it "defaults to 5" do
      subject.hit_points.should == 5
    end

    it "can be changed" do
      subject.hit_points = 10
      subject.hit_points.should == 10
    end
  end

  describe 'attack' do
    let(:armor_class) { 5 }
    let(:hit_points) { 5 }
    let(:opponent) {
      c = Character.new
      c.armor_class = armor_class
      c.hit_points = hit_points
      c
    }

    it "hits if the die roll is larger than the opponent's armor class" do
      subject.attack(opponent, armor_class + 1).should == :hit
    end

    it "hits if the die roll equals the opponent's armor class" do
      subject.attack(opponent, armor_class).should == :hit
    end

    it "is a critical hit on a natural 20" do
      subject.attack(opponent, 20).should == :critical_hit
    end

    it "deals one point of damage on a hit" do
      subject.attack(opponent, armor_class)
      opponent.hit_points.should == hit_points - 1
    end

    it "deals two points of damage on a critical hit" do
      subject.attack(opponent, 20)
      opponent.hit_points.should == hit_points - 2
    end

    it "misses if the die roll is less than the opponent's armor class" do
      subject.attack(opponent, armor_class - 1).should be :miss
    end
  end

  describe "is dead?" do

    it "returns true when their hit points are at 0" do
      subject.hit_points = 0
      subject.dead?.should be true
    end

    it "returns false if hit points are greater than 0" do
      subject.hit_points = 1
      subject.dead?.should be false
    end

  end

end
