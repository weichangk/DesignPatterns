using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern.IEnumerableIEnumerator
{
    //利用IEnumerable<T>和IEnumerator<T>接口。并实现一个泛型迭代器
    public class MyGenericArrayList<T> : IEnumerable<T>
    {
        T[] data;
        int currentIndex;

        public MyGenericArrayList(int length)
        {
            this.data = new T[length];
            currentIndex = 0;
        }

        public void Add(T s)
        {
            data[currentIndex++] = s;
        }

        //可以看出GetEnumerator返回一个IEnumerator<T>类型，所以我们就必须要去实现自己的IEnumerator<T>类：
        public IEnumerator<T> GetEnumerator()
        {
            return new MyGenericEnumerator<T>(data);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
    public class MyGenericEnumerator<T> : IEnumerator<T>
    {
        private T[] _data;
        private int position = -1;

        public MyGenericEnumerator(T[] data)
        {
            _data = data;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _data.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public T Current
        {
            get
            {
                return _data[position];
            }
        }
    }

    public class MyGenericArrayListTest
    {
        public static void Test()
        {
            MyArrayList array = new MyArrayList(10);
            array.Add("Jack");
            array.Add("Tom");
            foreach (object i in array)
            {
                Console.WriteLine(i);
            }
        }
    }
}
