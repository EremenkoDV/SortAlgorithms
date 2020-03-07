using Algorithm;
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

        private string[,] allMethods = new string[13, 4];

        private int sortedItemsCount = 0;

        private int maxSortedItemsCount = 20;

        private int maxValue = 100;

        private Color[,] bgColors;

        public Form1()
        {
            //allMethods[X, 0] - Name of Sorting
            //allMethods[X, 1] - Complexity
            //allMethods[X, 2] - Class of Sorting
            //allMethods[X, 3] - Stability (0 - false/1 - true)

            allMethods[0, 0] = "Bubble Sort";
            allMethods[0, 1] = "O(n²)";
            allMethods[0, 2] = "1";
            allMethods[0, 3] = "1";

            allMethods[1, 0] = "Cocktail Sort";
            allMethods[1, 1] = "O(n²)";
            allMethods[1, 2] = "1";
            allMethods[1, 3] = "1";

            allMethods[2, 0] = "Gnome Sort";
            allMethods[2, 1] = "O(n²)";
            allMethods[2, 2] = "1";
            allMethods[2, 3] = "1";

            allMethods[3, 0] = "Quick Sort";
            allMethods[3, 1] = "O(n log n) -> O(n²)";
            allMethods[3, 2] = "1";
            allMethods[3, 3] = "0";

            allMethods[4, 0] = "Comb Sort";
            allMethods[4, 1] = "O(n log n) -> O(n²)";
            allMethods[4, 2] = "1";
            allMethods[4, 3] = "1";

            allMethods[5, 0] = "Odd-Even Sort";
            allMethods[5, 1] = "O(n²)";
            allMethods[5, 2] = "1";
            allMethods[5, 3] = "1";

            allMethods[6, 0] = "Selection Sort";
            allMethods[6, 1] = "O(n²)";
            allMethods[6, 2] = "2";
            allMethods[6, 3] = "0";

            allMethods[7, 0] = "Heap Sort";
            allMethods[7, 1] = "O(n log n)";
            allMethods[7, 2] = "2";
            allMethods[7, 3] = "0";

            allMethods[8, 0] = "Insertion Sort";
            allMethods[8, 1] = "O(n²)";
            allMethods[8, 2] = "3";
            allMethods[8, 3] = "1";

            allMethods[9, 0] = "Shell Sort";
            allMethods[9, 1] = "O(n log²n)";
            allMethods[9, 2] = "3";
            allMethods[9, 3] = "0";

            allMethods[10, 0] = "Tree Sort";
            allMethods[10, 1] = "O(n log n) -> O(n²)";
            allMethods[10, 2] = "3";
            allMethods[10, 3] = "1";

            allMethods[11, 0] = "Меrge Sort";
            allMethods[11, 1] = "O(n log n)";
            allMethods[11, 2] = "4";
            allMethods[11, 3] = "1";

            allMethods[12, 0] = "Radix Sort";
            allMethods[12, 1] = "O(n k)";
            allMethods[12, 2] = "5";
            allMethods[12, 3] = "0";

            InitializeComponent();
            SetResultTableLayoutPanelBackColors();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {

            for (int i = 1; i < ResultTableLayoutPanel.ColumnCount; i++)
            {
                panel3.Controls["radioButton" + i.ToString()].Text = allMethods[i - 1, 0];
                Color foreColor = allMethods[i - 1, 3] == "0" ? SystemColors.ControlText : Color.DeepSkyBlue;
                for (int j = 0; j < ResultTableLayoutPanel.RowCount; j++)
                {
                    Control control = ResultTableLayoutPanel.GetControlFromPosition(i, j);
                    if (control != null)
                    {
                        if (j == 1)
                        {
                            control.Text = allMethods[i - 1, 0] + " " + allMethods[i - 1, 1];
                        }
                        if (j == 2)
                        {
                            control.Text = "[" + i.ToString() + "]";
                        }
                        if (j > 2)
                        {
                            control.Text = "-";
                        }
                        control.ForeColor = foreColor;
                    }
                }
            }


            for (int i = 1; i <= 3; i++)
            {
                ResultTableLayoutPanel.Controls["TestsRadioButton_" + i.ToString()].Enabled = false;
            }

            //ResultTableLayoutPanel.Refresh();
            //ResultTableLayoutPanel.CellPaint -= ResultTableLayoutPanel_CellPaint;
            FillTextBox.Focus();

        }

        private void SetResultTableLayoutPanelBackColors()
        {
            Color backColor = SystemColors.ButtonHighlight;
            bgColors = new Color[ResultTableLayoutPanel.ColumnCount, ResultTableLayoutPanel.RowCount];
            for (int i = 0; i < ResultTableLayoutPanel.ColumnCount; i++)
            {
                for (int j = 0; j < ResultTableLayoutPanel.RowCount; j++)
                {
                    if (i > 0)
                    {
                        switch (allMethods[i - 1, 2])
                        {
                            case "1":
                                backColor = Color.AliceBlue;
                                break;
                            case "2":
                                backColor = Color.MistyRose;
                                break;
                            case "3":
                                backColor = Color.Bisque;
                                break;
                            case "4":
                                backColor = Color.LightGreen;
                                break;
                            case "5":
                                backColor = Color.PaleTurquoise;
                                break;
                            default:
                                backColor = SystemColors.ButtonHighlight;
                                break;
                        }
                    }
                    bgColors[i, j] = backColor;
                }
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
                    methods = allMethods.GetLength(0);
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

                    switch (panel3.Controls["radioButton" + methodNumber.ToString()].Text)
                    {
                        case "Bubble Sort":
                            algorithm = new BubbleSort<SortedItem>();
                            break;
                        case "Cocktail Sort":
                            algorithm = new CocktailSort<SortedItem>();
                            break;
                        case "Insertion Sort":
                            algorithm = new InsertionSort<SortedItem>();
                            break;
                        case "Shell Sort":
                            algorithm = new ShellSort<SortedItem>();
                            break;
                        case "Tree Sort":
                            algorithm = new Algorithm.DataStructures.Tree<SortedItem>();
                            break;
                        case "Heap Sort":
                            algorithm = new Algorithm.DataStructures.Heap<SortedItem>();
                            break;
                        case "Selection Sort":
                            algorithm = new SelectionSort<SortedItem>();
                            break;
                        case "Gnome Sort":
                            algorithm = new GnomeSort<SortedItem>();
                            break;
                        case "Radix Sort":
                            algorithm = new RadixSort<SortedItem>(RadixSortCheckBox.Checked);
                            break;
                        case "Merge Sort":
                            algorithm = new MergeSort<SortedItem>();
                            break;
                        case "Quick Sort":
                            algorithm = new QuickSort<SortedItem>();
                            break;
                        case "Odd-Even Sort":
                            algorithm = new OddEvenSort<SortedItem>();
                            break;
                        default:
                            algorithm = new BubbleSort<SortedItem>();
                            break;
                    }
                    MessageBox.Show("Вы выбрали метод сортировки " + panel3.Controls["radioButton" + methodNumber.ToString()].Text + " : " + methodNumber.ToString());

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

                    ResultTableLayoutPanel.GetControlFromPosition(methodNumber, 3).Text = runTime.Seconds.ToString() + "." + runTime.Milliseconds.ToString();
                    ResultTableLayoutPanel.GetControlFromPosition(methodNumber, 4).Text = algorithm.ComparisonCount.ToString();
                    ResultTableLayoutPanel.GetControlFromPosition(methodNumber, 5).Text = algorithm.SwapCount.ToString();

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
                RadixSortCheckBox.Visible = (sender as RadioButton).Text == "Radix Sort";
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
                for (int i = 0; i < allMethods.GetLength(0); i++)
                {
                    //ResultTableLayoutPanel.Controls["label_" + i.ToString("D2") + "1"].Text = "-";
                    //ResultTableLayoutPanel.Controls["label_" + i.ToString("D2") + "2"].Text = "-";
                    //ResultTableLayoutPanel.Controls["label_" + i.ToString("D2") + "3"].Text = "-";
                    ResultTableLayoutPanel.GetControlFromPosition(i + 1, 3).Text = "-";
                    ResultTableLayoutPanel.GetControlFromPosition(i + 1, 4).Text = "-";
                    ResultTableLayoutPanel.GetControlFromPosition(i + 1, 5).Text = "-";
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
                            for (int i = 1; i <= allMethods.GetLength(0); i++)
                            {
                                //text = ResultTableLayoutPanel.Controls["label_" + i.ToString("D2") + parameterNumber.ToString()].Text.Replace(".", culture.NumberFormat.NumberDecimalSeparator);
                                text = ResultTableLayoutPanel.GetControlFromPosition(i, parameterNumber + 2).Text.Replace(".", culture.NumberFormat.NumberDecimalSeparator);
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

        private void ResultTableLayoutPanel_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
                using (var b = new SolidBrush(bgColors[e.Column, e.Row]))
                {
                    e.Graphics.FillRectangle(b, e.CellBounds);
                }
        }

    }
}
