using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwiczenia8
{
    class ListListenerDisplayChanges
    {

        public void Subscribe(ListWithNotifications list)
        {
            list.ListModified += new ListWithNotifications.ListModificationHandler(DisplayOnConsole);
        }

        public void Unsubscribe(ListWithNotifications list)
        {
            list.ListModified -= new ListWithNotifications.ListModificationHandler(DisplayOnConsole);
        }

        public void DisplayOnConsole(object list, ListModificationArgs modifyInfo)
        {            
            Console.WriteLine(modifyInfo.ToString());
            Console.WriteLine("-------------------------");
        }


    }
}
