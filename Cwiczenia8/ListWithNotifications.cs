using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwiczenia8
{
    class ListWithNotifications : ArrayList
    {
        public delegate void ListModificationHandler(object list, ListModificationArgs modifyInfo);
        public event ListModificationHandler ListModified;

        public override int Add(object value) {
            var al = new ArrayList();
            al.Add(value);
            var lma = new ListModificationArgs(DateTime.Now, al);
            OnModify(lma);
            return base.Add(value);
        }

        public override void Clear() {
            var al = new ArrayList(this);
            var lma = new ListModificationArgs(DateTime.Now, al);
            OnModify(lma);
            base.Clear();
        }

        public override object this[int pos]
        {
            get
            {
                return base[pos];
            }
            set
            {
                var al = new ArrayList();
                al.Add(value);
                var lma = new ListModificationArgs(DateTime.Now, al);
                OnModify(lma);
                base[pos] = value;
            }
        }

        protected void OnModify(ListModificationArgs modifyInfo) {
            if (ListModified != null)
            {
                Console.WriteLine("This is called when event fires");
                ListModified(this, modifyInfo);
            }
        }


    }
}
