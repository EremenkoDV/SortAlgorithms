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

        private void AfterLoad(object sender, EventArgs e)
        {
            FillTextBox.Focus();
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            if (sortedItemsCount > 0)
            {
                int sortMethodNumber = 0;
                AlgorithmBase<SortedItem> algorithm = new AlgorithmBase<SortedItem>();
                foreach (RadioButton radioButton in panel3.Controls.OfType<RadioButton>())
                {
                    if (radioButton.Checked)
                    {
                        switch (radioButton.Name)
                        {
                            case "radioButton1":
                                sortMethodNumber = 1;
                                algorithm = new BubbleSort<SortedItem>();
                                break;
                            case "radioButton2":
                                sortMethodNumber = 2;
                                algorithm = new CocktailSort<SortedItem>();
                                break;
                            case "radioButton3":
                                sortMethodNumber = 3;
                                algorithm = new InsertionSort<SortedItem>();
                                break;
                            case "radioButton4":
                                sortMethodNumber = 4;
                                algorithm = new ShellSort<SortedItem>();
                                break;
                            case "radioButton5":
                                sortMethodNumber = 5;
                                algorithm = new Algorithm.DataStructures.Tree<SortedItem>();
                                break;
                            case "radioButton6":
                                sortMethodNumber = 6;
                                algorithm = new Algorithm.DataStructures.Heap<SortedItem>();
                                break;
                            case "radioButton7":
                                sortMethodNumber = 7;
                                algorithm = new SelectionSort<SortedItem>();
                                break;
                            default:
                                algorithm = new BubbleSort<SortedItem>();
                                break;
                        }
                        //MessageBox.Show("Вы выбрали метод сортировки " + radioButton.Text);
                        break;
                    }
                }

                if (SpeedTrackBar.Value > 0)
                {
                    algorithm.CompareEvent += AlgorithmCompareEvent;
                    algorithm.SwapEvent += AlgorithmSwapEvent;
                    algorithm.RemoveEvent += AlgorithmRemoveEvent;
                }

                if (reverseSortCheckBox.Checked)
                {
                    algorithm.IsAscending = false;
                }

                algorithm.AddRange(items);
                TimeSpan runTime = algorithm.SortAndGetSpan();

                if (sortMethodNumber == 6)
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

                ResultTableLayoutPanel.ce
                RuntimeLabel.Text = "Время выполнения: " + runTime.Seconds.ToString() + "." + runTime.Milliseconds.ToString() + " с.";
                ComparationLabel.Text = "Количество сравнений: " + algorithm.ComparisonCount.ToString();
                SwapLabel.Text = "Количество обменов: " + algorithm.SwapCount.ToString();

                (sender as Button).Enabled = false;
            }
        }

        private void AlgorithmCompareEvent(object sender, Tuple<SortedItem, SortedItem> e)
        {
            if (SpeedTrackBar.Value > 0)
            {
                e.Item1.SetColor(Color.Red);
                e.Item2.SetColor(Color.Green);

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
                SortedItem.SwapPosition(e.Item1, e.Item2);
                e.Item1.SetColor(Color.Green);
                e.Item2.SetColor(Color.Red);

                VisualPanel.Refresh();

                //System.Threading.Thread.Sleep(500);

                e.Item1.SetColor(Color.Blue);
                e.Item2.SetColor(Color.Blue);

                VisualPanel.Refresh();
            }
        }

        private void AlgorithmRemoveEvent(object sender, SortedItem e)
        {
            if (SpeedTrackBar.Value > 0)
            {
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

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                RefillItems();
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

    }

}
