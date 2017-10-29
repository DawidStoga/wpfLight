using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.OOP
{
    class ClassEnumerable : IEnumerable, IEnumerator
    {

        int[] array;
        public ClassEnumerable()
        {
            array = new int[] { 1, 2, 3, 5 };
        }

        public object Current
        {
            get
            {
                throw new NotImplementedException();
            }
        }

       IEnumerator IEnumerable.GetEnumerator()
        {
            //return array.GetEnumerator();
              return GetEnumerator();  //z Yield return
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
          foreach(var t in array)
            {
                yield return t;
            }
        }
        public IEnumerable GetInt(bool reverse)
        {
            foreach (var t in array.Reverse())
                yield return t;
        }
    }

    class ClassEnumerableT<T> : IEnumerable<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
