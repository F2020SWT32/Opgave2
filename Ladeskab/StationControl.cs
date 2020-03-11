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
        private enum LadeskabState
        {
            Available,
            Locked,
            DoorOpen
        };

        // Her mangler flere member variable
        private LadeskabState _state;
        private Display _display;
        private Log _log;
        private ChargeControl _chargeControl;
        private int _oldId;
        private Door _door;
        private RfidReader _reader;


        StationControl(IDisplay _display, ILog _log, IChargeControl _chargecontrol, IDoor _door, IRfidReader _reader)
        {
            this._display = _display;
            this._log = _log;
            this._chargeControl = _chargeControl;
            this._door = _door;
            _door.DoorOpened += DoorOpenedHandler;
            _door.DoopClosed += DoorClosedHandler;
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
                    if (_chargecontrol.isConnected())
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
                        _charger.StopCharge();
                        _door.UnlockDoor();

                        _log.writeLog(2, _oldId);
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


        private void OpenDoorHandler(object sender)
        {
            _display.ConnectMsg();
            LadeskabState.DoorOpen;
        }

        private void ClosedDoorHandler(object sender)
        {
            _display.RFIDMsg();
            LadeskabState.Available;
        }
        // Her mangler de andre trigger handlere
    }
}
