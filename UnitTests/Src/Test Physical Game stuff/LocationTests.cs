using NUnit.Framework;
using System;
using Swin_Adventure;

namespace UnitTests
{
	[TestFixture()]
	public class LocationTests
	{
		Location testLocation;
		Item testItem;

		[OneTimeSetUp]
		public void LocationTestSetup()
		{
			testLocation = new Location(new string[] { "Test" }, "Test Area", "Such test!");
			testItem = new Item(new string[] { "Fresh", "New", "Mint" }, "Test Item", "This item is for testing");
		}

		[Test]
		public void IdentifySelf()
		{
			Assert.AreEqual(testLocation.Locate("Test"),testLocation as GameObject);
			Assert.AreEqual(testLocation.Locate("Test aRea"), testLocation as GameObject);
		}

		[Test]
		public void LocateItem()
		{
			testLocation.Inventory.Put(testItem);
			Assert.AreEqual(testLocation.Locate("Fresh"), testItem as GameObject);
			Assert.AreEqual(testLocation.Locate("MinT"), testItem as GameObject);
			Assert.AreEqual(testLocation.Locate("tEST iTEM"), testItem as GameObject);
		}
	}
}

