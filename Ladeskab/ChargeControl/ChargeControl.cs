
using System;

namespace Ladeskab
{
	public class ChargeControl : IChargeControl
	{
		
		private IUsbCharger _usbCharger;
		//private IDisplay _display;
		
		public ChargeControl(IUsbCharger usbCharger/*, IDisplay display*/)
		{
			_usbCharger = usbCharger;
			//_display = display;
			usbCharger.CurrentValueEvent += CurrentValueEventHandler;
		}
		
		private void CurrentValueEventHandler(object sender, CurrentEventArgs args)
		{
			// TODO: display charging status
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