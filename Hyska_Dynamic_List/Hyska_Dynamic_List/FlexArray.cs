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
            _array[Length - 1] = o;
        }

        public object Get(int index)
        {
            if (index < 0 || index > _array.Length) throw new ArgumentOutOfRangeException("Index nesmí být větší nebo menší než pole");
            return _array[index];
        }

        public object[] GetAll()
        {
            return _array;
        }

        public IEnumerator GetEnumerator()
        {
            return _array.GetEnumerator();
        }

        int index;
        public int IndexOf(object o)
        {
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] == o)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public void Set(int index, object o)
        {
            if (index < 0 || index > _array.Length) throw new ArgumentOutOfRangeException("Index nesmí být větší nebo menší než pole");
            _array[index] = o;
        }

        public void SetMove(ref object[] array, int index, object o)
        {
            if (index < 0 || index > array.Length) throw new ArgumentOutOfRangeException("Index nesmí být větší nebo menší než pole");
            Resize(ref array, Length + 1);
            for(int i = 0; i < array.Length; i++)
            {
                if(i >= index)
                {
                    _array[i] = array[i + 1];
                }
            }
            _array[index] = o;
        }

        public void ClearValue(object o)
        {
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] == o)
                {
                    _array[i] = null;
                    continue;
                }
            }
        }

        public void ClearIndex(int index)
        {
            if (index < 0 || index > _array.Length) throw new ArgumentOutOfRangeException("Index nesmí být větší nebo menší než pole");
            _array[index] = null;
        }

        public void RemoveIndex(int index)
        {
            if (index < 0 || index > _array.Length) throw new ArgumentOutOfRangeException("Index nesmí být větší nebo menší než pole");
            _array[index] = null;
            for (int i = 0; i < _array.Length; i++)
            {
                if (i > index)
                {
                    _array[i - 1] = _array[i];
                }
            }

            int newSize = (_array.Length - 1);
            object[] newArray = new object[newSize];
            for (int i = 0; i < Math.Min(_array.Length, newSize); i++)
            {
                newArray[i] = _array[i];
            }
            _array = newArray;
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
    }
}
