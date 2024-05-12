namespace TemperatureMonitor.View
{
    partial class TestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            lblVal = new Label();
            checkBox1 = new CheckBox();
            lblFan = new Label();
            gbCtrlType = new GroupBox();
            rbCrv = new RadioButton();
            rbDefault = new RadioButton();
            rbStatic = new RadioButton();
            hsbSpd = new HScrollBar();
            listBoxFans = new ListBox();
            tableLayoutPanel1.SuspendLayout();
            gbCtrlType.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(lblVal, 0, 2);
            tableLayoutPanel1.Controls.Add(checkBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(lblFan, 0, 1);
            tableLayoutPanel1.Controls.Add(gbCtrlType, 0, 3);
            tableLayoutPanel1.Controls.Add(hsbSpd, 0, 4);
            tableLayoutPanel1.Controls.Add(listBoxFans, 0, 6);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 19F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 24.5F));
            tableLayoutPanel1.Size = new Size(186, 400);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblVal
            // 
            lblVal.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblVal.AutoSize = true;
            lblVal.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVal.ForeColor = Color.Silver;
            lblVal.Location = new Point(5, 85);
            lblVal.Margin = new Padding(5);
            lblVal.Name = "lblVal";
            lblVal.Size = new Size(176, 50);
            lblVal.TabIndex = 2;
            lblVal.Text = "50";
            lblVal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // checkBox1
            // 
            checkBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(166, 5);
            checkBox1.Margin = new Padding(5);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(15, 10);
            checkBox1.TabIndex = 0;
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // lblFan
            // 
            lblFan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblFan.AutoSize = true;
            lblFan.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFan.ForeColor = Color.Silver;
            lblFan.Location = new Point(5, 25);
            lblFan.Margin = new Padding(5);
            lblFan.Name = "lblFan";
            lblFan.Size = new Size(176, 50);
            lblFan.TabIndex = 1;
            lblFan.Text = "Fan #1";
            lblFan.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gbCtrlType
            // 
            gbCtrlType.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbCtrlType.Controls.Add(rbCrv);
            gbCtrlType.Controls.Add(rbDefault);
            gbCtrlType.Controls.Add(rbStatic);
            gbCtrlType.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbCtrlType.ForeColor = Color.Silver;
            gbCtrlType.Location = new Point(5, 145);
            gbCtrlType.Margin = new Padding(5);
            gbCtrlType.Name = "gbCtrlType";
            gbCtrlType.Padding = new Padding(5);
            gbCtrlType.Size = new Size(176, 50);
            gbCtrlType.TabIndex = 3;
            gbCtrlType.TabStop = false;
            gbCtrlType.Text = "control type";
            // 
            // rbCrv
            // 
            rbCrv.AutoSize = true;
            rbCrv.Location = new Point(68, 21);
            rbCrv.Margin = new Padding(0);
            rbCrv.Name = "rbCrv";
            rbCrv.Size = new Size(43, 21);
            rbCrv.TabIndex = 2;
            rbCrv.TabStop = true;
            rbCrv.Text = "crv";
            rbCrv.UseVisualStyleBackColor = true;
            // 
            // rbDefault
            // 
            rbDefault.AutoSize = true;
            rbDefault.Location = new Point(126, 21);
            rbDefault.Margin = new Padding(0);
            rbDefault.Name = "rbDefault";
            rbDefault.Size = new Size(45, 21);
            rbDefault.TabIndex = 1;
            rbDefault.TabStop = true;
            rbDefault.Text = "def";
            rbDefault.UseVisualStyleBackColor = true;
            // 
            // rbStatic
            // 
            rbStatic.AutoSize = true;
            rbStatic.Location = new Point(5, 21);
            rbStatic.Margin = new Padding(0);
            rbStatic.Name = "rbStatic";
            rbStatic.Size = new Size(43, 21);
            rbStatic.TabIndex = 0;
            rbStatic.TabStop = true;
            rbStatic.Text = "sta";
            rbStatic.UseVisualStyleBackColor = true;
            // 
            // hsbSpd
            // 
            hsbSpd.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            hsbSpd.Location = new Point(5, 205);
            hsbSpd.Margin = new Padding(5);
            hsbSpd.Name = "hsbSpd";
            hsbSpd.Size = new Size(176, 15);
            hsbSpd.TabIndex = 4;
            hsbSpd.Scroll += hsbSpd_Change;
            // 
            // listBoxFans
            // 
            listBoxFans.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBoxFans.BackColor = Color.FromArgb(64, 64, 64);
            listBoxFans.BorderStyle = BorderStyle.None;
            listBoxFans.ForeColor = Color.Silver;
            listBoxFans.FormattingEnabled = true;
            listBoxFans.ItemHeight = 15;
            listBoxFans.Location = new Point(5, 307);
            listBoxFans.Margin = new Padding(5);
            listBoxFans.Name = "listBoxFans";
            listBoxFans.SelectionMode = SelectionMode.MultiExtended;
            listBoxFans.Size = new Size(176, 75);
            listBoxFans.TabIndex = 8;
            listBoxFans.SelectedIndexChanged += listBoxFans_SelectionChanged;
            // 
            // TestForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 32, 32);
            ClientSize = new Size(424, 441);
            Controls.Add(tableLayoutPanel1);
            Name = "TestForm";
            Text = "TestForm";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            gbCtrlType.ResumeLayout(false);
            gbCtrlType.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private CheckBox checkBox1;
        private Label lblFan;
        private Label lblVal;
        private GroupBox gbCtrlType;
        private RadioButton rbDefault;
        private RadioButton rbStatic;
        private HScrollBar hsbSpd;
        private RadioButton rbCrv;
        private ListBox listBoxFans;
    }
}