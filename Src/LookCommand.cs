using System;
namespace Swin_Adventure
{
	public class LookCommand : Command
	{
		public LookCommand(): base(new string[] { "Look" })
		{
		}

		public override string Execute(Player p, string[] text)
		{
			if (text.Length != 3 && text.Length != 5)
				return "I don't know how to look like that";
			if (text[0].ToLower() != "look")
				return "Error in look input";
			if (text[1].ToLower() != "at")
				return "What do you want to look at?";
			if (text.Length == 5 && text[3].ToLower() != "in")
				return "What do you want to look in?";
			IHaveInventory container;
			if (text.Length == 3)
				container = p;
			else {
				container = FetchContainer(p, text[4]);
				if (container == null)
					return "I cannot find the " + text[4];
			}
			return LookAtIn(text[2], container);
		}

		private IHaveInventory FetchContainer(Player p, string containerId)
		{
			return (IHaveInventory)p.Locate(containerId);
		}

		private string LookAtIn(string thingId, IHaveInventory container)
		{
			GameObject itemFound = container.Locate(thingId);
			if (itemFound != null)
				return itemFound.FullDescription;
			else
				return "I cannot find the " + thingId + " in the " + container.Name;
		}
	}
}

