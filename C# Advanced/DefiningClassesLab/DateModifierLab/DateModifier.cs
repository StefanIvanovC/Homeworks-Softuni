using System;
using System.Collections.Generic;

using System.Text;

namespace DateModifier
{
    public class DateModifier
    {
        public int GetDaysDifference(string start, string end)
        {
            DateTime startD = DateTime.Parse(start);
            DateTime endD = DateTime.Parse(end);
            
            

            var totalDiference = (int)(endD - startD).TotalDays;


            return totalDiference;


        }


    }
}
