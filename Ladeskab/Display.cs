using System;
using System.Collections.Generic;
using System.Text;

namespace Ladeskab
{
    public class Display : IDisplay
    {
        public void RFIDMsg()
        {
            Console.WriteLine("Indlæs RFID");
        }

        public void ConnectMsg()
        {
            Console.WriteLine("Tilslut telefonen");
        }

        public void CloseDoorMsg()
        {
            Console.WriteLine("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op. ");
        }

        public void CloseDoorErrorMsg()
        {
            Console.WriteLine("Din telefon er ikke ordentligt tilsluttet prøv igen. ");
        }

        public void UnlockDoorMsg()
        {
            Console.WriteLine("Tag din telefon ud af skabet og luk døren. ");
        }

        public void UnlockDoorErrorMsg()
        {
            Console.WriteLine("Forkert RFID prøv igen. ");
        }

        public void Fullycharged()
        {
            Console.WriteLine("Telefon er fuld opladet. ");
        }

        public void Opladning()
        {
            Console.WriteLine("Telefonen er under opladning. ");
        }

        public void ErrorMsgCharge()
        {
            Console.WriteLine("Error, Træk stikket ud. ");
        }
    }

    public interface IDisplay
    {

        public void RFIDMsg();

        public void ConnectMsg();

        public void CloseDoorMsg();

        public void CloseDoorErrorMsg();

        public void UnlockDoorMsg();

        public void UnlockDoorErrorMsg();

        public void Fullycharged();

        public void Opladning();

        public void ErrorMsgCharge();
    }


    /*
    public class DisplayEventArgs : EventArgs
    {
        public Display Display { get; set; }
    }
    public class DisplayService
    {
        public EventHandler<DisplayEventArgs> DisplayShown;

        public void DisplayMessage(Display message)
        {
            Console.WriteLine(message.Msg);

            OnDisplayShown(message);
        }

        protected virtual void OnDisplayShown(Display message)
        {
            DisplayShown?.Invoke(this, new DisplayEventArgs() { Display = message });
        }
    }
    */
}
