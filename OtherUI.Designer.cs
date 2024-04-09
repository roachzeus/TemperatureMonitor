namespace TemperatureMonitor
{
    partial class OtherUI
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
            } else if (disposing) {
                worker.stop();
                worker = null;
                monitorThread.Join();
                monitorThread = null;
                monitorComponents.Clear();
                monitorComponents = null;
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
            flp = new FlowLayoutPanel();
            btnAdd = new Button();
            btnRem = new Button();
            flp.SuspendLayout();
            SuspendLayout();
            // 
            // flp
            // 
            flp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flp.Controls.Add(btnAdd);
            flp.Controls.Add(btnRem);
            flp.Location = new Point(14, 14);
            flp.Margin = new Padding(5);
            flp.Name = "flp";
            flp.Size = new Size(396, 473);
            flp.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(64, 64, 64);
            btnAdd.ForeColor = Color.Silver;
            btnAdd.Location = new Point(5, 5);
            btnAdd.Margin = new Padding(5);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(188, 40);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnRem
            // 
            btnRem.BackColor = Color.FromArgb(64, 64, 64);
            flp.SetFlowBreak(btnRem, true);
            btnRem.ForeColor = Color.Silver;
            btnRem.Location = new Point(203, 5);
            btnRem.Margin = new Padding(5);
            btnRem.Name = "btnRem";
            btnRem.Size = new Size(188, 40);
            btnRem.TabIndex = 2;
            btnRem.Text = "Remove";
            btnRem.UseVisualStyleBackColor = false;
            btnRem.Click += btnRem_Click;
            // 
            // OtherUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 32, 32);
            ClientSize = new Size(424, 501);
            Controls.Add(flp);
            Name = "OtherUI";
            Text = "OtherUI";
            flp.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flp;
        private Button btnAdd;
        private Button btnRem;
    }
}