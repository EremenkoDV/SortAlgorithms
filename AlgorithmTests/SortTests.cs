﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            for (int i = 0; i < 100000; i++)
            {
                items.Add(rnd.Next(0, 1000));
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
            AlgorithmBase<int> heap = new DataStructures.Heap<int>(items);

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

        [TestMethod()]
        public void GnomeSortTest()
        {
            // arrange
            AlgorithmBase<int> gnome = new GnomeSort<int>(items);

            // act
            gnome.SortAndGetSpan();

            // assert
            for (int i = 0; i < items.Count; i++)
            {
                Assert.AreEqual(sorted[i], gnome.Items[i]);
            }
        }

        [TestMethod()]
        public void RadixSortTest()
        {
            // arrange
            //items.Clear();
            //List<int> items = new List<int> { 57, 7, 471, 359, 311, 1552, 730, 77, 311, 74234, 87, 419, 359 };
            //List<string> items = new List<string> { "EA57", "17", "71", "tyw11", "71y", "tyw116", "5f5", "30", "6fdg7", "74fgjj", "87", "g49k" };
            //AlgorithmBase<string> radix = new RadixSort<string>(items, true);
            AlgorithmBase<int> radix = new RadixSort<int>(items, false);

            // act
            radix.SortAndGetSpan();

            // assert
            for (int i = 0; i < items.Count; i++)
            {
                Assert.AreEqual(sorted[i], radix.Items[i]);
            }
        }

        [TestMethod()]
        public void MergeSortTest()
        {
            // arrange
            AlgorithmBase<int> merge = new MergeSort<int>(items);

            // act
            merge.SortAndGetSpan();

            // assert
            for (int i = 0; i < items.Count; i++)
            {
                Assert.AreEqual(sorted[i], merge.Items[i]);
            }
        }

        [TestMethod()]
        public void QuickSortTest()
        {
            // arrange
            //List<int> items = new List<int> { 57, 7, 471, 359, 311, 1552, 730, 77, 311, 74234, 87, 419, 359 };
            AlgorithmBase<int> quick = new BadQuickSort<int>(items);

            // act
            quick.SortAndGetSpan();

            // assert
            for (int i = 0; i < items.Count; i++)
            {
                Assert.AreEqual(sorted[i], quick.Items[i]);
            }
        }

        [TestMethod()]
        public void OddEvenSortTest()
        {
            // arrange
            //List<int> items = new List<int> { 57, 7, 471, 359, 311, 1552, 730, 77, 311, 74234, 87, 419, 359 };
            AlgorithmBase<int> oddEven = new OddEvenSort<int>(items);

            // act
            oddEven.SortAndGetSpan();

            // assert
            for (int i = 0; i < items.Count; i++)
            {
                Assert.AreEqual(sorted[i], oddEven.Items[i]);
            }
        }

        [TestMethod()]
        public void CombSortTest()
        {
            // arrange
            //List<int> items = new List<int> { 57, 7, 471, 359, 311, 1552, 730, 77, 311, 74234, 87, 419, 359 };
            AlgorithmBase<int> comb = new CombSort<int>(items);

            // act
            comb.SortAndGetSpan();

            // assert
            for (int i = 0; i < items.Count; i++)
            {
                Assert.AreEqual(sorted[i], comb.Items[i]);
            }
        }

        [TestMethod()]
        public void QuickSort2Test()
        {
            // arrange
            //List<int> items = new List<int> { 57, 7, 471, 359, 311, 1552, 730, 77, 311, 74234, 87, 419, 359 };
            AlgorithmBase<int> quick2 = new QuickSort<int>(items);

            // act
            quick2.SortAndGetSpan();

            // assert
            for (int i = 0; i < items.Count; i++)
            {
                Assert.AreEqual(sorted[i], quick2.Items[i]);
            }
        }

    }
}