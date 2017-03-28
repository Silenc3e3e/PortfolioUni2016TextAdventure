using NUnit.Framework;
using System;
using Swin_Adventure;
namespace UnitTests
{
	[TestFixture()]
	public class BagTests
	{
		Bag testBag;
		Item testItem;

		[SetUp]
		public void BagTestsSetup()
		{
			testBag = new Bag(new string[]{ "Very large" },"Test Bag","This is an amazing bag!");
			testItem = new Item(new string[] { "Fresh", "New", "Mint" }, "Test Item", "This item is for testing");
			testBag.Inventory.Put(testItem);
		}

		[Test]
		public void LocateItems()
		{
			Assert.AreEqual(testItem, testBag.Locate("Test Item"));
		}

		[Test]
		public void LocateSelf()
		{
			Assert.AreEqual(testBag, testBag.Locate("Very large"));
			Assert.AreEqual(testBag, testBag.Locate("Test Bag"));
		}

		[Test]
		public void LocateNothing()
		{
			Assert.Null(testBag.Locate("A none existant Item"));
		}

		[Test]
		public void FullDescription()
		{
			Assert.AreEqual("Very large Test Bag\nThis is an amazing bag!\n\tFresh Test Item" , testBag.FullDescription);
		}

		[Test]
		public void CanLocateBagInItself()
		{
			Bag testBag2 = new Bag(new string[] { "Somewhat small" }, "Anouther Test Bag", "This is an OK bag!");
			Item testItem2 = new Item(new string[] { "Moldy", "Old", "Smelly" }, "Anouther Test Item", "This other item is for testing");

			testBag2.Inventory.Put(testItem2);
			testBag.Inventory.Put(testBag2);

			Assert.AreEqual(testItem, testBag.Locate("Test Item"));
			Assert.AreSame(testBag2, testBag.Locate("Somewhat small"));
			Assert.AreEqual(testBag2, testBag.Locate("Anouther Test Bag"));
			Assert.Null(testBag.Locate("Moldy"));
			Assert.Null(testBag.Locate("Anouther Test Item"));
		}
	}
}

