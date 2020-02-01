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

        public SortedItem(Control control, int instance, int value, uint hexColor = 0xFF0000FF)
        {
            int indent = 4;
            int border = 15;
            int controlWidth = control.Width - 2 * border;
            int size = (controlWidth - (indent * instance)) / instance > 15 ? (int)((controlWidth - (indent * instance)) / instance) : 15;
            Color color = GetColor(hexColor);

            //Value = value;

            for (int i = 0; i < instance; i++)
            {
                if (control.Controls.Find("verticalProgressBar" + (i + 1).ToString(), false).Any())
                {
                    Control subControl = control.Controls.Find("verticalProgressBar" + (i + 1).ToString(), false).First();
                    subControl.Location = new Point(border + (size + indent) * i, 25);
                    subControl.Size = new Size(size, 86);
                    subControl.ForeColor = color;
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
            VerticalProgressBar.Style = ProgressBarStyle.Continuous;
            VerticalProgressBar.Step = 1;
            VerticalProgressBar.Maximum = 100;
            VerticalProgressBar.TabIndex = instance;
            VerticalProgressBar.ForeColor = color;
            //VerticalProgressBar.Value = value;
            control.Controls.Add(VerticalProgressBar);
            //SetColor(Color.FromArgb(color));
            //VerticalProgressBar.Refresh();
            //control.Refresh();

            Label.AutoSize = true;
            Label.Location = new Point(border + (size + indent) * (instance - 1), 114);
            Label.Name = "label" + instance.ToString();
            Label.Size = new Size(size, 13);
            Label.TabIndex = instance;
            //Label.Text = value.ToString();
            control.Controls.Add(Label);

            // Set value
            Value = value;
            VerticalProgressBar.Value = value;
            Label.Text = value.ToString();

        }

        public static Color GetColor(uint color)
        {
            int[] argb = new int[4];
            for (int i = 0; i < 32; i += 8)
            {
                argb[i / 8] = (int)(color >> i) & 255;
//MessageBox.Show("{0:X2}", BitConverter.GetBytes(argb[i / 8])[0]);
            }
            return Color.FromArgb(argb[3], argb[2], argb[1], argb[0]);
        }

        public static void SwapPosition(SortedItem first, SortedItem second)
        {
            if (first.VerticalProgressBar != null && second.VerticalProgressBar != null)
            {
                Point locationFirst = first.VerticalProgressBar.Location;
                first.VerticalProgressBar.Location = second.VerticalProgressBar.Location;
                second.VerticalProgressBar.Location = locationFirst;

                locationFirst = first.Label.Location;
                first.Label.Location = second.Label.Location;
                second.Label.Location = locationFirst;
            }
        }

        public void SetColor(Color color)
        {
            VerticalProgressBar.ForeColor = color;
            //VerticalProgressBar.Refresh();
//MessageBox.Show(VerticalProgressBar.ForeColor.ToString());
//MessageBox.Show(VerticalProgressBar.Style.ToString());
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

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
