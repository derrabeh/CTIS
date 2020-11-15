using System;
using System.Collections.Generic;
using System.Text;

namespace CTIS.Model
{
    public class User
    {
        public string UserID { get; set; } //auto-generated
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Passport { get; set; }
        public string Type { get; set; }
        //if user is initialized from Register page, user type is automatically Patient
        //new center officers must be registered by another existing officer 

        //Patient types: returnee, quarantined, close contact, infected, suspected
        //Officer positions: tester, manager 
    }
}
