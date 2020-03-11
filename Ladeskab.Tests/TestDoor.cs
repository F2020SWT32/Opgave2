using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ladeskab.Tests
{
    [TestFixture]
    public class TestDoor
    {
        private Door _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new Door();
        }

        [Test]
        public void TestDoorOpened()
        {
            var WasCalled = false;
            _uut.DoorOpened += (o, e) => {WasCalled = true;};

            Assert.IsTrue(WasCalled);
        }
        
        public void TestDoorClosed()
        {
            var WasCalled = false;
            _uut.DoorClosed += (o, e) => {WasCalled = true;};

            Assert.IsTrue(WasCalled);
        }
    }
}