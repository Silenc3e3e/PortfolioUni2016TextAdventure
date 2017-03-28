using NUnit.Framework;
using System;
using Swin_Adventure;

namespace UnitTests
{
	[TestFixture()]
	public class InventoryTests
	{
		Inventory testInventory;
		Item testItem;

		[OneTimeSetUp]
		public void InventoryTestSetup()
		{
			testInventory = new Inventory();
			testItem = new Item(new string[] { "Fresh", "New", "Mint" }, "Test Item", "This item is for testing");
			testInventory.Put(testItem);
		}

		[Test]
		public void FindItem()
		{
			Assert.True(testInventory.HasItem("nEw"));
			Assert.True(testInventory.HasItem("Test Item"));
		}

		[Test]
		public void NoFindItem()
		{
			Assert.False(testInventory.HasItem("None existant item"));
		}

		[Test]//WARNING, HAS DEPENDANCY ON ITEM EXISTING
		public void Fetch()//WARNING, HAS DEPENDANCY ON ITEM EXISTING
		{
			Assert.AreSame(testItem, testInventory.Fetch("Test Item"));
		}

		[Test]//WARNING, HAS DEPENDANCY ON ITEM EXISTING
		public void ItemList()//WARNING, HAS DEPENDANCY ITEM EXISTING
		{
			Assert.True("\t" + testItem.ShortDescription == testInventory.ItemList);
		}

		[Test]
		public void TakeItem()
		{
			Item takeItem;
			takeItem = testInventory.Take("Test iTeM");
			Assert.False(testInventory.HasItem("Test Item"));
			Assert.False(testInventory.HasItem("Mint"));
		}
	}
}

