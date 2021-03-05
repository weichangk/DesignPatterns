using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern
{
    public class Food //: IEnumerable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        //使用foreach的条件是 类型包含public IEnumerator GetEnumerator()，可以不继承IEnumerable ！！！！
        //public IEnumerator GetEnumerator()
        //{
        //    throw new Exception();
        //    //返回一个迭代器
        //}
    }
}
