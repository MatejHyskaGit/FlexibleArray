using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyska_Dynamic_List
{
    public class FlexArray : IEnumerable, IFlexArray
    {
        protected object[] _array = new object[0];

        public int Count
        {
            get
            {
                int cnt = 0;
                for (int i = 0; i < Length; i++)
                {
                    if (_array[i] != null) cnt++;
                }
                return cnt;
            }
        }

        public int Length { get { return _array.Length; } }

        public void Add(object o)
        {
            Resize(ref _array, Length + 1);
            Set(Length-1, o);
        }

        public object Get(int index)
        {
            if (index < 0 || index > _array.Length) throw new ArgumentOutOfRangeException("Index nesmí být větší nebo menší než pole");
            return _array[index];
        }

        public string GetAll()
        {
            string output = "";
            foreach (var i in _array)
            {
                output += (i + ", ");
            }
            return output;
        }

        public IEnumerator GetEnumerator()
        {
            return _array.GetEnumerator();
        }

        public int IndexOf(object o)
        {
            for (var i = 0; i < Length; i++)
            {
                //Console.WriteLine(i+  "  Index");
                //Console.WriteLine(o + "  Object");
                if (object.Equals(o, Get(i)))
                {
                    return i;
                }

            }
            throw new ArgumentException("Objekt " + o + " se v array nenachazi");
        }

        public void Set(int index, object o)
        {
            if (index < 0 || index > _array.Length) throw new ArgumentOutOfRangeException("Index nesmí být větší nebo menší než pole");
            _array[index] = o;
        }

        public void SetMove(int index, object o)
        {
            ShiftItemsUp(index);
            Set(index, o);
        }

        public void ClearValue(object o)
        {
            Set(IndexOf(o), null);
        }

        public void ClearIndex(int index)
        {
            Set(index, null);
        }

        public void RemoveValue(object o)
        {
            int x = IndexOf(o);
            ShiftItemsDown(x + 1);
        }

        public void RemoveIndex(int index)
        {
            ShiftItemsDown(index + 1);
        }

        protected void Resize(ref object[] old, int newSize)
        {
            if (newSize < 0) throw new ArgumentOutOfRangeException("Pole nemůže mít zápornou velikost");
            object[] newArray = new object[newSize];
            for (int i = 0; i < Math.Min(old.Length, newSize); i++)
            {
                newArray[i] = old[i];
            }
            old = newArray;
        }

        public void ShiftItemsUp(int index, int size = 1)
        {
            Resize(ref _array, _array.Length + size);
            //Console.WriteLine(this.Length + "   delka po resize");
            //Console.WriteLine(this.GetAll() + "   array po resize");
            object temp1 = Get(index);
            object temp2;
            for (var i = index; i < _array.Length - 1; i++)
            {

                temp2 = Get(i + 1);
                Set(i + 1, temp1);
                temp1 = temp2;

            }

        }

        public void ShiftItemsDown(int index, int size = 1)
        {
            //Console.WriteLine(index + "index");
            if (index < 0 || index >= Length+1)
            {
                throw new ArgumentOutOfRangeException("Out of range");
            }

            for (int i = index; i < _array.Length; i += 1)
            {
                //Console.WriteLine(i);
                //Console.WriteLine(i - 1);
                Set(i - 1, Get(i));
            }
            Resize(ref _array, _array.Length - size);
        }

        public override string ToString()
        {
            return "Flexible Array";
        }
    }
}
