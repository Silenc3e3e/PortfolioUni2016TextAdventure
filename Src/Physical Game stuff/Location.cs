using System;
using System.Linq;
namespace Swin_Adventure
{
	public class Location: GameObject, IHaveInventory
	{
		private Inventory _inventory;

		//																  Concat is here to allow more idents to be passed through on construction of a Location
		public Location(string[] idents, string name, string desc) : base(idents.Concat(new string[] {"Location", "Area", "Here"}).ToArray(), name, desc)
		{
			_inventory = new Inventory();
		}

		public Inventory Inventory
		{
			get
			{
				return _inventory;
			}
		}

		public GameObject Locate(string id)
		{
			if (AreYou(id))
			{
				return this;
			}
			return _inventory.Fetch(id);
		}
	}
}

