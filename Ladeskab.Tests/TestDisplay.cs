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
    }
}
