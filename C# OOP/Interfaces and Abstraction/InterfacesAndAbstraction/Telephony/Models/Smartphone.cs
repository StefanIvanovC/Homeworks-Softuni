using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telephony.Interfaces;

namespace Telephony.Models
{
    public class Smartphone : ICalling , IBrowsing
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
            if (!PhoneNumber.All(x => char.IsDigit(x)))
            {
                return "Invalid number!";
            }
            return $"Calling... {PhoneNumber}";
        }

        public string Browse(string url)
        {
            if (url.Any(x => char.IsDigit(x)))
            {
                return "Invalid URL!";
            }
            return $"Browsing: {url}!";
        }
    }
}


