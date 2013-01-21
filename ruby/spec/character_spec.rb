require 'character'

describe Character do

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
    let(:opponent) {
      c = Character.new
      c.armor_class = armor_class
      c
    }

    it "hits if the die roll is larger than the opponent's armor class" do
      subject.attack(opponent, armor_class + 1).should be true
    end

    it "hits if the die roll equals the opponent's armor class" do
      subject.attack(opponent, armor_class).should be true
    end

    it "misses if the die roll is less than the opponent's armor class" do
      subject.attack(opponent, armor_class - 1).should be false
    end
  end

end
