using NUnit.Framework;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ladeskab.Tests
{
    namespace ConsoleLogger.Tests
    {

    }
    public class TestDisplay
    {
        private Display _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new Display();
        }

        public class ConsoleOutput : IDisposable
        {
            private StringWriter stringWriter;
            private TextWriter originalOutput;

            public ConsoleOutput()
            {
                stringWriter = new StringWriter();
                originalOutput = Console.Out;
                Console.SetOut(stringWriter);
            }

            public string GetOuput()
            {
                return stringWriter.ToString();
            }

            public void Dispose()
            {
                Console.SetOut(originalOutput);
                stringWriter.Dispose();
            }
        }

        [Test]
        public void TestAfRFIDMsg()
        {
            var CurrentConsoleOut = Console.Out;

            string text = "Indlæs RFID\r\n";

            using (var ConsoleOutput = new ConsoleOutput())
            {
                _uut.RFIDMsg();
                Assert.AreEqual(text, ConsoleOutput.GetOuput());
            }

            Assert.AreEqual(CurrentConsoleOut, Console.Out);
        }

        [Test]
        public void TestAfConnectMsg()
        {
            var CurrentConsoleOut = Console.Out;

            string text = "Tilslut telefonen\r\n";

            using (var ConsoleOutput = new ConsoleOutput())
            {
                _uut.ConnectMsg();
                Assert.AreEqual(text, ConsoleOutput.GetOuput());
            }

            Assert.AreEqual(CurrentConsoleOut, Console.Out);
        }

        [Test]
        public void TestAfCloseDoorMsg()
        {
            var CurrentConsoleOut = Console.Out;

            string text = "Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op. \r\n";

            using (var ConsoleOutput = new ConsoleOutput())
            {
                _uut.CloseDoorMsg();
                Assert.AreEqual(text, ConsoleOutput.GetOuput());
            }

            Assert.AreEqual(CurrentConsoleOut, Console.Out);
        }

        [Test]
        public void TestAfCloseDoorErrorMsg()
        {
            var CurrentConsoleOut = Console.Out;

            string text = "Din telefon er ikke ordentligt tilsluttet prøv igen. \r\n";

            using (var ConsoleOutput = new ConsoleOutput())
            {
                _uut.CloseDoorErrorMsg();
                Assert.AreEqual(text, ConsoleOutput.GetOuput());
            }

            Assert.AreEqual(CurrentConsoleOut, Console.Out);
        }

        [Test]
        public void TestAfUnlockDoorMsg()
        {
            var CurrentConsoleOut = Console.Out;

            string text = "Tag din telefon ud af skabet og luk døren. \r\n";

            using (var ConsoleOutput = new ConsoleOutput())
            {
                _uut.UnlockDoorMsg();
                Assert.AreEqual(text, ConsoleOutput.GetOuput());
            }

            Assert.AreEqual(CurrentConsoleOut, Console.Out);
        }

        [Test]
        public void TestAfUnlockDoorErrorMsg()
        {
            var CurrentConsoleOut = Console.Out;

            string text = "Forkert RFID prøv igen. \r\n";

            using (var ConsoleOutput = new ConsoleOutput())
            {
                _uut.UnlockDoorErrorMsg();
                Assert.AreEqual(text, ConsoleOutput.GetOuput());
            }

            Assert.AreEqual(CurrentConsoleOut, Console.Out);
        }

        [Test]
        public void TestAfFullycharged()
        {
            var CurrentConsoleOut = Console.Out;

            string text = "Telefon er fuld opladet. \r\n";

            using (var ConsoleOutput = new ConsoleOutput())
            {
                _uut.Fullycharged();
                Assert.AreEqual(text, ConsoleOutput.GetOuput());
            }

            Assert.AreEqual(CurrentConsoleOut, Console.Out);
        }

        [Test]
        public void TestAfCharging()
        {
            var CurrentConsoleOut = Console.Out;

            string text = "Telefonen er under opladning. \r\n";

            using (var ConsoleOutput = new ConsoleOutput())
            {
                _uut.Charging();
                Assert.AreEqual(text, ConsoleOutput.GetOuput());
            }

            Assert.AreEqual(CurrentConsoleOut, Console.Out);
        }

        [Test]
        public void TestAfErrorMsgCharge()
        {
            var CurrentConsoleOut = Console.Out;

            string text = "Error, Træk stikket ud. \r\n";

            using (var ConsoleOutput = new ConsoleOutput())
            {
                _uut.ErrorMsgCharge();
                Assert.AreEqual(text, ConsoleOutput.GetOuput());
            }

            Assert.AreEqual(CurrentConsoleOut, Console.Out);
        }
    }
}
