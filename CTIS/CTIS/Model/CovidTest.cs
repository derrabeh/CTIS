using System;
using System.Collections.Generic;
using System.Text;

namespace CTIS.Model
{
    public class CovidTest
    {
        public string TestID { get; set; }
        public string PatientName { get; set; } //how to link to a patient instance...? 
        public DateTime TestDate { get; set; }
        public string Result { get; set; } //Positive, Negative 
        public DateTime ResultDate { get; set; }
        public string Status { get; set; } //Pending, Complete, Under review
        public string TestedBy { get; set; }
        //test.TestedBy = App.User.Name;  
        //^ logs the name of tester who recorded this test 
    }
}
