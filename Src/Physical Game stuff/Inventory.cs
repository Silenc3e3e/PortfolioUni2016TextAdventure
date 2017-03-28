using System;
using System.Collections.Generic;

namespace Swin_Adventure
{
	public class Inventory : GameObject
	{
		private List<Item> _items;
		public Inventory() : base (new string[0], "", "")
		{
			_items = new List<Item>();
		}

		public bool HasItem(string id)
		{
			return _items.Find(i => i.AreYou(id)) != null;
		}

		public void Put(Item itm)
		{
			_items.Add(itm);
		}

		public Item Take(string id)
		{
			Item toReturn = Fetch(id);
			_items.Remove(toReturn);
			return toReturn;
		}

		public Item Fetch(string id)
		{
			return _items.Find(i => i.AreYou(id));
		}

		public string ItemList
		{
			get
			{
				string items = "";
				foreach (Item itm in _items)
				{
					items += "\t"+itm.ShortDescription+ "\n";
				}
				items = items.TrimEnd();
				return items;
			}
		}
	}
}

