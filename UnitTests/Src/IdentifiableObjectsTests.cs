using NUnit.Framework;
using System;
using Swin_Adventure;

namespace UnitTests
{
	[TestFixture()]
	public class IdentifiableObjectsTests
	{
		IdentifiableObject testIdentifiableObject;

		[SetUp]
		public void IdentifiableObjectsTestSetup()
		{
			testIdentifiableObject = new IdentifiableObject(new string[] { "Test Value", "Anouther Test Value" });
		}

		[Test]
		public void AreYou()
		{
			Assert.AreEqual(true, testIdentifiableObject.AreYou("Test Value"), "Are you function can find a real match");
			Assert.AreNotEqual(true, testIdentifiableObject.AreYou("Incorrect value"), "Are you function does not find a false match");
			Assert.AreEqual(true, testIdentifiableObject.AreYou("tEsT vAlUe"), "Are you function can find mismatch casing value");
		}

		[Test]
		public void FirstId()
		{
			Assert.AreEqual("Test Value", testIdentifiableObject.FirstId, "Returns first ID");
		}

		[Test]
		public void AddIdentifier()
		{
			testIdentifiableObject.AddIdentifier("New Value");
			Assert.AreEqual(true, testIdentifiableObject.AreYou("New Value"), "Can add new IDs");
		}
	}
}

