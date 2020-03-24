
using System;

namespace Ladeskab
{
	public class ChargeControl : IChargeControl
	{
		
		private IUsbCharger _usbCharger;
		private IDisplay _display;
		
		public ChargeControl(IUsbCharger usbCharger, IDisplay display)
		{
			_usbCharger = usbCharger;
			_display = display;
			usbCharger.CurrentValueEvent += CurrentValueEventHandler;
		}
		
		private void CurrentValueEventHandler(object sender, CurrentEventArgs args)
		{
			double current = args.Current;

			if (current == 0)
				_display.ConnectMsg();
			else if (current > 0 && current <= 5)
				_display.Fullycharged();
			else if (current > 5 && current <= 500)
				_display.Charging();
			else if (current > 500)
				_display.ErrorMsgCharge();
		}
		
		public bool IsConnected()
		{
			return _usbCharger.Connected;
		}
		
		public void StartCharge()
		{
			_usbCharger.StartCharge();
		}
		
		public void StopCharge()
		{
			_usbCharger.StopCharge();
		}
	}
}