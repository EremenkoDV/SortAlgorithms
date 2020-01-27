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
    public class SortTests
    {

        Random rnd = new Random();
        List<int> items = new List<int>();
        List<int> sorted = new List<int>();

        [TestInitialize]
        public void Init()
        {
            items.Clear();
            for (int i = 0; i < 10000; i++)
            {
                items.Add(rnd.Next(0, 100));
            }

            sorted.Clear();
            sorted.AddRange(items.OrderBy(x => x).ToList());
        }

        [TestMethod()]
        public void BubbleSortTest()
        {
            // arrange
            BubbleSort<int> bubble = new BubbleSort<int>();

            //cocktail.IsAscending = false;
            bubble.Items.AddRange(items);

            // act
            bubble.SortAndGetSpan();

            // assert
            for (int i = 0; i < items.Count; i++)
            {
                Assert.AreEqual(sorted[i], bubble.Items[i]);
            }
        }

        [TestMethod()]
        public void CocktailSortTest()
        {
            // arrange
            CocktailSort<int> cocktail = new CocktailSort<int>();

            //cocktail.IsAscending = false;
            cocktail.Items.AddRange(items);

            // act
            cocktail.SortAndGetSpan();

            // assert
            for (int i = 0; i < items.Count; i++)
            {
                Assert.AreEqual(sorted[i], cocktail.Items[i]);
            }
        }

        [TestMethod()]
        public void InsertionSortTest()
        {
            // arrange
            InsertionSort<int> insertion = new InsertionSort<int>();

            //cocktail.IsAscending = false;
            insertion.Items.AddRange(items);

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