using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace Ladeskab
{
    public class StationControl
    {
        // Enum med tilstande ("states") svarende til tilstandsdiagrammet for klassen
        public enum LadeskabState
        {
            Available,
            Locked,
            DoorOpen
        };

        // Her mangler flere member variable
        private LadeskabState _state;
        private IDisplay _display;
        private ILogFile _log;
        private IChargeControl _chargeControl;
        private int _oldId;
        private IDoor _door;
        private IRfidReader _reader;

        public LadeskabState state
        {
            get
            {
                return _state;
            }
        }


        public StationControl(IDisplay _display, ILogFile _log, IChargeControl _chargeControl, IDoor _door, IRfidReader _reader)
        {
            this._display = _display;
            this._log = _log;
            this._chargeControl = _chargeControl;
            this._door = _door;
            _door.DoorOpened += DoorOpenedHandler;
            _door.DoorClosed += DoorClosedHandler;
            this._reader = _reader;
            _reader.RfidDetected += RfidDetectedHandler;
            _oldId = 0;
            _state = LadeskabState.Available;
            _display.RFIDMsg();

        }

        

        // Eksempel på event handler for eventet "RFID Detected" fra tilstandsdiagrammet for klassen
        private void RfidDetectedHandler(object sender, RfidDetectedEventArgs arg)
        {
            switch (_state)
            {
                case LadeskabState.Available:
                    // Check for ladeforbindelse
                    if (_chargeControl.IsConnected())
                    {
                        _door.LockDoor();
                        _chargeControl.StartCharge();
                        _oldId = arg.Id;

                        _log.logWrite(1, _oldId);
                        _display.CloseDoorMsg();
                       
                        _state = LadeskabState.Locked;
                    }
                    else
                    {
                        _display.CloseDoorErrorMsg();
                    }

                    break;

                case LadeskabState.DoorOpen:
                    // Ignore
                    break;

                case LadeskabState.Locked:
                    // Check for correct ID
                    if (arg.Id == _oldId)
                    {
                        _chargeControl.StopCharge();
                        _door.UnlockDoor();

                        _log.logWrite(2, _oldId);
                        _display.UnlockDoorMsg();
                        
                        _state = LadeskabState.Available;
                    }
                    else
                    {
                        _display.UnlockDoorErrorMsg();

                    }

                    break;
            }
        }


        private void DoorOpenedHandler(object sender, EventArgs args)
        {
            _display.ConnectMsg();
            _state = LadeskabState.DoorOpen;
        }

        private void DoorClosedHandler(object sender, EventArgs args)
        {
            _display.RFIDMsg();
            _state = LadeskabState.Available;
        }
        // Her mangler de andre trigger handlere
    }
}
