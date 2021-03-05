using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern
{
    /*
     调用上面的Power方法，不会执行函数的主体，而是返回一个IEnumerable<int>对象，
     在foreach中，调用MoveNext来进行遍历，这时函数开始执行，知道碰到yield，后面返回的对象就是Current属性的值。
     下次调用MoveNext的时候，会从上个yield的地方继续往后执行。
     */
    public class YieldShow1
    {
        public static void Show()
        {
            // Display powers of 2 up to the exponent of 8:
            foreach (int i in Power(2, 8))
            {
                Console.Write("{0} ", i);
            }
        }

        public static System.Collections.Generic.IEnumerable<int> Power(int number, int exponent)
        {
            int result = 1;

            for (int i = 0; i < exponent; i++)
            {
                result = result * number;
                yield return result;
            }
        }
    }
}
