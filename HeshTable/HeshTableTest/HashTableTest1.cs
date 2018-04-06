using Microsoft.VisualStudio.TestTools.UnitTesting;
using HeshTable;

namespace HashTableTest
{
    [TestClass]
    public class HashTableTest1
    {
        [TestMethod]
        public void TestThreeElements()
        {
            string[] value = new string[] { "один", "два", "три" };
            var table = new HashTable(3);
            table.PutPair(1, value[0]);
            table.PutPair(2, value[1]);
            table.PutPair(3, value[2]);
            Assert.AreEqual(table.GetValueByKey(1), value[0]);
            Assert.AreEqual(table.GetValueByKey(2), value[1]);
            Assert.AreEqual(table.GetValueByKey(3), value[2]);

        }
        [TestMethod]
        public void Test2EqualElements()
        {
            string[] value = new string[] { "один", "два" };
            var table = new HashTable(3);
            table.PutPair(1, value[0]);
            table.PutPair(1, value[1]);
            Assert.AreEqual(table.GetValueByKey(1), value[1]);
        }

        [TestMethod]
        public void TestManyElements()
        {
            int size = 100000;
            var table = new HashTable(size);
            for (int i = 0; i < size; i++)
                table.PutPair(i, i + 1);
            Assert.AreEqual(table.GetValueByKey(70000), 70001);
        }


        [TestMethod]
        public void TestManySearchlElements()
        {
            int size = 100;
            var table = new HashTable(size);
            for (int i = 0; i < size; i++)
                table.PutPair(i, i + 1);
            for (int i = 0; i < size; i++)
            {
                Assert.AreEqual(table.GetValueByKey(i), i + 1);
            }
        }
    }
}

