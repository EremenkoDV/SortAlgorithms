using Algorithm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private int sortedItemsCount = 0;

        private int maxSortedItemsCount = 20;
        
        private int maxValue = 100;

        public Form1()
        {
            InitializeComponent();

            RuntimeLabel.Text = "";
            ComparationLabel.Text = "";
            SwapLabel.Text = "";
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            if (sortedItemsCount > 0)
            {
                AlgorithmBase<SortedItem> algorithm = new BubbleSort<SortedItem>();
                foreach (RadioButton radioButton in panel3.Controls.OfType<RadioButton>())
                {
                    if (radioButton.Checked)
                    {
                        switch (radioButton.Name)
                        {
                            case "radioButton1":
                                algorithm = new BubbleSort<SortedItem>();
                                break;
                            case "radioButton2":
                                algorithm = new CocktailSort<SortedItem>();
                                break;
                            case "radioButton3":
                                algorithm = new InsertionSort<SortedItem>();
                                break;
                            case "radioButton4":
                                algorithm = new ShellSort<SortedItem>();
                                break;
                            case "radioButton5":
                                algorithm = new TreeSort<SortedItem>();
                                break;
                            case "radioButton6":
                                algorithm = new Algorithm.DataStructures.Heap<SortedItem>();
                                break;
                        }
                        //MessageBox.Show("Вы выбрали метод сортировки " + radioButton.Text);
                        break;
                    }
                }

                algorithm.Items.AddRange(items);
                algorithm.CompareEvent += AlgorithmCompareEvent;
                algorithm.SwapEvent += AlgorithmSwapEvent;
                TimeSpan runTime = algorithm.SortAndGetSpan();

                RuntimeLabel.Text = "Время выполнения: " + runTime.Seconds.ToString() + "." + runTime.Milliseconds.ToString() + " с.";
                ComparationLabel.Text = "Количество сравнений: " + algorithm.ComparisonCount.ToString();
                SwapLabel.Text = "Количество обменов: " + algorithm.SwapCount.ToString();

                (sender as Button).Enabled = false;
            }
        }

        private void AlgorithmCompareEvent(object sender, Tuple<SortedItem, SortedItem> e)
        {
            e.Item1.SetColor(Color.Red);
            e.Item2.SetColor(Color.Green);

            VisualPanel.Refresh();

            //System.Threading.Thread.Sleep(500);

            e.Item1.SetColor(Color.Blue);
            e.Item2.SetColor(Color.Blue);

            VisualPanel.Refresh();
        }

        private void AlgorithmSwapEvent(object sender, Tuple<SortedItem, SortedItem> e)
        {
            //int aux = e.Item1.Value;
            //e.Item1.SetValue(e.Item2.Value);
            //e.Item2.SetValue(aux);
            SortedItem.SwapPosition(e.Item1, e.Item2);
            e.Item1.SetColor(Color.Green);
            e.Item2.SetColor(Color.Red);

            VisualPanel.Refresh();

            //System.Threading.Thread.Sleep(500);

            e.Item1.SetColor(Color.Blue);
            e.Item2.SetColor(Color.Blue);

            VisualPanel.Refresh();
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
                //panel3.Controls.Add(item.VerticalProgressBar);
                //panel3.Controls.Add(item.Label);
            }
            AddTextBox.Text = "";
            AddTextBox.Focus();
        }

        private void FillRandomNumbersButton_Click(object sender, EventArgs e)
        {

            if (int.TryParse(FillTextBox.Text, out int value) && value <= maxSortedItemsCount)
            {
                VisualPanel.Controls.Clear();
                sortedItemsCount = 0;
                items.Clear();
                values.Clear();

                Random rnd = new Random();
                for (int i = 0; i < value; i++)
                {
                    SortedItem item = new SortedItem(VisualPanel, ++sortedItemsCount, rnd.Next(0, maxValue));
                    items.Add(item);
                    values.Add(item.Value);
                    //VisualPanel.Controls.Add(item.VerticalProgressBar);
                    //VisualPanel.Controls.Add(item.Label);
                }
            }
            FillTextBox.Text = "";
            FillTextBox.Focus();
        }

        private void RefillItems()
        {
            VisualPanel.Controls.Clear();
            sortedItemsCount = 0;
            items.Clear();
            for (int i = 0; i < values.Count; i++)
            {
                SortedItem item = new SortedItem(VisualPanel, ++sortedItemsCount, values[i]);
                VisualPanel.Refresh();
                items.Add(item);
            }
//MessageBox.Show($"Количество items {items.Count} : {sortedItemsCount}");
            VisualPanel.Refresh();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                RefillItems();
                SortButton.Enabled = true;
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                RefillItems();
                SortButton.Enabled = true;
            }
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                RefillItems();
                SortButton.Enabled = true;
            }
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                RefillItems();
                SortButton.Enabled = true;
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                RefillItems();
                SortButton.Enabled = true;
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                RefillItems();
                SortButton.Enabled = true;
            }
        }
    }

}
