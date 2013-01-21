require 'character'

describe Character do

  describe "Name" do
    it "can be set" do
      subject.name = "Test"
      subject.name.should == "Test"
    end

    it "can be read" do
      subject.name = "Test"
      subject.name.should == "Test"
    end
  end

end
