using System;

namespace Ladeskab
{
    public interface IDoor
    {
        public event EventHandler DoorOpened;
        public event EventHandler DoorClosed;
        
        public void LockDoor();
        public void UnlockDoor();
        
    }

}