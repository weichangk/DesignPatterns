using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern.IEnumerableIEnumerator
{
    //利用IEnumerable<T>和Yield实现一个泛型迭代器
    public class MyGenericArrayListYield<T> : IEnumerable<T>
    {
        T[] data;
        int currentIndex;

        public MyGenericArrayListYield(int length)
        {
            this.data = new T[length];
            currentIndex = 0;
        }

        public void Add(T s)
        {
            data[currentIndex++] = s;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        //可以看出GetEnumerator返回一个IEnumerator<T>类型，使用yield可以不用实现自己的IEnumerator<T>类：
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < data.Length; i++)
            {
                yield return data[i];
            }
        }
    }


    public class MyGenericArrayListYieldTest
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
