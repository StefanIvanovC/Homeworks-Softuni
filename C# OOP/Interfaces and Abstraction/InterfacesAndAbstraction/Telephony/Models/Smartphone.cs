using System;
using System.Collections.Generic;
using System.Text;
using Telephony.Interfaces;

namespace Telephony.Models
{
    public class Smartphone : ICalling
    {

        public Smartphone()
        {

        }
        public Smartphone(string url)
        {
            this.Url = url;
        }

        public Smartphone(string callnumber, string url)
        {
            this.CallNumger = callnumber;
            this.Url = url;
        }
        public string CallNumger { get; set; }
        public string Url { get; set; }

        public string Call(string PhoneNumber)
        {
            return $"Calling... {PhoneNumber}";
        }

        public string Browse(string url)
        {
            return $"Browsing: {url}";
        }
    }
}


