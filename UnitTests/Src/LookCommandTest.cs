using NUnit.Framework;
using System;
using Swin_Adventure;

namespace UnitTests
{
	[TestFixture()]
	public class LookCommandTest
	{
		Player testPlayer;
		LookCommand testLookCommand;
		Item testItem;
		Bag testBag;
		Location testLocation;

		[SetUp]
		public void LookCommandTestSetup()
		{
			testLocation = new Location(new string[] { "Test" }, "Test Area", "Such test!");
			testPlayer = new Player("Luke", "The Amazing one!", testLocation);
			testLookCommand = new LookCommand();
			testItem = new Item(new string[] { "Shiny" }, "Gem", "A shiny gem");
			testBag = new Bag(new string[] { "Large" }, "Bag", "A large leather bag");

			testPlayer.Inventory.Put(testItem);
			testPlayer.Inventory.Put(testBag);
		}

		[Test]
		public void LookAtMe()
		{
			Assert.AreEqual(testPlayer.FullDescription, testLookCommand.Execute(testPlayer,new string[]{ "look", "at", "me" }));
		}

		[Test]
		public void LookAtGem()
		{
			Assert.AreEqual("A shiny gem", testLookCommand.Execute(testPlayer, new string[] { "look", "at", "Gem" }));
		}

		[Test]
		public void LookAtUnk()
		{
			testPlayer.Inventory.Take("Gem");
			Assert.AreEqual("I cannot find the gem in the Luke", testLookCommand.Execute(testPlayer, new string[] { "look", "at", "gem" }));
		}

		[Test]
		public void LookAtGemInMe()
		{
			Assert.AreEqual("A shiny gem", testLookCommand.Execute(testPlayer, new string[] { "look", "at", "Gem", "in", "me" }));
		}

		[Test]
		public void LookAtGemInBag()
		{
			testBag.Inventory.Put(testPlayer.Inventory.Take("gem"));
			Assert.AreEqual("A shiny gem", testLookCommand.Execute(testPlayer, new string[] { "look", "at", "Gem", "in", "bag" }));
		}

		[Test]
		public void LookAtGemInNoBag()
		{
			testPlayer.Inventory.Take("Bag");
			Assert.AreEqual("I cannot find the bag", testLookCommand.Execute(testPlayer, new string[] { "look", "at", "Gem", "in", "bag" }));
		}

		[Test]
		public void LookAtNoGemInBag()
		{
			testPlayer.Inventory.Take("gem");
			Assert.AreEqual("I cannot find the gem in the Bag", testLookCommand.Execute(testPlayer, new string[] { "look", "at", "gem", "in", "bag" }));
		}

		[Test]
		public void InvalidLook()
		{
			Assert.AreEqual("What do you want to look at?", testLookCommand.Execute(testPlayer, new string[] { "look", "around", "room"}));
			Assert.AreEqual("Error in look input", testLookCommand.Execute(testPlayer, new string[] { "Hello", "sup", "Brau"}));
			Assert.AreEqual("What do you want to look in?", testLookCommand.Execute(testPlayer, new string[] { "look", "at", "a", "at", "b" }));
			Assert.AreEqual("I don't know how to look like that", testLookCommand.Execute(testPlayer, new string[] { "look", "at", "a", "in", "b", "in", "c" }));
		}
	}
}

