namespace SortAlgorithms
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.ResultTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.RuntimeLabel = new System.Windows.Forms.Label();
            this.ComparationLabel = new System.Windows.Forms.Label();
            this.SwapLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AddNumberButton = new System.Windows.Forms.Button();
            this.AddTextBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.reverseSortCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SpeedTrackBar = new System.Windows.Forms.TrackBar();
            this.FillRandomNumbersButton = new System.Windows.Forms.Button();
            this.FillTextBox = new System.Windows.Forms.TextBox();
            this.VisualPanel = new System.Windows.Forms.Panel();
            this.SortButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.ResultTableLayoutPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedTrackBar)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ResultTableLayoutPanel);
            this.panel1.Location = new System.Drawing.Point(12, 277);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(793, 161);
            this.panel1.TabIndex = 0;
            // 
            // ResultTableLayoutPanel
            // 
            this.ResultTableLayoutPanel.ColumnCount = 11;
            this.ResultTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.ResultTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ResultTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ResultTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ResultTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ResultTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ResultTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ResultTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ResultTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ResultTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ResultTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ResultTableLayoutPanel.Controls.Add(this.RuntimeLabel, 0, 1);
            this.ResultTableLayoutPanel.Controls.Add(this.ComparationLabel, 0, 2);
            this.ResultTableLayoutPanel.Controls.Add(this.SwapLabel, 0, 3);
            this.ResultTableLayoutPanel.Location = new System.Drawing.Point(4, 4);
            this.ResultTableLayoutPanel.Name = "ResultTableLayoutPanel";
            this.ResultTableLayoutPanel.RowCount = 4;
            this.ResultTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ResultTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ResultTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ResultTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ResultTableLayoutPanel.Size = new System.Drawing.Size(786, 154);
            this.ResultTableLayoutPanel.TabIndex = 0;
            // 
            // RuntimeLabel
            // 
            this.RuntimeLabel.AutoSize = true;
            this.RuntimeLabel.Location = new System.Drawing.Point(3, 38);
            this.RuntimeLabel.Name = "RuntimeLabel";
            this.RuntimeLabel.Size = new System.Drawing.Size(106, 13);
            this.RuntimeLabel.TabIndex = 3;
            this.RuntimeLabel.Text = "Время выполнения:";
            // 
            // ComparationLabel
            // 
            this.ComparationLabel.AutoSize = true;
            this.ComparationLabel.Location = new System.Drawing.Point(3, 76);
            this.ComparationLabel.Name = "ComparationLabel";
            this.ComparationLabel.Size = new System.Drawing.Size(127, 13);
            this.ComparationLabel.TabIndex = 3;
            this.ComparationLabel.Text = "Количество сравнений:";
            // 
            // SwapLabel
            // 
            this.SwapLabel.AutoSize = true;
            this.SwapLabel.Location = new System.Drawing.Point(3, 114);
            this.SwapLabel.Name = "SwapLabel";
            this.SwapLabel.Size = new System.Drawing.Size(116, 13);
            this.SwapLabel.TabIndex = 3;
            this.SwapLabel.Text = "Количество обменов:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Добавить число";
            // 
            // AddNumberButton
            // 
            this.AddNumberButton.Location = new System.Drawing.Point(286, 55);
            this.AddNumberButton.Name = "AddNumberButton";
            this.AddNumberButton.Size = new System.Drawing.Size(75, 23);
            this.AddNumberButton.TabIndex = 1;
            this.AddNumberButton.Text = "Добавить";
            this.AddNumberButton.UseVisualStyleBackColor = true;
            this.AddNumberButton.Click += new System.EventHandler(this.AddNumberButton_Click);
            // 
            // AddTextBox
            // 
            this.AddTextBox.Location = new System.Drawing.Point(143, 55);
            this.AddTextBox.Name = "AddTextBox";
            this.AddTextBox.Size = new System.Drawing.Size(137, 21);
            this.AddTextBox.TabIndex = 0;
            this.AddTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddTextBox_KeyDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.reverseSortCheckBox);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.AddNumberButton);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.AddTextBox);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.SpeedTrackBar);
            this.panel2.Controls.Add(this.FillRandomNumbersButton);
            this.panel2.Controls.Add(this.FillTextBox);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(379, 152);
            this.panel2.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(291, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "замедление";
            // 
            // reverseSortCheckBox
            // 
            this.reverseSortCheckBox.AutoSize = true;
            this.reverseSortCheckBox.Location = new System.Drawing.Point(19, 82);
            this.reverseSortCheckBox.Name = "reverseSortCheckBox";
            this.reverseSortCheckBox.Size = new System.Drawing.Size(138, 17);
            this.reverseSortCheckBox.TabIndex = 3;
            this.reverseSortCheckBox.Text = "Обратная сортировка";
            this.reverseSortCheckBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(269, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "0 - тест по скорости";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 25);
            this.label2.MaximumSize = new System.Drawing.Size(130, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Заполнить  коллекцию случайными числами";
            // 
            // SpeedTrackBar
            // 
            this.SpeedTrackBar.Location = new System.Drawing.Point(272, 105);
            this.SpeedTrackBar.Name = "SpeedTrackBar";
            this.SpeedTrackBar.Size = new System.Drawing.Size(104, 42);
            this.SpeedTrackBar.TabIndex = 4;
            this.SpeedTrackBar.Value = 1;
            // 
            // FillRandomNumbersButton
            // 
            this.FillRandomNumbersButton.Location = new System.Drawing.Point(286, 25);
            this.FillRandomNumbersButton.Name = "FillRandomNumbersButton";
            this.FillRandomNumbersButton.Size = new System.Drawing.Size(75, 23);
            this.FillRandomNumbersButton.TabIndex = 1;
            this.FillRandomNumbersButton.Text = "Заполнить";
            this.FillRandomNumbersButton.UseVisualStyleBackColor = true;
            this.FillRandomNumbersButton.Click += new System.EventHandler(this.FillRandomNumbersButton_Click);
            // 
            // FillTextBox
            // 
            this.FillTextBox.Location = new System.Drawing.Point(143, 28);
            this.FillTextBox.Name = "FillTextBox";
            this.FillTextBox.Size = new System.Drawing.Size(137, 21);
            this.FillTextBox.TabIndex = 0;
            this.FillTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FillTextBox_KeyDown);
            // 
            // VisualPanel
            // 
            this.VisualPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VisualPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.VisualPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VisualPanel.Location = new System.Drawing.Point(398, 12);
            this.VisualPanel.Name = "VisualPanel";
            this.VisualPanel.Size = new System.Drawing.Size(408, 152);
            this.VisualPanel.TabIndex = 1;
            // 
            // SortButton
            // 
            this.SortButton.Location = new System.Drawing.Point(286, 4);
            this.SortButton.Name = "SortButton";
            this.SortButton.Size = new System.Drawing.Size(75, 93);
            this.SortButton.TabIndex = 1;
            this.SortButton.Text = "Отсортировать";
            this.SortButton.UseVisualStyleBackColor = true;
            this.SortButton.Click += new System.EventHandler(this.SortButton_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.radioButton7);
            this.panel3.Controls.Add(this.radioButton6);
            this.panel3.Controls.Add(this.radioButton5);
            this.panel3.Controls.Add(this.radioButton4);
            this.panel3.Controls.Add(this.radioButton3);
            this.panel3.Controls.Add(this.radioButton2);
            this.panel3.Controls.Add(this.radioButton1);
            this.panel3.Controls.Add(this.SortButton);
            this.panel3.Location = new System.Drawing.Point(12, 171);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(379, 100);
            this.panel3.TabIndex = 2;
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(102, 50);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(88, 17);
            this.radioButton7.TabIndex = 2;
            this.radioButton7.Text = "SelectionSort";
            this.radioButton7.UseVisualStyleBackColor = true;
            this.radioButton7.CheckedChanged += new System.EventHandler(this.radioButton7_CheckedChanged);
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(102, 27);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(70, 17);
            this.radioButton6.TabIndex = 2;
            this.radioButton6.Text = "HeapSort";
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(102, 4);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(67, 17);
            this.radioButton5.TabIndex = 2;
            this.radioButton5.Text = "TreeSort";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(19, 73);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(67, 17);
            this.radioButton4.TabIndex = 2;
            this.radioButton4.Text = "ShellSort";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(19, 50);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(88, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "InsertionSort";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(19, 27);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(82, 17);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.Text = "CocktailSort";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(19, 4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(77, 17);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "BubbleSort";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(398, 171);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(408, 100);
            this.panel4.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 450);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.VisualPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.AfterLoad);
            this.panel1.ResumeLayout(false);
            this.ResultTableLayoutPanel.ResumeLayout(false);
            this.ResultTableLayoutPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedTrackBar)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddNumberButton;
        private System.Windows.Forms.TextBox AddTextBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button FillRandomNumbersButton;
        private System.Windows.Forms.TextBox FillTextBox;
        private System.Windows.Forms.Panel VisualPanel;
        private System.Windows.Forms.Button SortButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label RuntimeLabel;
        private System.Windows.Forms.Label ComparationLabel;
        private System.Windows.Forms.Label SwapLabel;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.TrackBar SpeedTrackBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.CheckBox reverseSortCheckBox;
        private System.Windows.Forms.TableLayoutPanel ResultTableLayoutPanel;
        private System.Windows.Forms.Panel panel4;
    }

    public class VerticalProgressBar : System.Windows.Forms.ProgressBar
    {

        public VerticalProgressBar()
        {
            this.SetStyle(System.Windows.Forms.ControlStyles.UserPaint, true);
            this.DoubleBuffered = true;
        }

        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                System.Windows.Forms.CreateParams cp = base.CreateParams;
                cp.Style |= 0x04;
                return cp;
            }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            System.Drawing.Rectangle rec = e.ClipRectangle;
            rec.Height = (int)(rec.Height * ((double)Value / Maximum)) - 4;
            if (System.Windows.Forms.ProgressBarRenderer.IsSupported)
                System.Windows.Forms.ProgressBarRenderer.DrawVerticalBar(e.Graphics, e.ClipRectangle);
            rec.Width = rec.Width - 4;
            e.Graphics.FillRectangle(new System.Drawing.SolidBrush(this.ForeColor), 2, e.ClipRectangle.Height - rec.Height - 2, rec.Width, rec.Height);
            //e.Graphics.DrawRectangle(new System.Drawing.Pen(System.Drawing.Color.Black), 2, e.ClipRectangle.Height - rec.Height - 2, rec.Width, rec.Height);
        }
    }

}

