using System;
using System.Collections.Generic;
using System.Text;

namespace CTIS.Model
{
    public class TestCentre
    {
        public string CentreID { get; set; }
        public string CentreName { get; set; }
        public string PhoneNum { get; set; }
        public TimeSpan OpeningTime { get; set; }
        public TimeSpan ClosingTime { get; set; }
        public string Address { get; set; }
    }
}
