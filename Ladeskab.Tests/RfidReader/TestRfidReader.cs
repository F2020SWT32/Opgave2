
using NUnit.Framework;

namespace Ladeskab.Tests
{
	[TestFixture]
	public class TestRfidReader
	{
		
		private RfidReader _uut;
		
		[SetUp]
		public void Setup()
		{
			_uut = new RfidReader();
		}
		
		[TestCase(123)]
		[TestCase(2819923)]
		[TestCase(0)]
		public void TestRfidDetectedEvent(int id)
		{
			int arg = -1;
			_uut.RfidDetected += (o, args) =>
			{
				arg = args.Id;
			};
			_uut.OnRfidRead(id);
			Assert.AreEqual(arg, id);
		}
	}
}