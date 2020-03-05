using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortAlgorithms
{
    public class SortedItem : IComparable, IConvertible
    {

        public VerticalProgressBar VerticalProgressBar = new VerticalProgressBar();

        public Label Label = new Label();

        public Label LabelID = new Label();

        public int Value { get; private set; }

        public int Index { get; set; }

        private static int indent = 4;

        private static int border = 15;

        private static int vertProgressBarSize = 100;

        private static int labelsSize = 15;

        private static int vertProgressBarPositionY = 10;

        private static int labelPositionY = 115;

        private static int labelIDPositionY = 130;

        /// <summary>
        /// Контруктор без графического представления (для групповых тестов)
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="value"></param>
        public SortedItem(int instance, int value)
        {
            // Set value
            Value = value;

            // Set index
            Index = instance;
        }

        public SortedItem(Control control, int instance, int value, uint hexColor = 0xFF0000FF)
        {
            int controlWidth = control.Width - 2 * border;
            int size = (controlWidth - (indent * instance)) / instance > 15 ? (int)((controlWidth - (indent * instance)) / instance) : 15;
            Color color = GetColor(hexColor);

            //Value = value;

            for (int i = 0; i < instance; i++)
            {
                if (control.Controls.Find("verticalProgressBar" + (i + 1).ToString(), false).Any())
                {
                    Control subControl = control.Controls.Find("verticalProgressBar" + (i + 1).ToString(), false).First();
                    subControl.Location = new Point(border + (size + indent) * i, vertProgressBarPositionY);
                    subControl.Size = new Size(size, vertProgressBarSize);
                    subControl.ForeColor = color;
                }
                if (control.Controls.Find("label" + (i + 1).ToString(), false).Any())
                {
                    Control subControl = control.Controls.Find("label" + (i + 1).ToString(), false).First();
                    subControl.Location = new Point(border + (size + indent) * i, labelPositionY);
                    subControl.Size = new Size(size, labelsSize);
                }
                if (control.Controls.Find("labelID" + (i + 1).ToString(), false).Any())
                {
                    Control subControl = control.Controls.Find("labelID" + (i + 1).ToString(), false).First();
                    subControl.Location = new Point(border + (size + indent) * i, labelIDPositionY);
                    subControl.Size = new Size(size, labelsSize);
                }
            }

            VerticalProgressBar.BackColor = SystemColors.Control;
            VerticalProgressBar.Location = new Point(border + (size + indent) * (instance - 1), vertProgressBarPositionY);
            VerticalProgressBar.Name = "verticalProgressBar" + instance.ToString();
            VerticalProgressBar.Size = new Size(size, vertProgressBarSize);
            VerticalProgressBar.Style = ProgressBarStyle.Continuous;
            VerticalProgressBar.Step = 1;
            VerticalProgressBar.Maximum = 100;
            VerticalProgressBar.ForeColor = color;
            //VerticalProgressBar.Value = value;
            control.Controls.Add(VerticalProgressBar);
            //SetColor(Color.FromArgb(color));
            //VerticalProgressBar.Refresh();
            //control.Refresh();

            Label.AutoSize = true;
            Label.Location = new Point(border + (size + indent) * (instance - 1), labelPositionY);
            Label.Name = "label" + instance.ToString();
            Label.Size = new Size(size, labelsSize);
            //Label.Text = value.ToString();
            control.Controls.Add(Label);

            LabelID.AutoSize = true;
            LabelID.Location = new Point(border + (size + indent) * (instance - 1), labelIDPositionY);
            LabelID.Name = "labelID" + instance.ToString();
            LabelID.Size = new Size(size, labelsSize);
            //Label.Text = value.ToString();
            control.Controls.Add(LabelID);

            // Set value
            Value = value;
            VerticalProgressBar.Value = value;
            Label.Text = value.ToString();
            LabelID.Text = "[" + instance.ToString() + "]";

            // Set index
            Index = instance;
            VerticalProgressBar.TabIndex = instance;
            Label.TabIndex = instance;

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
            if (first.VerticalProgressBar != null && second.VerticalProgressBar != null && first != second)
            {
                // Swap location
                Point locationFirst = first.VerticalProgressBar.Location;
                first.VerticalProgressBar.Location = second.VerticalProgressBar.Location;
                second.VerticalProgressBar.Location = locationFirst;

                locationFirst = first.Label.Location;
                first.Label.Location = second.Label.Location;
                second.Label.Location = locationFirst;

                locationFirst = first.LabelID.Location;
                first.LabelID.Location = second.LabelID.Location;
                second.LabelID.Location = locationFirst;

                // Swap index
                //int index = first.Index;
                //first.Index = second.Index;
                //second.Index = first.Index;

                int index = first.VerticalProgressBar.TabIndex;
                first.VerticalProgressBar.TabIndex = second.VerticalProgressBar.TabIndex;
                second.VerticalProgressBar.TabIndex = index;

                first.Label.TabIndex = second.Label.TabIndex;
                second.Label.TabIndex = index;

                first.LabelID.Text = second.LabelID.Text;
                first.LabelID.Text = second.LabelID.Text;
                second.LabelID.Text = "[" + index.ToString() + "]";

                // Swap name
                string name = first.VerticalProgressBar.Name;
                first.VerticalProgressBar.Name = second.VerticalProgressBar.Name;
                second.VerticalProgressBar.Name = name;

                name = first.Label.Name;
                first.Label.Name = second.Label.Name;
                second.Label.Name = name;

                name = first.LabelID.Name;
                first.LabelID.Name = second.LabelID.Name;
                second.LabelID.Name = name;

            }
        }

        public static void Remove(SortedItem item)
        {
            Control control = null;
            if (item.VerticalProgressBar != null)
            {
                control = item.VerticalProgressBar.Parent;
                control.Controls.Remove(item.VerticalProgressBar);
            }
            if (item.Label != null)
            {
                if (control == null)
                {
                    control = item.Label.Parent;
                }
                control.Controls.Remove(item.Label);
            }
            if (item.LabelID != null)
            {
                if (control == null)
                {
                    control = item.LabelID.Parent;
                }
                control.Controls.Remove(item.LabelID);
            }
            item = null;
            Replace(control);
        }

        public static void Replace(Control control)
        {
            int instances = control.Controls.OfType<VerticalProgressBar>().Count();
            for (int i = 0; i < instances; i++)
            {
                int value = 0;
                int controlWidth = control.Width - 2 * border;
                int size = (controlWidth - (indent * instances)) / instances > labelsSize ? (int)((controlWidth - (indent * instances)) / instances) : labelsSize;
                if (control.Controls.Find("verticalProgressBar" + (i + 1).ToString(), false).Any())
                {
                    Control subControl = control.Controls["verticalProgressBar" + (i + 1).ToString()];
                    value = (subControl as VerticalProgressBar).Value;
                    subControl.Location = new Point(border + (size + indent) * i, vertProgressBarPositionY);
                    subControl.Size = new Size(size, vertProgressBarSize);
                }
                if (control.Controls.Find("label" + (i + 1).ToString(), false).Any())
                {
                    Control subControl = control.Controls["label" + (i + 1).ToString()];
                    if (value.ToString() == (subControl as Label).Text)
                    {
                        subControl.Location = new Point(border + (size + indent) * i, labelPositionY);
                        subControl.Size = new Size(size, labelsSize);
                    }
                }
                if (control.Controls.Find("labelID" + (i + 1).ToString(), false).Any())
                {
                    Control subControl = control.Controls["labelID" + (i + 1).ToString()];
                    if ("[" + (i + 1).ToString() + "]" == (subControl as Label).Text)
                    {
                        subControl.Location = new Point(border + (size + indent) * i, labelIDPositionY);
                        subControl.Size = new Size(size, labelsSize);
                    }
                }
            }
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

        public override string ToString()
        {
            return Value.ToString();
        }

        public TypeCode GetTypeCode()
        {
            throw new NotImplementedException();
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public char ToChar(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public byte ToByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public short ToInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public int ToInt32(IFormatProvider provider)
        {
            return Value;
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public long ToInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public float ToSingle(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public double ToDouble(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public string ToString(IFormatProvider provider)
        {
            return Value.ToString();
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }
    }
}
