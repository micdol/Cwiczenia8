using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cwiczenia8
{
    class Program
    {
        static void Main(string[] args)
        {
            ListWithNotifications list = new ListWithNotifications();
            
            ListListenerDisplayChanges displayListener = new ListListenerDisplayChanges();
            displayListener.Subscribe(list);

            ListListenerSaveToFile logListener = new ListListenerSaveToFile("list.txt");
            logListener.Subscribe(list);

            list.Add(4);
            list.Add(23);
            list.Add(44);

            list[1] = 65;

            Thread.Sleep(1000);

            list.Clear();

            displayListener.Unsubscribe(list);
            logListener.Unsubscribe(list);

            list.Add(17);

            Console.ReadKey();
        }
    }
}
