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

        private int sortedItemsCount = 0;

        private int maxSortedItemsCount = 20;
        
        private int maxValue = 100;

        public Form1()
        {
            InitializeComponent();
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            if (sortedItemsCount > 0)
            {
                AlgorithmBase<int> algorithm = new BubbleSort<int>();
                foreach (RadioButton radioButton in panel3.Controls.OfType<RadioButton>())
                {
                    if (radioButton.Checked)
                    {
                        switch (radioButton.Name)
                        {
                            case "radioButton1":
                                algorithm = new BubbleSort<int>();
                                break;
                            case "radioButton2":
                                algorithm = new CocktailSort<int>();
                                break;
                            case "radioButton3":
                                algorithm = new InsertionSort<int>();
                                break;
                            case "radioButton4":
                                algorithm = new BubbleSort<int>();
                                break;
                        }
                        MessageBox.Show("Вы выбрали метод сортировки " + radioButton.Text);
                        break;
                    }
                }

                for (int i = 0; i < items.Count; i++)
                {
                    algorithm.Items.Add(items[i].Value);
                }

                algorithm.CompareEvent += Algorithm_CompareEvent;
                algorithm.SwapEvent += Algorithm_SwapEvent;
                algorithm.SortAndGetSpan();

                VisualPanel.Controls.Clear();
                sortedItemsCount = 0;
                items.Clear();

                for (int i = 0; i < algorithm.Items.Count; i++)
                {
                    SortedItem item = new SortedItem(VisualPanel, ++sortedItemsCount, algorithm.Items[i]);
                    items.Add(item);
                }
            }
        }

        private void Algorithm_SwapEvent(object sender, Tuple<SortedItem, SortedItem> e)
        {
            int aux = e.Item1.Value;
            e.Item1.SetValue(e.Item2.Value);
            e.Item2.SetValue(aux);

            VisualPanel.Refresh();
        }

        private void Algorithm_CompareEvent(object sender, Tuple<SortedItem, SortedItem> e)
        {
            e.Item1.SetColor(Color.Red);
            e.Item2.SetColor(Color.Green);

            VisualPanel.Refresh();
        }

        //private void Swap(SortedItem first, SortedItem second)
        //{
        //    first.SetColor(Color.Red);
        //    second.SetColor(Color.Green);
        //}

        private void AddNumberButton_Click(object sender, EventArgs e)
        {

            if (int.TryParse(AddTextBox.Text, out int value) && value <= maxValue)
            {
                if (sortedItemsCount >= maxSortedItemsCount)
                {
                    VisualPanel.Controls.Clear();
                    sortedItemsCount = 0;
                    items.Clear();
                }

                SortedItem item = new SortedItem(VisualPanel, ++sortedItemsCount, value);
                items.Add(item);
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

                Random rnd = new Random();
                for (int i = 0; i < value; i++)
                {
                    SortedItem item = new SortedItem(VisualPanel, ++sortedItemsCount, rnd.Next(0, maxValue));
                    items.Add(item);
                    //panel3.Controls.Add(item.VerticalProgressBar);
                    //panel3.Controls.Add(item.Label);
                }
                //label1.Text += " " + value;
            }
            FillTextBox.Text = "";
            FillTextBox.Focus();
        }

    }

}
