using System;
using NUnit.Framework;
using Should.Extensions.AssertExtensions;

namespace EverCraft.Tests {
	[TestFixture()]
	public class CharacterTest {

		[Test()]
		public void can_set_and_read_name () {
			var character = new Character { Name = "Test" };
			character.Name.ShouldEqual("Test");
		}
	}
}

