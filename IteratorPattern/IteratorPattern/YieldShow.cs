using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern
{
    /// <summary>
    /// 含有yield的函数说明它是一个生成器，而不是普通的函数。
    /// 当程序运行到yield这一行时，该函数会返回值，并保存当前域的所有变量状态；
    /// 等到该函数下一次被调用时，会从上一次中断的地方开始执行，一直遇到下一个yield, 程序返回值, 并在此保存当前状态; 
    /// 如此反复，直到函数正常执行完成。
    /// </summary>
    public class YieldShow
    {
        public IEnumerable<int> CreateEnumerable()
        {
            try
            {
                Console.WriteLine("{0} CreateEnumerable()方法开始", DateTime.Now);
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("{0}开始 yield {1}", DateTime.Now, i);
                    yield return i;
                    Console.WriteLine("{0}yield 结束", DateTime.Now);
                    if (i == 4)
                    {
                        yield break;//直接终结迭代  4会出现的，，
                    }
                }
                Console.WriteLine("{0} Yielding最后一个值", DateTime.Now);
                yield return -1;
                Console.WriteLine("{0} CreateEnumerable()方法结束", DateTime.Now);
            }
            finally
            {
                Console.WriteLine("停止迭代！");
            }
        }

        /// <summary>
        /// MoveNext 检查是否存在  并设置current
        /// </summary>
        public void Show()
        {
            //直接迭代
            //foreach (var item in this.CreateEnumerable())
            //{
            //}

            //模拟foreach迭代
            IEnumerable<int> iterable = this.CreateEnumerable();//1 不会直接执行
            //IEnumerator iterator = iterable.GetEnumerator();
            IEnumerator<int> iterator = iterable.GetEnumerator();
            Console.WriteLine("开始迭代");
            while (true)
            {
                Console.WriteLine("调用MoveNext方法……");
                Boolean result = iterator.MoveNext();//2 正式开启CreateEnumerable
                Console.WriteLine("MoveNext方法返回的{0}", result);
                if (!result)
                {
                    break;
                }
                Console.WriteLine("获取当前值……");
                Console.WriteLine("获取到的当前值为{0}", iterator.Current);
            }

            Console.ReadKey();
        }
    }
}
