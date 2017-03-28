using NUnit.Framework;
using System;
using Swin_Adventure;

namespace UnitTests
{
	[TestFixture()]
	public class PlayerTests
	{
		Player testPlayer;
		Item testItem;
		Item testItemB;
		Location testLocation;

		[OneTimeSetUp]
		public void PlayerTestSetup()
		{
			testLocation = new Location(new string[] { "Test" }, "Test Area", "Such test!");
			testPlayer = new Player("Luke", "This man is amazing!", testLocation);
			testItem = new Item(new string[] { "Fresh", "New", "Mint" }, "Test Item", "This item is for testing");
			testItemB = new Item(new string[] { "B", "Second", "Different" }, "Test B Item", "This item is for testing search in location");
			testPlayer.Inventory.Put(testItem);
		}

		[Test]
		public void Identifiable()
		{
			Assert.True(testPlayer.AreYou("me"));
			Assert.True(testPlayer.AreYou("inventory"));
		}

		[Test]
		public void LocateItems()
		{
			Assert.AreEqual(testItem, testPlayer.Locate("Test Item"));
		}

		[Test]
		public void LocateItemsInLocation()
		{
			testLocation.Inventory.Put(testItemB);
			Assert.AreEqual(testItemB, testPlayer.Locate("B"), testItem.Name +" vs. "+testPlayer.Locate("Test B Item"));
		}

		[Test]
		public void LocateSelf()
		{
			Assert.AreEqual(testPlayer, testPlayer.Locate("me"));
			Assert.AreEqual(testPlayer, testPlayer.Locate("inventory"));
		}

		[Test]
		public void LocateNothing()
		{
			Assert.Null(testPlayer.Locate("A none existant Item"));
		}

		[Test]//WARNING, HAS DEPENDANCY ON ITEM EXISTING
		public void FullDescription()//WARNING, HAS DEPENDANCY ON ITEM EXISTING
		{
			LocateItems();
			Assert.True("me Luke\nThis man is amazing!\n\tFresh Test Item" == testPlayer.FullDescription);
		}
	}
}

