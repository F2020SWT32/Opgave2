using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsbSimulator;

namespace Ladeskab
{
    public class Door : IDoor
    {
        public event EventHandler DoorOpened;
        public event EventHandler DoorClosed;

        
        public void openDoor()
        {
            DoorOpened.Invoke(this, EventArgs.Empty);
        }

        public void closeDoor()
        {
            DoorClosed.Invoke(this, EventArgs.Empty);
        }

    }

}