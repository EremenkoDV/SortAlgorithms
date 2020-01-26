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

                for (int i = 0; i < items.Count; i++)
                {
                    algorithm.Items.Add(items[i].VerticalProgressBar.Value);
                }

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
