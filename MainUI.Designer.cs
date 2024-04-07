
namespace TemperatureMonitor
{
    partial class MainUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mainTable = new TableLayoutPanel();
            listBox4 = new ListBox();
            listBox3 = new ListBox();
            listBox2 = new ListBox();
            lblKey2 = new Label();
            lblKey1 = new Label();
            lblKey3 = new Label();
            lblKey4 = new Label();
            lblVal1 = new Label();
            lblVal2 = new Label();
            lblVal3 = new Label();
            lblVal4 = new Label();
            listBox1 = new ListBox();
            btnStartStop = new Button();
            mainTable.SuspendLayout();
            SuspendLayout();
            // 
            // mainTable
            // 
            mainTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainTable.ColumnCount = 4;
            mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            mainTable.Controls.Add(listBox4, 3, 2);
            mainTable.Controls.Add(listBox3, 2, 2);
            mainTable.Controls.Add(listBox2, 1, 2);
            mainTable.Controls.Add(lblKey2, 1, 0);
            mainTable.Controls.Add(lblKey1, 0, 0);
            mainTable.Controls.Add(lblKey3, 2, 0);
            mainTable.Controls.Add(lblKey4, 3, 0);
            mainTable.Controls.Add(lblVal1, 0, 1);
            mainTable.Controls.Add(lblVal2, 1, 1);
            mainTable.Controls.Add(lblVal3, 2, 1);
            mainTable.Controls.Add(lblVal4, 3, 1);
            mainTable.Controls.Add(listBox1, 0, 2);
            mainTable.Controls.Add(btnStartStop, 0, 3);
            mainTable.Location = new Point(20, 20);
            mainTable.Margin = new Padding(10);
            mainTable.Name = "mainTable";
            mainTable.RowCount = 4;
            mainTable.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            mainTable.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            mainTable.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            mainTable.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            mainTable.Size = new Size(384, 421);
            mainTable.TabIndex = 0;
            // 
            // listBox4
            // 
            listBox4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBox4.BackColor = Color.FromArgb(32, 32, 32);
            listBox4.BorderStyle = BorderStyle.FixedSingle;
            listBox4.Font = new Font("Segoe UI", 10F);
            listBox4.ForeColor = Color.Silver;
            listBox4.FormattingEnabled = true;
            listBox4.ItemHeight = 17;
            listBox4.Items.AddRange(new object[] { "asd", "qwe", "zxc", "rty", "fgh", "vbn" });
            listBox4.Location = new Point(293, 215);
            listBox4.Margin = new Padding(5);
            listBox4.Name = "listBox4";
            listBox4.Size = new Size(86, 155);
            listBox4.TabIndex = 12;
            listBox4.SelectedIndexChanged += listBox4_SelectedIndexChanged;
            // 
            // listBox3
            // 
            listBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBox3.BackColor = Color.FromArgb(32, 32, 32);
            listBox3.BorderStyle = BorderStyle.FixedSingle;
            listBox3.Font = new Font("Segoe UI", 10F);
            listBox3.ForeColor = Color.Silver;
            listBox3.FormattingEnabled = true;
            listBox3.ItemHeight = 17;
            listBox3.Items.AddRange(new object[] { "asd", "qwe", "zxc", "rty", "fgh", "vbn" });
            listBox3.Location = new Point(197, 215);
            listBox3.Margin = new Padding(5);
            listBox3.Name = "listBox3";
            listBox3.Size = new Size(86, 155);
            listBox3.TabIndex = 11;
            listBox3.SelectedIndexChanged += listBox3_SelectedIndexChanged;
            // 
            // listBox2
            // 
            listBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBox2.BackColor = Color.FromArgb(32, 32, 32);
            listBox2.BorderStyle = BorderStyle.FixedSingle;
            listBox2.Font = new Font("Segoe UI", 10F);
            listBox2.ForeColor = Color.Silver;
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 17;
            listBox2.Items.AddRange(new object[] { "asd", "qwe", "zxc", "rty", "fgh", "vbn" });
            listBox2.Location = new Point(101, 215);
            listBox2.Margin = new Padding(5);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(86, 155);
            listBox2.TabIndex = 10;
            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
            // 
            // lblKey2
            // 
            lblKey2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblKey2.AutoSize = true;
            lblKey2.Font = new Font("Segoe UI", 12F);
            lblKey2.ForeColor = Color.Silver;
            lblKey2.Location = new Point(101, 5);
            lblKey2.Margin = new Padding(5);
            lblKey2.Name = "lblKey2";
            lblKey2.Size = new Size(86, 74);
            lblKey2.TabIndex = 1;
            lblKey2.Text = "Cpu package";
            lblKey2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblKey1
            // 
            lblKey1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblKey1.AutoSize = true;
            lblKey1.Font = new Font("Segoe UI", 12F);
            lblKey1.ForeColor = Color.Silver;
            lblKey1.Location = new Point(5, 5);
            lblKey1.Margin = new Padding(5);
            lblKey1.Name = "lblKey1";
            lblKey1.Size = new Size(86, 74);
            lblKey1.TabIndex = 0;
            lblKey1.Text = "Core (Tctl/Tdie)";
            lblKey1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblKey3
            // 
            lblKey3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblKey3.AutoSize = true;
            lblKey3.Font = new Font("Segoe UI", 12F);
            lblKey3.ForeColor = Color.Silver;
            lblKey3.Location = new Point(197, 5);
            lblKey3.Margin = new Padding(5);
            lblKey3.Name = "lblKey3";
            lblKey3.Size = new Size(86, 74);
            lblKey3.TabIndex = 2;
            lblKey3.Text = "Gpu core";
            lblKey3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblKey4
            // 
            lblKey4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblKey4.AutoSize = true;
            lblKey4.Font = new Font("Segoe UI", 12F);
            lblKey4.ForeColor = Color.Silver;
            lblKey4.Location = new Point(293, 5);
            lblKey4.Margin = new Padding(5);
            lblKey4.Name = "lblKey4";
            lblKey4.Size = new Size(86, 74);
            lblKey4.TabIndex = 3;
            lblKey4.Text = "Gpu Hotspot";
            lblKey4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblVal1
            // 
            lblVal1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblVal1.AutoSize = true;
            lblVal1.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblVal1.ForeColor = Color.Silver;
            lblVal1.Location = new Point(5, 89);
            lblVal1.Margin = new Padding(5);
            lblVal1.Name = "lblVal1";
            lblVal1.Size = new Size(86, 116);
            lblVal1.TabIndex = 4;
            lblVal1.Text = "99,9";
            lblVal1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblVal2
            // 
            lblVal2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblVal2.AutoSize = true;
            lblVal2.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblVal2.ForeColor = Color.Silver;
            lblVal2.Location = new Point(101, 89);
            lblVal2.Margin = new Padding(5);
            lblVal2.Name = "lblVal2";
            lblVal2.Size = new Size(86, 116);
            lblVal2.TabIndex = 5;
            lblVal2.Text = "99,9";
            lblVal2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblVal3
            // 
            lblVal3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblVal3.AutoSize = true;
            lblVal3.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblVal3.ForeColor = Color.Silver;
            lblVal3.Location = new Point(197, 89);
            lblVal3.Margin = new Padding(5);
            lblVal3.Name = "lblVal3";
            lblVal3.Size = new Size(86, 116);
            lblVal3.TabIndex = 6;
            lblVal3.Text = "99,9";
            lblVal3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblVal4
            // 
            lblVal4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblVal4.AutoSize = true;
            lblVal4.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblVal4.ForeColor = Color.Silver;
            lblVal4.Location = new Point(293, 89);
            lblVal4.Margin = new Padding(5);
            lblVal4.Name = "lblVal4";
            lblVal4.Size = new Size(86, 116);
            lblVal4.TabIndex = 7;
            lblVal4.Text = "N/A";
            lblVal4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // listBox1
            // 
            listBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBox1.BackColor = Color.FromArgb(32, 32, 32);
            listBox1.BorderStyle = BorderStyle.FixedSingle;
            listBox1.Font = new Font("Segoe UI", 10F);
            listBox1.ForeColor = Color.Silver;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 17;
            listBox1.Items.AddRange(new object[] { "asd", "qwe", "zxc", "rty", "fgh", "vbn" });
            listBox1.Location = new Point(5, 215);
            listBox1.Margin = new Padding(5);
            listBox1.Name = "listBox1";
            listBox1.RightToLeft = RightToLeft.No;
            listBox1.Size = new Size(86, 155);
            listBox1.TabIndex = 9;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // btnStartStop
            // 
            btnStartStop.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnStartStop.BackColor = Color.FromArgb(64, 64, 64);
            mainTable.SetColumnSpan(btnStartStop, 4);
            btnStartStop.ForeColor = Color.Silver;
            btnStartStop.Location = new Point(5, 383);
            btnStartStop.Margin = new Padding(5);
            btnStartStop.Name = "btnStartStop";
            btnStartStop.Size = new Size(374, 33);
            btnStartStop.TabIndex = 1;
            btnStartStop.Text = "Start";
            btnStartStop.UseVisualStyleBackColor = false;
            btnStartStop.Click += btnStartStop_Click;
            // 
            // MainUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 32, 32);
            ClientSize = new Size(424, 461);
            Controls.Add(mainTable);
            MinimumSize = new Size(440, 500);
            Name = "MainUI";
            Padding = new Padding(10);
            Text = "TempMonitor";
            SizeChanged += mainUI_Resize;
            mainTable.ResumeLayout(false);
            mainTable.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel mainTable;
        private Label lblKey2;
        private Label lblKey1;
        private Label lblKey3;
        private Label lblKey4;
        private Label lblVal1;
        private Label lblVal2;
        private Label lblVal3;
        private Label lblVal4;
        private ListBox listBox1;
        private ListBox listBox2;
        private ListBox listBox4;
        private ListBox listBox3;
        private Button btnStartStop;
    }
}
