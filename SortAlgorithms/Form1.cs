﻿using Algorithm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortAlgorithms
{
    public partial class Form1 : Form
    {
        private List<SortedItem> items = new List<SortedItem>();

        private List<int> values = new List<int>();

        private string[,] allMethods = new int[12, 4];

        private int sortedItemsCount = 0;

        private int maxSortedItemsCount = 20;

        private int maxValue = 100;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            FillTextBox.Focus();

            allMethods[0, 0] = "Bubble Sort";
            allMethods[0, 1] = "Сложн.: O(n²)";
            allMethods[0, 2] = "1";
            allMethods[0, 3] = "1";

            allMethods[1, 0] = "Cocktail Sort";
            allMethods[1, 1] = "Сложн.: O(n²)";
            allMethods[1, 2] = "1";
            allMethods[1, 3] = "1";

            allMethods[2, 0] = "Gnome Sort";
            allMethods[2, 1] = "Сложн.: O(n²)";
            allMethods[2, 2] = "1";
            allMethods[2, 3] = "1";

            allMethods[3, 0] = "Quick Sort";
            allMethods[3, 1] = "Сложн.: O(n log n) - O(n²)";
            allMethods[3, 2] = "1";
            allMethods[3, 3] = "0";

            allMethods[4, 0] = "Comb Sort";
            allMethods[4, 1] = "Сложн.: O(n log n) - O(n²)";
            allMethods[4, 2] = "1";
            allMethods[4, 3] = "1";

            allMethods[5, 0] = "Gnome Sort";
            allMethods[5, 1] = "Сложн.: O(n²)";
            allMethods[5, 2] = "1";
            allMethods[5, 3] = "1";

            allMethods[6, 0] = "Gnome Sort";
            allMethods[6, 1] = "Сложн.: O(n²)";
            allMethods[6, 2] = "1";
            allMethods[6, 3] = "1";

            allMethods[7, 0] = "Gnome Sort";
            allMethods[7, 1] = "Сложн.: O(n²)";
            allMethods[7, 2] = "1";
            allMethods[7, 3] = "1";

            allMethods[8, 0] = "Gnome Sort";
            allMethods[8, 1] = "Сложн.: O(n²)";
            allMethods[8, 2] = "1";
            allMethods[8, 3] = "1";

            allMethods[9, 0] = "Gnome Sort";
            allMethods[9, 1] = "Сложн.: O(n²)";
            allMethods[9, 2] = "1";
            allMethods[9, 3] = "1";

            allMethods[10, 0] = "Gnome Sort";
            allMethods[10, 1] = "Сложн.: O(n²)";
            allMethods[10, 2] = "1";
            allMethods[10, 3] = "1";

            allMethods[11, 0] = "Gnome Sort";
            allMethods[11, 1] = "Сложн.: O(n²)";
            allMethods[11, 2] = "1";
            allMethods[11, 3] = "1";

            allMethods[2, 0] = "Gnome Sort";
            allMethods[2, 1] = "Сложн.: O(n²)";
            allMethods[2, 2] = "1";
            allMethods[2, 3] = "1";

            allMethods[2, 0] = "Gnome Sort";
            allMethods[2, 1] = "Сложн.: O(n²)";
            allMethods[2, 2] = "1";
            allMethods[2, 3] = "1";
            

            for (int i = 1; i <= allMethods.Length; i++)
            {
            }

            for (int i = 1; i <= 3; i++)
            {
                ResultTableLayoutPanel.Controls["TestsRadioButton_" + i.ToString()].Enabled = false;
            }
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            if (sortedItemsCount > 0)
            {
                (sender as Button).Enabled = false;

                int methods = 1;

                if (SpeedTrackBar.Value == 0)
                {
                    SpeedTrackBar.Enabled = false;
                    methods = allMethods.Length;
                    VisualPanel.Controls.Clear();
                }

                for (int methodNumber = 1; methodNumber <= methods; methodNumber++)
                {

                    Label label = new Label();
                    AlgorithmBase<SortedItem> algorithm = new AlgorithmBase<SortedItem>();

                    if (SpeedTrackBar.Value > 0)
                    {
                        foreach (RadioButton radioButton in panel3.Controls.OfType<RadioButton>())
                        {
                            if (radioButton.Checked)
                            {
                                if (!Int32.TryParse(radioButton.Name.Substring("radioButton".Length), out methodNumber))
                                {
                                    methodNumber = 1;
                                }
                                break;
                            }
                        }
                    }
                    else if (methodNumber > 1)
                    {
                        RefillItems(SpeedTrackBar.Value > 0);
                    }

                    switch (methodNumber)
                    {
                        case 1:
                            algorithm = new BubbleSort<SortedItem>();
                            break;
                        case 2:
                            algorithm = new CocktailSort<SortedItem>();
                            break;
                        case 3:
                            algorithm = new InsertionSort<SortedItem>();
                            break;
                        case 4:
                            algorithm = new ShellSort<SortedItem>();
                            break;
                        case 5:
                            algorithm = new Algorithm.DataStructures.Tree<SortedItem>();
                            break;
                        case 6:
                            algorithm = new Algorithm.DataStructures.Heap<SortedItem>();
                            break;
                        case 7:
                            algorithm = new SelectionSort<SortedItem>();
                            break;
                        case 8:
                            algorithm = new GnomeSort<SortedItem>();
                            break;
                        case 9:
                            algorithm = new RadixSort<SortedItem>(RadixSortCheckBox.Checked);
                            break;
                        case 10:
                            algorithm = new MergeSort<SortedItem>();
                            break;
                        case 11:
                            algorithm = new QuickSort<SortedItem>();
                            break;
                        default:
                            algorithm = new BubbleSort<SortedItem>();
                            break;
                    }
                    //MessageBox.Show("Вы выбрали метод сортировки " + radioButton.Text);

                    if (SpeedTrackBar.Value > 0)
                    {
                        algorithm.CompareEvent += AlgorithmCompareEvent;
                        algorithm.SwapEvent += AlgorithmSwapEvent;
                        algorithm.RemoveEvent += AlgorithmRemoveEvent;
                    }
                    else
                    {
                        label.Name = "label_" + methodNumber.ToString();
                        label.Text = "Идет сортировка массива из " + items.Count.ToString() + " элементов по методу " + panel3.Controls["radioButton" + methodNumber.ToString()].Text + " ...";
                        label.AutoSize = true;
                        label.Location = new Point(5, 15 * (methodNumber - 1));
                        VisualPanel.Controls.Add(label);
                        VisualPanel.Refresh();
                    }

                    if (reverseSortCheckBox.Checked)
                    {
                        algorithm.IsAscending = false;
                    }

                    algorithm.AddRange(items);
                    TimeSpan runTime = algorithm.SortAndGetSpan();

                    if (SpeedTrackBar.Value > 0 && methodNumber == 6)
                    {
                        VisualPanel.Controls.Clear();
                        sortedItemsCount = 0;
                        for (int i = 0; i < algorithm.Items.Count; i++)
                        {
                            SortedItem item = new SortedItem(VisualPanel, ++sortedItemsCount, algorithm.Items[i].Value);
                            VisualPanel.Refresh();
                        }
                        VisualPanel.Refresh();
                    }

                    label.Text = "Сортировка " + items.Count.ToString() + " элементов по методу " + panel3.Controls["radioButton" + methodNumber.ToString()].Text + " завершена.";

                    ResultTableLayoutPanel.Controls["label_" + methodNumber.ToString() + "1"].Text = runTime.Seconds.ToString() + "." + runTime.Milliseconds.ToString();
                    ResultTableLayoutPanel.Controls["label_" + methodNumber.ToString() + "2"].Text = algorithm.ComparisonCount.ToString();
                    ResultTableLayoutPanel.Controls["label_" + methodNumber.ToString() + "3"].Text = algorithm.SwapCount.ToString();

                    VisualPanel.Refresh();
                }

                SpeedTrackBar.Enabled = true;

                if (SpeedTrackBar.Value == 0)
                {
                    for (int i = 1; i <= 3; i++)
                    {
                        ResultTableLayoutPanel.Controls["TestsRadioButton_" + i.ToString()].Enabled = true;
                    }
                }

            }
        }

        private void AlgorithmCompareEvent(object sender, Tuple<SortedItem, SortedItem> e)
        {
            if (SpeedTrackBar.Value > 0)
            {
                e.Item1.SetColor(Color.Green);
                e.Item2.SetColor(Color.Yellow);

                VisualPanel.Refresh();

                System.Threading.Thread.Sleep(50 * SpeedTrackBar.Value - 1);

                e.Item1.SetColor(Color.Blue);
                e.Item2.SetColor(Color.Blue);

                VisualPanel.Refresh();
            }
        }

        private void AlgorithmSwapEvent(object sender, Tuple<SortedItem, SortedItem> e)
        {
            if (SpeedTrackBar.Value > 0)
            {
                e.Item1.SetColor(Color.Red);
                e.Item2.SetColor(Color.Red);

                VisualPanel.Refresh();

                SortedItem.SwapPosition(e.Item1, e.Item2);

                System.Threading.Thread.Sleep(50 * SpeedTrackBar.Value - 1);

                e.Item1.SetColor(Color.Blue);
                e.Item2.SetColor(Color.Blue);

                VisualPanel.Refresh();
            }
        }

        private void AlgorithmRemoveEvent(object sender, SortedItem e)
        {
            if (SpeedTrackBar.Value > 0)
            {
                e.SetColor(Color.Black);

                VisualPanel.Refresh();

                SortedItem.Remove(e);

                VisualPanel.Refresh();
            }
        }

        private void AddNumberButton_Click(object sender, EventArgs e)
        {

            if (int.TryParse(AddTextBox.Text, out int value) && value <= maxValue)
            {
                if (sortedItemsCount >= maxSortedItemsCount)
                {
                    VisualPanel.Controls.Clear();
                    sortedItemsCount = 0;
                    items.Clear();
                    values.Clear();
                }

                SortedItem item = new SortedItem(VisualPanel, ++sortedItemsCount, value);
                items.Add(item);
                values.Add(value);
            }
            AddTextBox.Text = "";
            AddTextBox.Focus();
        }

        private void FillRandomNumbersButton_Click(object sender, EventArgs e)
        {

            if (int.TryParse(FillTextBox.Text, out int numbers))
            {
                if (SpeedTrackBar.Value > 0 && numbers <= maxSortedItemsCount || SpeedTrackBar.Value == 0)
                {

                    int value;
                    Random rnd = new Random();
                    values.Clear();
                    for (int i = 0; i < numbers; i++)
                    {
                        value = rnd.Next(0, maxValue);
                        values.Add(value);
                    }
                    RefillItems(SpeedTrackBar.Value > 0);
                    FillTextBox.Text = "";
                    FillTextBox.Focus();
                }
            }
        }

        private void RefillItems(bool enableVisualization = true)
        {
            if (enableVisualization)
            {
                VisualPanel.Controls.Clear();
            }
            sortedItemsCount = 0;
            items.Clear();
            for (int i = 0; i < values.Count; i++)
            {
                if (enableVisualization)
                {
                    SortedItem item = new SortedItem(VisualPanel, ++sortedItemsCount, values[i]);
                    items.Add(item);
                    VisualPanel.Refresh();
                }
                else
                {
                    SortedItem item = new SortedItem(++sortedItemsCount, values[i]);
                    items.Add(item);
                }
            }
            //MessageBox.Show($"Количество items {items.Count} : {sortedItemsCount}");
            //VisualPanel.Refresh();
        }

        private void RadixSortCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender as CheckBox).Checked)
            {
                RadixSortCheckBox.Text = "LSD - с младшего разряда (числовая)";
            }
            else
            {
                RadixSortCheckBox.Text = "MSD - со старшего разряда (алфавитная)";
            }
            RefillItems(SpeedTrackBar.Value > 0);
            SortButton.Enabled = true;
        }

        private void reverseSortCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            RefillItems(SpeedTrackBar.Value > 0);
            SortButton.Enabled = true;
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                RadixSortCheckBox.Visible = (sender as RadioButton).Name == "radioButton9";
                RadixSortCheckBox.Refresh();
                RefillItems(SpeedTrackBar.Value > 0);
                SortButton.Enabled = true;
            }
        }

        private void AddTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddNumberButton_Click(sender, e);
                SortButton.Enabled = true;
            }
        }

        private void FillTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FillRandomNumbersButton_Click(sender, e);
                SortButton.Enabled = true;
            }
        }

        private void SpeedTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (SpeedTrackBar.Value == 0)
            {
                testsLabel.ForeColor = SystemColors.ControlLight;
                testsLabel.BackColor = Color.DarkRed;
                for (int i = 1; i < 11; i++)
                {
                    ResultTableLayoutPanel.Controls["label_" + i.ToString() + "1"].Text = "-";
                    ResultTableLayoutPanel.Controls["label_" + i.ToString() + "2"].Text = "-";
                    ResultTableLayoutPanel.Controls["label_" + i.ToString() + "3"].Text = "-";
                }
            }
            else
            {
                testsLabel.ForeColor = SystemColors.ControlText;
                testsLabel.BackColor = SystemColors.Control;
                if (values.Count > maxSortedItemsCount)
                {
                    values.RemoveRange(maxSortedItemsCount, values.Count - maxSortedItemsCount);
                }
                for (int i = 1; i <= 3; i++)
                {
                    ResultTableLayoutPanel.Controls["TestsRadioButton_" + i.ToString()].Enabled = false;
                }
            }
            testsLabel.Refresh();
        }

        private void testsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (SpeedTrackBar.Value == 0)
            {
                if ((sender as RadioButton).Checked)
                {
                    int parameterNumber = 1;
                    if (Int32.TryParse((sender as RadioButton).Name.Substring("TestsRadioButton_".Length), out parameterNumber))
                    {
                        {
                            //NumberStyles style = NumberStyles.AllowDecimalPoint;
                            CultureInfo culture = CultureInfo.CreateSpecificCulture("ru-RU");
                            string text = "";
                            float value = 0;
                            values.Clear();
                            for (int i = 1; i <= allMethods.Length; i++)
                            {
                                text = ResultTableLayoutPanel.Controls["label_" + i.ToString() + parameterNumber.ToString()].Text.Replace(".", culture.NumberFormat.NumberDecimalSeparator);
                                float.TryParse(text, out value);
                                values.Add(Convert.ToInt32(parameterNumber == 1 ? value * 1000 : value));
                            }
                            int maxValue = values.Max();
                            for (int i = 0; i < values.Count; i++)
                            {
                                values[i] = 100 * values[i] / (maxValue == 0 ? 100 : maxValue);
                            }
                            RefillItems(true);
                        }
                    }
                }
            }
        }

    }
}
