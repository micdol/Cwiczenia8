using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwiczenia8
{
    class ListListenerSaveToFile
    {
        private const string FILENAME = "log.log";
        private FileStream fileStream;
        private StreamWriter streamWriter;

        public ListListenerSaveToFile(string filename)
        {
            if(filename == null || filename == "")
            {
                filename = FILENAME;
            }
            fileStream  = new FileStream(filename, FileMode.Create);
            streamWriter = new StreamWriter(fileStream);            
        }

        public void Subscribe(ListWithNotifications list)
        {
            list.ListModified += new ListWithNotifications.ListModificationHandler(SaveToFile);
        }

        public void Unsubscribe(ListWithNotifications list)
        {
            list.ListModified -= new ListWithNotifications.ListModificationHandler(SaveToFile);
        }

        public void SaveToFile(object list, ListModificationArgs modifyInfo)
        {
            streamWriter.WriteLine(modifyInfo.ToString());
            streamWriter.WriteLine("-------------------------");
            streamWriter.Flush();
        }
    }
}
