using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyska_Dynamic_List
{
    interface IFlexArray
    {
        public void Add(object o);
        public object Get(int index);
        public void Set(int index, object o);
        public int IndexOf(object o);
        public string GetAll();
        public int Count { get; }
        public int Length{ get; }
    }
}
