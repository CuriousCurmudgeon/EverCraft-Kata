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

end
