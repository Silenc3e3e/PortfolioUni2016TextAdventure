using NUnit.Framework;
using System;
using Swin_Adventure;

namespace UnitTests
{
	[TestFixture()]
	public class ItemTests
	{
		Item testItem;

		[SetUp]
		public void ItemTestSetup()
		{
			testItem = new Item(new string[] { "Fresh", "New", "Mint" }, "Test Item", "This item is for testing");
		}

		[Test]
		public void AreYou()
		{
			Assert.AreEqual(true, testItem.AreYou("Fresh"));
			Assert.AreEqual(true, testItem.AreYou("nEw"));
			Assert.AreNotEqual(true, testItem.AreYou("Old"));
		}

		[Test]
		public void ShortDescription()
		{ 
			Assert.AreEqual("Fresh Test Item", testItem.ShortDescription);
		}

		[Test]
		public void FullDescription()
		{
			Assert.AreEqual("This item is for testing", testItem.FullDescription);
		}
	}
}

