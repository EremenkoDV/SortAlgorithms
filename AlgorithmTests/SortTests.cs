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
            for (int i = 0; i < 10; i++)
            {
                items.Add(rnd.Next(0, 10));
            }

            sorted.Clear();
            sorted.AddRange(items.OrderBy(x => x).ToList());
        }

        [TestMethod()]
        public void BaseSortTest()
        {
            // arrange
            AlgorithmBase<int> _base = new AlgorithmBase<int>(items);

            // act
            _base.SortAndGetSpan();

            // assert
            for (int i = 0; i < items.Count; i++)
            {
                Assert.AreEqual(sorted[i], _base.Items[i]);
            }
        }

        [TestMethod()]
        public void BubbleSortTest()
        {
            // arrange
            AlgorithmBase<int> bubble = new BubbleSort<int>(items);

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
            AlgorithmBase<int> cocktail = new CocktailSort<int>(items);

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
            AlgorithmBase<int> insertion = new InsertionSort<int>(items);

            // act
            insertion.SortAndGetSpan();

            // assert
            for (int i = 0; i < items.Count; i++)
            {
                Assert.AreEqual(sorted[i], insertion.Items[i]);
            }
        }

        [TestMethod()]
        public void ShellSortTest()
        {
            // arrange
            AlgorithmBase<int> shell = new ShellSort<int>(items);

            // act
            shell.SortAndGetSpan();

            // assert
            for (int i = 0; i < items.Count; i++)
            {
                Assert.AreEqual(sorted[i], shell.Items[i]);
            }
        }

        [TestMethod()]
        public void TreeSortTest()
        {
            // arrange
            AlgorithmBase<int> tree = new DataStructures.Tree<int>(items);
            //tree.Items.AddRange(items);

            // act
            tree.SortAndGetSpan();

            // assert
            for (int i = 0; i < items.Count; i++)
            {
                Assert.AreEqual(sorted[i], tree.Items[i]);
            }
        }

        [TestMethod()]
        public void HeapSortTest()
        {
            // arrange
            AlgorithmBase<int> heap = new DataStructures.Heap<int>(items, false);

            // act
            heap.SortAndGetSpan();

            // assert
            for (int i = 0; i < items.Count; i++)
            {
                Assert.AreEqual(sorted[i], heap.Items[i]);
            }
        }

        [TestMethod()]
        public void SelectionSortTest()
        {
            // arrange
            AlgorithmBase<int> selection = new SelectionSort<int>(items);

            // act
            selection.SortAndGetSpan();

            // assert
            for (int i = 0; i < items.Count; i++)
            {
                Assert.AreEqual(sorted[i], selection.Items[i]);
            }
        }

    }
}