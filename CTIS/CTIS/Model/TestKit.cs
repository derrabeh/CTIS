using CTIS.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTIS.Model
{
    public class TestKit : BaseVM
    {
        public string KitID { get; set; }
        public string KitName { get; set; }
        public string CurrentStock { get; set; } //available stock 
        public DateTime LastUpdated { get; set; }
        public string Status { get; set; }

        private bool isVisible;
        public bool IsVisible
        {
            get { return isVisible; }
            set { SetField(ref isVisible, value); }
        }
    }
}
