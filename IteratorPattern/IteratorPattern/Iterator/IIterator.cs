using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern.Menu
{
    /// <summary>
    /// 自定义迭代器接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IIterator<T>
    {
        T Current { get; }

        bool MoveNext();

        void Reset();
    }
}
