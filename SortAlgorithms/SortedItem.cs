using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortAlgorithms
{
    public class SortedItem : IComparable
    {

        public VerticalProgressBar VerticalProgressBar = new VerticalProgressBar();

        public Label Label = new Label();

        public int Value { get; private set; }

        public SortedItem(Control control, int instance, int value, int color = 0x0000FF)
        {
            int indent = 4;
            int border = 15;
            int controlWidth = control.Width - 2 * border;
            int size = (controlWidth - (indent * instance)) / instance > 15 ? (int)((controlWidth - (indent * instance)) / instance) : 15;

            //Value = value;

            for (int i = 0; i < instance; i++)
            {
                if (control.Controls.Find("verticalProgressBar" + (i + 1).ToString(), false).Any())
                {
                    Control subControl = control.Controls.Find("verticalProgressBar" + (i + 1).ToString(), false).First();
                    subControl.Location = new Point(border + (size + indent) * i, 25);
                    subControl.Size = new Size(size, 86);
                }
                if (control.Controls.Find("label" + (i + 1).ToString(), false).Any())
                {
                    Control subControl = control.Controls.Find("label" + (i + 1).ToString(), false).First();
                    subControl.Location = new Point(border + (size + indent) * i, 114);
                    subControl.Size = new Size(size, 13);
                }
            }

            VerticalProgressBar.BackColor = SystemColors.Control;
            VerticalProgressBar.Location = new Point(border + (size + indent) * (instance - 1), 25);
            VerticalProgressBar.Name = "verticalProgressBar" + instance.ToString();
            VerticalProgressBar.Size = new Size(size, 86);
            VerticalProgressBar.Style = ProgressBarStyle.Blocks;
            VerticalProgressBar.Step = 1;
            VerticalProgressBar.TabIndex = instance;
            VerticalProgressBar.ForeColor = Color.FromArgb(color);
            //VerticalProgressBar.Value = value;
            control.Controls.Add(VerticalProgressBar);

            Label.AutoSize = true;
            Label.Location = new Point(border + (size + indent) * (instance - 1), 114);
            Label.Name = "label" + instance.ToString();
            Label.Size = new Size(size, 13);
            Label.TabIndex = instance;
            //Label.Text = value.ToString();
            control.Controls.Add(Label);

            SetValue(value);
        }

        public void SetValue(int value)
        {
            Value = value;
            VerticalProgressBar.Value = value;
            Label.Text = value.ToString();
        }

        public void SetColor(Color color)
        {
            VerticalProgressBar.ForeColor = color;
        }

        public int CompareTo(object obj)
        {
            if (obj is SortedItem item)
            {
                return Value.CompareTo(item.Value);
            }
            else
            {
                throw new ArgumentException($"obj is not {nameof(SortedItem)}", nameof(item));
            }
        }
    }
}
