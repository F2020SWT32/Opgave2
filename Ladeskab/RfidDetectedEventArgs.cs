
using System;

namespace Ladeskab
{
	public class RfidDetectedEventArgs : EventArgs
	{
		public int Id { get; }
		public RfidDetectedEventArgs(int Id)
		{
			this.Id = Id;
		}
	}
}
