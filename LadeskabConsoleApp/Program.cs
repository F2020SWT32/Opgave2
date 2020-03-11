
using System;

namespace Ladeskab
{
    class Program
    {
        static void Main(string[] args)
        {
				// Assemble your system here from all the classes
			
			RfidReader rfidReader = new RfidReader();
			Display display = new Display();
			LogFile logFile = new LogFile();
			Door door = new Door();
			UsbChargerSimulator usbCharger = new UsbChargerSimulator();
			ChargeControl chargeControl = new ChargeControl(usbCharger);
			StationControl controller = new StationControl(
				display,
				logFile,
				chargeControl,
				door,
				rfidReader
			);
			
            bool finish = false;
            do
            {
                string input;
                System.Console.WriteLine("Indtast E, O, C, R: ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) continue;

                switch (input[0])
                {
                    case 'E':
                        finish = true;
                        break;

                    case 'O':
                        //door.OnDoorOpen();
                        break;

                    case 'C':
                        //door.OnDoorClose();
                        break;

                    case 'R':
                        System.Console.WriteLine("Indtast RFID id: ");
                        string idString = System.Console.ReadLine();

                        int id = Convert.ToInt32(idString);
                        rfidReader.OnRfidRead(id);
                        break;

                    default:
                        break;
                }

            } while (!finish);
        }
    }
}
