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
        public string Type { get; set; }  //tester, manager, officer, patient
        public string Symtoms { get; set; } //returnee, quarantined, close contact, infected, suspected


    }
}
