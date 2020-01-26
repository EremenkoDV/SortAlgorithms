using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Tests
{
    [TestClass()]
    public class InsertionSortTests
    {
        [TestMethod()]
        public void SortTest()
        {
            // arrange
            InsertionSort<int> insertion = new InsertionSort<int>();

            Random rnd = new Random();
            List<int> items = new List<int>();
            for (int i = 0; i < 10000; i++)
            {
                items.Add(rnd.Next(0, 100));
            }
            insertion.Items.AddRange(items);
            List<int> sorted = items.OrderBy(x => x).ToList();

            //cocktail.IsAscending = false;

            // act
            insertion.SortAndGetSpan();

            // assert
            for (int i = 0; i < items.Count; i++)
            {
                Assert.AreEqual(sorted[i], insertion.Items[i]);
            }

        }
    }
}