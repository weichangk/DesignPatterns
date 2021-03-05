using IteratorPattern.IEnumerableIEnumerator;
using IteratorPattern.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern
{
    /// <summary>
    /// 1 迭代器模式 Iterator
    /// 2 .net里面的迭代器模式  yield return
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                {
                    Console.WriteLine("***********************KFCMenu*********************");
                    KFCMenu menu = new KFCMenu();
                    Food[] foods = menu.GetFoods();
                    //遍历数组
                    for (int i = 0; i < foods.Length; i++)
                    {
                        Console.WriteLine("{0} {1} {2}￥", foods[i].Id, foods[i].Name, foods[i].Price);
                    }

                    //实现遍历自定义迭代器集合对象
                    IIterator<Food> iterator = menu.GetIterator();
                    while (iterator.MoveNext())
                    {
                        Food food = iterator.Current;
                        Console.WriteLine("{0} {1} {2}￥", food.Id, food.Name, food.Price);
                    }

                    //foreach (var item in foods)
                    //{
                    //    Console.WriteLine("{0} {1} {2}￥", item.Id, item.Name, item.Price);
                    //}
                }


                {
                    Console.WriteLine("***********************MacDonaldMenu*********************");
                    MacDonaldMenu menu = new MacDonaldMenu();
                    List<Food> foods = menu.GetFoods();
                    //遍历list集合
                    for (int i = 0; i < foods.Count; i++)
                    {
                        Console.WriteLine("{0} {1} {2}￥", foods[i].Id, foods[i].Name, foods[i].Price);
                    }

                    //实现遍历自定义迭代器集合对象
                    IIterator<Food> iterator = menu.GetIterator();
                    while (iterator.MoveNext())
                    {
                        Food food = iterator.Current;
                        Console.WriteLine("{0} {1} {2}￥", food.Id, food.Name, food.Price);
                    }



                    //foreach (var item in foods)
                    //{
                    //    Console.WriteLine("{0} {1} {2}￥", item.Id, item.Name, item.Price);
                    //}

                    //// 使用foreach的条件是 类型包含public IEnumerator GetEnumerator()，可以不继承IEnumerable ！！！！
                    //Food food1 = new Food();
                    //foreach (var item in food1)
                    //{
                    //}


                }



                {
                    Console.WriteLine("***********************利用IEnumerable和IEnumerator接口。并实现一个非泛型迭代器测试***********************");
                    MyArrayListTest.Test();
                }

                {
                    Console.WriteLine("***********************利用IEnumerable<T>和IEnumerator<T>接口。并实现一个泛型迭代器测试***********************");
                    MyGenericArrayListTest.Test();
                }

                {
                    Console.WriteLine("***********************Yield测试***********************");
                    YieldShow show = new YieldShow();
                    show.Show();
                }

                {
                    Console.WriteLine("***********************Yield测试1***********************");
                    YieldShow1.Show();
                }

                {
                    Console.WriteLine("***********************利用IEnumerable<T>和Yield。并实现一个泛型迭代器测试***********************");
                    MyGenericArrayListYieldTest.Test();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
