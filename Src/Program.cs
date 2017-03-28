using System;

namespace Swin_Adventure
{
	class MainClass
	{
		static Player thePlayer;

		public static void Main(string[] args)
		{
			Console.ReadLine();
			Console.WriteLine("Please enter your player name");
			string playerName = Console.ReadLine();
			Console.WriteLine("Please Describe your player");
			string playerDescription = Console.ReadLine();
			Location startPlace = new Location(new string[] { "First" }, "Starting Area", "such beginnings");
			thePlayer = new Player(playerName, playerDescription, startPlace);

			Item bigGem = new Item(new string[] { "big", "large", "shiny", "gem" }, "BigGem", "This is a very large gem");
			Item littleGem = new Item(new string[] { "small", "little", "shiny", "gem" }, "LittleGem", "This is a very small gem");
			thePlayer.Inventory.Put(bigGem);
			thePlayer.Inventory.Put(littleGem);

			Bag playerBag = new Bag(new string[] { "useful", "large", "shiny", "gem" }, "HandBag", "A very pretty man bag");
			thePlayer.Inventory.Put(playerBag);

			Item shovel = new Item(new string[] { "Useful", "long", "spadelike" }, "Shovel", "Can pick up dirt, and other substances");
			playerBag.Inventory.Put(shovel);

			Console.WriteLine(thePlayer.Name + " has the following in their inventory");
			Console.WriteLine(thePlayer.Inventory.ItemList);
			Console.WriteLine(thePlayer.Name + " has the following in their " + playerBag.Name);
			Console.WriteLine(playerBag.Inventory.ItemList);
		}
	}
}
