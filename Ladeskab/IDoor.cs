using System;

namespace Ladeskab
{
    public interface IDoor
    {
        event EventHandler DoorOpened;
        event EventHandler DoorClosed;
        
        void LockDoor();
        void UnlockDoor();
        
    }

}