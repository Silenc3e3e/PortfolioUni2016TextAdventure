using System;
using System.Collections.Generic;
namespace Swin_Adventure
{
	public class IdentifiableObject
	{
		private List<string> _identifiers;

		public IdentifiableObject()
		{
			_identifiers = new List<string>();
		}
		public IdentifiableObject(string[] idents) : this()
		{
			foreach (string s in idents)
			{
				if (s != null)
				{
					_identifiers.Add(s);
				}
			}
		}

		public bool AreYou(string id)
		{
			foreach (string subject in _identifiers)
			{
				if (subject.ToLower().Equals(id.ToLower()))
				{
					return true;
				}
			}
			return false;
		}
		public string FirstId
		{
			get
			{
				if (_identifiers.Count > 0)
				{
					return _identifiers[0];
				}
				else
				{
					return "";
				}
			}
		}

		public void AddIdentifier(string id)
		{
			_identifiers.Add(id);
		}
	}
}