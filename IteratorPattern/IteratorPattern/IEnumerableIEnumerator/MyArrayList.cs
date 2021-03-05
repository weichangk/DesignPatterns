using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern.IEnumerableIEnumerator
{
    //利用IEnumerable和IEnumerator接口。并实现一个非泛型迭代器
    public class MyArrayList : IEnumerable
    {
        object[] data;
        int currentIndex;

        public MyArrayList(int length)
        {
            this.data = new object[length];
            currentIndex = 0;
        }

        public void Add(object s)
        {
            data[currentIndex++] = s;
        }

        //可以看出GetEnumerator返回一个IEnumerator类型，所以我们就必须要去实现自己的IEnumerator类：
        public IEnumerator GetEnumerator()
        {
            return new MyEnumerator(data);
        }

       
    }
    public class MyEnumerator : IEnumerator
    {
        private object[] _data;
        private int position = -1;

        public MyEnumerator(object[] data)
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

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public object Current
        {
            get
            {
                return _data[position];
            }
        }
    }

    public class MyArrayListTest
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
