using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Ladeskab.Tests
{
	class TestChargeControl
	{
		UsbChargerMock usbChargerMock;
		DisplayMock displayMock;
		ChargeControl _uut;

		[SetUp]
		public void Setup()
		{
			usbChargerMock = new UsbChargerMock();
			displayMock = new DisplayMock();
			_uut = new ChargeControl(usbChargerMock, displayMock);
		}

		[TestCase(true)]
		[TestCase(false)]
		public void TestIsConnected(bool state)
		{
			usbChargerMock.Connected = state;
			Assert.IsTrue(_uut.IsConnected() == state);
		}

		[Test]
		public void TestStartCharge()
		{
			_uut.StartCharge();
			Assert.AreEqual(1, usbChargerMock.StartChargeCalls);
		}

		[Test]
		public void TestStopCharge()
		{
			_uut.StopCharge();
			Assert.AreEqual(1, usbChargerMock.StopChargeCalls);
		}

		[Test]
		public void TestChargeMessageDisconnected()
		{
			usbChargerMock.CurrentValue = 0;
			usbChargerMock.FireCurrentEvent();
			Assert.AreEqual(1, displayMock.ConnectMsgCalls);
			Assert.AreEqual(0, displayMock.ChargingCalls);
			Assert.AreEqual(0, displayMock.FullychargedCalls);
			Assert.AreEqual(0, displayMock.ErrorMsgChargeCalls);
		}

		[TestCase(1.0)]
		[TestCase(2.5)]
		[TestCase(5.0)]
		public void TestChargeMessageFullyCharged(double current)
		{
			usbChargerMock.CurrentValue = current;
			usbChargerMock.FireCurrentEvent();
			Assert.AreEqual(0, displayMock.ConnectMsgCalls);
			Assert.AreEqual(0, displayMock.ChargingCalls);
			Assert.AreEqual(1, displayMock.FullychargedCalls);
			Assert.AreEqual(0, displayMock.ErrorMsgChargeCalls);
		}

		[TestCase(100.0)]
		[TestCase(500.0)]
		[TestCase(5.1)]
		public void TestChargeMessageCharging(double current)
		{
			usbChargerMock.CurrentValue = current;
			usbChargerMock.FireCurrentEvent();
			Assert.AreEqual(0, displayMock.ConnectMsgCalls);
			Assert.AreEqual(1, displayMock.ChargingCalls);
			Assert.AreEqual(0, displayMock.FullychargedCalls);
			Assert.AreEqual(0, displayMock.ErrorMsgChargeCalls);
		}

		[TestCase(2000.0)]
		[TestCase(500.1)]
		[TestCase(10000000000.0)]
		public void TestChargeMessageError(double current)
		{
			usbChargerMock.CurrentValue = current;
			usbChargerMock.FireCurrentEvent();
			Assert.AreEqual(0, displayMock.ConnectMsgCalls);
			Assert.AreEqual(0, displayMock.ChargingCalls);
			Assert.AreEqual(0, displayMock.FullychargedCalls);
			Assert.AreEqual(1, displayMock.ErrorMsgChargeCalls);
		}



	}

	class UsbChargerMock : IUsbCharger
	{
		public int StartChargeCalls, StopChargeCalls;
		public UsbChargerMock()
		{
			ResetCounters();
		}
		public void ResetCounters()
		{
			StartChargeCalls = 0;
			StopChargeCalls = 0;
		}

		public double CurrentValue { get; set; }
		public bool Connected { get; set; }
		public event EventHandler<CurrentEventArgs> CurrentValueEvent;
		public void FireCurrentEvent()
		{
			CurrentValueEvent?.Invoke(this, new CurrentEventArgs() { Current = this.CurrentValue });
		}

		public void StartCharge()
		{
			StartChargeCalls++;
		}

		public void StopCharge()
		{
			StopChargeCalls++;
		}
	}

	class DisplayMock : IDisplay
	{
		public int
			ChargingCalls,
			CloseDoorErrorMsgCalls,
			CloseDoorMsgCalls,
			ConnectMsgCalls,
			ErrorMsgChargeCalls,
			FullychargedCalls,
			RFIDMsgCalls,
			UnlockDoorErrorMsgCalls,
			UnlockDoorMsgCalls;

		public DisplayMock()
		{
			ResetCounters();
		}

		public void ResetCounters()
		{
			ChargingCalls			= 0;
			CloseDoorErrorMsgCalls	= 0;
			CloseDoorMsgCalls		= 0;
			ConnectMsgCalls			= 0;
			ErrorMsgChargeCalls		= 0;
			FullychargedCalls		= 0;
			RFIDMsgCalls			= 0;
			UnlockDoorErrorMsgCalls	= 0;
			UnlockDoorMsgCalls		= 0;
		}

		public void Charging()
		{
			ChargingCalls++;
		}

		public void CloseDoorErrorMsg()
		{
			CloseDoorErrorMsgCalls++;
		}

		public void CloseDoorMsg()
		{
			CloseDoorMsgCalls++;
		}

		public void ConnectMsg()
		{
			ConnectMsgCalls++;
		}

		public void ErrorMsgCharge()
		{
			ErrorMsgChargeCalls++;
		}

		public void Fullycharged()
		{
			FullychargedCalls++;
		}

		public void RFIDMsg()
		{
			RFIDMsgCalls++;
		}

		public void UnlockDoorErrorMsg()
		{
			UnlockDoorErrorMsgCalls++;
		}

		public void UnlockDoorMsg()
		{
			UnlockDoorMsgCalls++;
		}
	}
}
