using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortAlgorithms
{
    public class SortedItem
    {

        public VerticalProgressBar VerticalProgressBar = new VerticalProgressBar();

        public Label Label = new Label();

        public SortedItem(Control control, int instance, int value)
        {
            int indent = 4;
            int border = 15;
            int controlWidth = control.Width - 2 * border;
            int size = (controlWidth - (indent * instance)) / instance > 15 ? (int)((controlWidth - (indent * instance)) / instance) : 15;

            for (int i = 0; i < instance; i++)
            {
                if (control.Controls.Find("verticalProgressBar" + (i + 1).ToString(), false).Any())
                {
                    Control subControl = control.Controls.Find("verticalProgressBar" + (i + 1).ToString(), false).First();
                    subControl.Location = new System.Drawing.Point(border + (size + indent) * i, 25);
                    subControl.Size = new System.Drawing.Size(size, 86);
                }
                if (control.Controls.Find("label" + (i + 1).ToString(), false).Any())
                {
                    Control subControl = control.Controls.Find("label" + (i + 1).ToString(), false).First();
                    subControl.Location = new System.Drawing.Point(border + (size + indent) * i, 114);
                    subControl.Size = new System.Drawing.Size(size, 13);
                }
            }

            VerticalProgressBar.BackColor = System.Drawing.SystemColors.Control;
            VerticalProgressBar.Location = new System.Drawing.Point(border + (size + indent) * (instance - 1), 25);
            VerticalProgressBar.Name = "verticalProgressBar" + instance.ToString();
            VerticalProgressBar.Size = new System.Drawing.Size(size, 86);
            VerticalProgressBar.Style = ProgressBarStyle.Blocks;
            VerticalProgressBar.Step = 1;
            VerticalProgressBar.TabIndex = 0;
            VerticalProgressBar.Value = value;
            control.Controls.Add(VerticalProgressBar);

            Label.AutoSize = true;
            Label.Location = new System.Drawing.Point(border + (size + indent) * (instance - 1), 114);
            Label.Name = "label" + instance.ToString();
            Label.Size = new System.Drawing.Size(size, 13);
            Label.TabIndex = 1;
            Label.Text = value.ToString();
            control.Controls.Add(Label);

        }


    }
}
