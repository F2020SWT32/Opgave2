using System;
using System.Collections.Generic;
using System.Text;

namespace Ladeskab
{
    public class Display
    {
        public string Msg { get; set; }
        
        public void ShowMsg()
        {
            Console.WriteLine(this.Msg);
        }

    }

    /*
    public class DisplayEventArgs : EventArgs
    {
        public Display Display { get; set; }
    }
    public class DisplayService
    {
        public EventHandler<DisplayEventArgs> DisplayShown;

        public void DisplayMessage(Display message)
        {
            Console.WriteLine(message.Msg);

            OnDisplayShown(message);
        }

        protected virtual void OnDisplayShown(Display message)
        {
            DisplayShown?.Invoke(this, new DisplayEventArgs() { Display = message });
        }
    }
    */
}
