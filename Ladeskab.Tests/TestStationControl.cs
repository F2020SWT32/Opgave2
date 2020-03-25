using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;

namespace Ladeskab.Tests
{

    [TestFixture]
    class TestStationControl
    {


        private IDisplay display = Substitute.For<IDisplay>();
        private ILogFile logfile = Substitute.For<ILogFile>();
        private IChargeControl chargeControl = Substitute.For<IChargeControl>();
        private IDoor door = Substitute.For<IDoor>();
        private IRfidReader reader = Substitute.For<IRfidReader>();

        private StationControl _uut;

        [SetUp]

        public void setup()
        {
            _uut = new StationControl(display, logfile, chargeControl, door, reader);
        }

        [Test]

        public void testDoorOpenedHandler()
        {

            door.DoorOpened += Raise.EventWith(new object(), new EventArgs());
            display.Received().ConnectMsg();
            Assert.AreEqual("DoorOpen", _uut.state.ToString());
        }

        [Test]
        public void testDoorClosedHandler()
        {

            door.DoorClosed += Raise.EventWith(new object(), new EventArgs());
            display.Received(2).RFIDMsg();
            Assert.AreEqual("Available", _uut.state.ToString());
        }
        [Test]
        public void RfidAvailableSuccess()
        {
            chargeControl.IsConnected().Returns(true);
            reader.RfidDetected += Raise.EventWith(new object(), new RfidDetectedEventArgs(123));
            door.Received().LockDoor();
            chargeControl.Received().StartCharge();
            logfile.Received().logWrite(1, 123);
            display.Received().CloseDoorMsg();
            Assert.AreEqual("Locked", _uut.state.ToString());

        }
        [Test]
        public void RfidAvailableError()
        {
            chargeControl.IsConnected().Returns(false);
            reader.RfidDetected += Raise.EventWith(new object(), new RfidDetectedEventArgs(123));
            display.Received().CloseDoorErrorMsg();
        }
    }

}
