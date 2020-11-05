using System;
using System.Collections.Generic;
using System.Text;
using Telephony.Interfaces;

namespace Telephony.Models
{
    public class StationaryPhone : ICalling
    {
        public StationaryPhone()
        {
                
        }

        public StationaryPhone(string callnumber)
        {
            this.CallNumger = callnumber;
            
        }
        public string CallNumger { get; set; }


        
        public string Call(string PhoneNumber)
        {
            return $"Dialing... {PhoneNumber}";
        }
    }
}
