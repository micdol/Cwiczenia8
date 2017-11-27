using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwiczenia8
{
    class ListModificationArgs : EventArgs
    {
        public readonly int hour;
        public readonly int minute;
        public readonly int second;
        public readonly ArrayList changedElements;

        public ListModificationArgs(DateTime dt, ArrayList elmts)
        {
            GetTimes(dt, out hour, out minute, out second);
            changedElements = elmts;
        }

        public ListModificationArgs(int h, int m, int s, ArrayList elmts)
        {
            hour = h;
            minute = m;
            second = s;
            changedElements = elmts;
        }

        public static void GetTimes(DateTime dt, out int hour, out int minute, out int second)
        {
            hour = dt.Hour;
            minute = dt.Minute;
            second = dt.Second;
        }

        public override string ToString()
        {
            string str = string.Format("Event fired at: {0:00}h {1:00}min {2:00}sec\r\nElements changed:\r\n", hour, minute, second);
            foreach(int i in changedElements)
            {
                str += string.Format("item {0},\r\n", i);
            }
            return str;
        }
    }
}
