

namespace TemperatureMonitor.View
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
                presenter.StopMonitor();
            } else if (disposing)
            {
                presenter.StopMonitor();
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
            flp = new FlowLayoutPanel();
            btnAddTemp = new Button();
            btnAddLoad = new Button();
            btnAddFanCtrl = new Button();
            btnAddFanPer = new Button();
            btnRem = new Button();
            flp.SuspendLayout();
            SuspendLayout();
            // 
            // flp
            // 
            flp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flp.Controls.Add(btnAddTemp);
            flp.Controls.Add(btnAddLoad);
            flp.Controls.Add(btnAddFanCtrl);
            flp.Controls.Add(btnAddFanPer);
            flp.Controls.Add(btnRem);
            flp.Location = new Point(10, 10);
            flp.Margin = new Padding(5);
            flp.Name = "flp";
            flp.Size = new Size(404, 441);
            flp.TabIndex = 0;
            // 
            // btnAddTemp
            // 
            btnAddTemp.Anchor = AnchorStyles.Left;
            btnAddTemp.BackColor = Color.FromArgb(64, 64, 64);
            btnAddTemp.ForeColor = Color.Silver;
            btnAddTemp.Location = new Point(5, 5);
            btnAddTemp.Margin = new Padding(5);
            btnAddTemp.Name = "btnAddTemp";
            btnAddTemp.Size = new Size(83, 23);
            btnAddTemp.TabIndex = 0;
            btnAddTemp.Text = "Add Temp";
            btnAddTemp.UseVisualStyleBackColor = false;
            btnAddTemp.Click += btnAddTemp_Click;
            // 
            // btnAddLoad
            // 
            btnAddLoad.Anchor = AnchorStyles.Left;
            btnAddLoad.BackColor = Color.FromArgb(64, 64, 64);
            btnAddLoad.ForeColor = Color.Silver;
            btnAddLoad.Location = new Point(98, 5);
            btnAddLoad.Margin = new Padding(5);
            btnAddLoad.Name = "btnAddLoad";
            btnAddLoad.Size = new Size(83, 23);
            btnAddLoad.TabIndex = 1;
            btnAddLoad.Text = "Add Load";
            btnAddLoad.UseVisualStyleBackColor = false;
            btnAddLoad.Click += btnAddLoad_Click;
            // 
            // btnAddFanCtrl
            // 
            btnAddFanCtrl.Anchor = AnchorStyles.Left;
            btnAddFanCtrl.BackColor = Color.FromArgb(64, 64, 64);
            btnAddFanCtrl.ForeColor = Color.Silver;
            btnAddFanCtrl.Location = new Point(191, 5);
            btnAddFanCtrl.Margin = new Padding(5);
            btnAddFanCtrl.Name = "btnAddFanCtrl";
            btnAddFanCtrl.Size = new Size(83, 23);
            btnAddFanCtrl.TabIndex = 2;
            btnAddFanCtrl.Text = "Add Fan Ctrl";
            btnAddFanCtrl.UseVisualStyleBackColor = false;
            btnAddFanCtrl.Click += btnAddFan_Click;
            // 
            // btnAddFanPer
            // 
            btnAddFanPer.Anchor = AnchorStyles.Left;
            btnAddFanPer.BackColor = Color.FromArgb(64, 64, 64);
            btnAddFanPer.ForeColor = Color.Silver;
            btnAddFanPer.Location = new Point(284, 5);
            btnAddFanPer.Margin = new Padding(5);
            btnAddFanPer.Name = "btnAddFanPer";
            btnAddFanPer.Size = new Size(83, 23);
            btnAddFanPer.TabIndex = 4;
            btnAddFanPer.Text = "Add Fan %";
            btnAddFanPer.UseVisualStyleBackColor = false;
            btnAddFanPer.Click += btnAddFanPer_Click;
            // 
            // btnRem
            // 
            btnRem.Anchor = AnchorStyles.Left;
            btnRem.BackColor = Color.FromArgb(64, 64, 64);
            flp.SetFlowBreak(btnRem, true);
            btnRem.ForeColor = Color.Silver;
            btnRem.Location = new Point(5, 38);
            btnRem.Margin = new Padding(5);
            btnRem.Name = "btnRem";
            btnRem.Size = new Size(86, 23);
            btnRem.TabIndex = 3;
            btnRem.Text = "Remove";
            btnRem.UseVisualStyleBackColor = false;
            btnRem.Click += btnRem_Click;
            // 
            // MainUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 32, 32);
            ClientSize = new Size(424, 461);
            Controls.Add(flp);
            MinimumSize = new Size(440, 500);
            Name = "MainUI";
            Padding = new Padding(5);
            Text = "TempMonitor";
            SizeChanged += mainUI_Resize;
            flp.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flp;
        private Button btnAddTemp;
        private Button btnRem;
        private Button btnAddFanCtrl;
        private Button btnAddLoad;
        private Button btnAddFanPer;
    }
}
