using System;
namespace Swin_Adventure
{
	public class Player : GameObject, IHaveInventory
	{
		private Inventory _inventory;
		private Location _location;

		public Player(string name, string desc, Location startLocation) : base(new string[] { "me", "inventory"}, name, desc)
		{
			_inventory = new Inventory();
			_location = startLocation;
		}

		public GameObject Locate(string id)
		{
			if (AreYou(id))
			{
				return this;
			}
			Item test = _inventory.Fetch(id);
			if (test != null && test.AreYou(id))
			{
				return test;
			}
			return _location.Inventory.Fetch(id);
		}

		public override string FullDescription
		{
			get
			{
				return ShortDescription + "\n" + base.FullDescription + "\n" + _inventory.ItemList;
			}
		}

		public Inventory Inventory
		{
			get
			{
				return _inventory;
			}
		}
	}
}

