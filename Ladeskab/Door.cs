using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab
{
    public class Door : IDoor
    {
        private bool isLocked;
        public event EventHandler DoorOpened;
        public event EventHandler DoorClosed;

        
        public bool openDoor()
        {
            if(isLocked)
                return false;
            DoorOpened?.Invoke(this, EventArgs.Empty);
                return true;
        }

        public bool closeDoor()
        {
            DoorClosed?.Invoke(this, EventArgs.Empty);
            return true;
        }
        
        public void LockDoor()
        {
            isLocked = true;
                
        }
        
        public void UnlockDoor()
        {
            isLocked = false;
        }

    }

}