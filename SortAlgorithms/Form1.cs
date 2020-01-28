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
                                algorithm = new BubbleSort<SortedItem>();
                                break;
                        }
                        MessageBox.Show("Вы выбрали метод сортировки " + radioButton.Text);
                        break;
                    }
                }

                //for (int i = 0; i < items.Count; i++)
                //{
                //    algorithm.Items.Add(new SortedItem(VisualPanel, i + 1, items[i].Value));
                //}
MessageBox.Show("Заполнение items #1");
                algorithm.Items.AddRange(items);

                algorithm.CompareEvent += AlgorithmCompareEvent;
                algorithm.SwapEvent += AlgorithmSwapEvent;
                algorithm.SortAndGetSpan();

                VisualPanel.Controls.Clear();
                //sortedItemsCount = 0;
                items.Clear();
MessageBox.Show("Очистка items");

                for (int i = 0; i < algorithm.Items.Count; i++)
                {
                    SortedItem item = new SortedItem(VisualPanel, i + 1, algorithm.Items[i].Value);
                    items.Add(item);
                    MessageBox.Show("Заполнение items #2");
                }
                //items.AddRange(algorithm.Items);
                MessageBox.Show("Заполнение items #2");
            }
        }

        private void AlgorithmCompareEvent(object sender, Tuple<SortedItem, SortedItem> e)
        {
            e.Item1.SetColor(Color.Red);
            e.Item2.SetColor(Color.Green);

            VisualPanel.Refresh();
//            System.Threading.Thread.Sleep(500);

//            e.Item1.SetColor(Color.Blue);
//            e.Item2.SetColor(Color.Blue);
//            VisualPanel.Refresh();
        }

        private void AlgorithmSwapEvent(object sender, Tuple<SortedItem, SortedItem> e)
        {
            int aux = e.Item1.Value;
            e.Item1.SetValue(e.Item2.Value);
            e.Item2.SetValue(aux);
            e.Item1.SetColor(Color.Green);
            e.Item2.SetColor(Color.Red);

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
