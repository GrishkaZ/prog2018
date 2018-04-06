using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickSort;

namespace UnitTestProject1
{
    [TestClass]
    public class QuickSortTest
    {
        [TestMethod]
        public void TestLitleArray()
        {
            bool test = true;
            int[] array = new[] { 4, 8, 3 };           
            QuickSorting.QuickSort(array, 0, array.Length - 1);
            if (array[0] > array[1] || array[1] > array[2])
                test = false;
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void TestSameNumberArray()
        {
            bool test = true;
            int[] array = new int [100];
            for (int i = 0; i < array.Length; i++)
                array[i] = 1;
            QuickSorting.QuickSort(array, 0, array.Length - 1);
            if (array[0] > array[array.Length - 1])
                test = false;
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void TestRandomArray()
        {
            bool test = true;
            int[] array = new int[1000];
            var rand = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i] = rand.Next(0, 999);
            QuickSorting.QuickSort(array, 0, array.Length - 1);
            /* полная проверка всего массива
             for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    test = false;
                    break;
                }
            }*/
            for (int i = 0; i < 10; i++)
            {
                var a = rand.Next(0, 998);
                if (array[a] > array[a + 1])
                {
                    test = false;
                    break;
                }
            }
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void TestEmptyArray()
        {
            bool test = true;
            int[] array = new int[0];           
            QuickSorting.QuickSort(array, 0, array.Length - 1);
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    test = false;
                    break;
                }
            }
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void TestBigArray()
        {
            bool test = true;
            int[] array = new int[150000000]; // 4гб оперативной памяти, процессор i3 
            var rand = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i] = rand.Next(0, 1499999);
            QuickSorting.QuickSort(array, 0, array.Length - 1);           
             for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    test = false;
                    break;
                }
            }           
            Assert.IsTrue(test);
        }
    }
}
