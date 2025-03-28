namespace SIEM_PROJECT
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.buttonLoadXml = new System.Windows.Forms.Button();
            this.buttonProcess = new System.Windows.Forms.Button();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.buttonLoadExcel = new System.Windows.Forms.Button();
            this.txtBoxProcess = new System.Windows.Forms.TextBox();
            this.pnl = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbl_OUTPUT = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonView = new System.Windows.Forms.Button();
            this.buttonBanlist = new System.Windows.Forms.Button();
            this.pnl.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLoadXml
            // 
            this.buttonLoadXml.BackColor = System.Drawing.Color.Gold;
            this.buttonLoadXml.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonLoadXml.Location = new System.Drawing.Point(75, 128);
            this.buttonLoadXml.Name = "buttonLoadXml";
            this.buttonLoadXml.Size = new System.Drawing.Size(167, 65);
            this.buttonLoadXml.TabIndex = 0;
            this.buttonLoadXml.Text = "Load XML";
            this.buttonLoadXml.UseVisualStyleBackColor = false;
            this.buttonLoadXml.Click += new System.EventHandler(this.buttonLoadXml_Click);
            // 
            // buttonProcess
            // 
            this.buttonProcess.BackColor = System.Drawing.Color.DarkGreen;
            this.buttonProcess.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonProcess.ForeColor = System.Drawing.Color.White;
            this.buttonProcess.Location = new System.Drawing.Point(75, 270);
            this.buttonProcess.Name = "buttonProcess";
            this.buttonProcess.Size = new System.Drawing.Size(167, 65);
            this.buttonProcess.TabIndex = 1;
            this.buttonProcess.Text = "Process";
            this.buttonProcess.UseVisualStyleBackColor = false;
            this.buttonProcess.Click += new System.EventHandler(this.buttonProcess_Click);
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.BackColor = System.Drawing.Color.Black;
            this.textBoxOutput.ForeColor = System.Drawing.Color.White;
            this.textBoxOutput.Location = new System.Drawing.Point(-3, 388);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxOutput.Size = new System.Drawing.Size(1123, 179);
            this.textBoxOutput.TabIndex = 3;
            // 
            // buttonLoadExcel
            // 
            this.buttonLoadExcel.BackColor = System.Drawing.Color.PaleGreen;
            this.buttonLoadExcel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonLoadExcel.Location = new System.Drawing.Point(75, 199);
            this.buttonLoadExcel.Name = "buttonLoadExcel";
            this.buttonLoadExcel.Size = new System.Drawing.Size(167, 65);
            this.buttonLoadExcel.TabIndex = 2;
            this.buttonLoadExcel.Text = "Load Excel";
            this.buttonLoadExcel.UseVisualStyleBackColor = false;
            this.buttonLoadExcel.Click += new System.EventHandler(this.buttonLoadExcel_Click);
            // 
            // txtBoxProcess
            // 
            this.txtBoxProcess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBoxProcess.ForeColor = System.Drawing.Color.White;
            this.txtBoxProcess.Location = new System.Drawing.Point(323, 108);
            this.txtBoxProcess.Multiline = true;
            this.txtBoxProcess.Name = "txtBoxProcess";
            this.txtBoxProcess.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBoxProcess.Size = new System.Drawing.Size(755, 227);
            this.txtBoxProcess.TabIndex = 5;
            // 
            // pnl
            // 
            this.pnl.BackColor = System.Drawing.Color.DarkBlue;
            this.pnl.Controls.Add(this.panel1);
            this.pnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl.Location = new System.Drawing.Point(0, 0);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(1113, 77);
            this.pnl.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1113, 77);
            this.panel1.TabIndex = 7;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::SIEM_PROJECT.Properties.Resources.bb;
            this.pictureBox3.Location = new System.Drawing.Point(1067, -12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(53, 61);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 11;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SIEM_PROJECT.Properties.Resources.pngwing_com;
            this.pictureBox1.Location = new System.Drawing.Point(2, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 74);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(156, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(357, 39);
            this.label1.TabIndex = 9;
            this.label1.Text = "SIEM Event  Processor";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 560);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1113, 28);
            this.panel2.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(923, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "SIEM Event  Processor";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SIEM_PROJECT.Properties.Resources.pngwing_com;
            this.pictureBox2.Location = new System.Drawing.Point(1075, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(28, 23);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // lbl_OUTPUT
            // 
            this.lbl_OUTPUT.AutoSize = true;
            this.lbl_OUTPUT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_OUTPUT.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_OUTPUT.ForeColor = System.Drawing.Color.White;
            this.lbl_OUTPUT.Location = new System.Drawing.Point(-2, 374);
            this.lbl_OUTPUT.Name = "lbl_OUTPUT";
            this.lbl_OUTPUT.Size = new System.Drawing.Size(88, 19);
            this.lbl_OUTPUT.TabIndex = 8;
            this.lbl_OUTPUT.Text = "CONSOLE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(325, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "PROCESS";
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.Gold;
            this.buttonSave.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonSave.Location = new System.Drawing.Point(610, 341);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(152, 30);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "Save the report";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Visible = false;
            this.buttonSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonView
            // 
            this.buttonView.BackColor = System.Drawing.Color.PaleGreen;
            this.buttonView.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonView.Location = new System.Drawing.Point(768, 341);
            this.buttonView.Name = "buttonView";
            this.buttonView.Size = new System.Drawing.Size(152, 30);
            this.buttonView.TabIndex = 12;
            this.buttonView.Text = "View last report";
            this.buttonView.UseVisualStyleBackColor = false;
            this.buttonView.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonBanlist
            // 
            this.buttonBanlist.BackColor = System.Drawing.Color.DarkGreen;
            this.buttonBanlist.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonBanlist.ForeColor = System.Drawing.Color.White;
            this.buttonBanlist.Location = new System.Drawing.Point(926, 341);
            this.buttonBanlist.Name = "buttonBanlist";
            this.buttonBanlist.Size = new System.Drawing.Size(152, 30);
            this.buttonBanlist.TabIndex = 13;
            this.buttonBanlist.Text = "View ban list";
            this.buttonBanlist.UseVisualStyleBackColor = false;
            this.buttonBanlist.Click += new System.EventHandler(this.buttonBanlist_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1113, 588);
            this.Controls.Add(this.buttonBanlist);
            this.Controls.Add(this.buttonView);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_OUTPUT);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnl);
            this.Controls.Add(this.txtBoxProcess);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.buttonLoadExcel);
            this.Controls.Add(this.buttonProcess);
            this.Controls.Add(this.buttonLoadXml);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SIEM PROJECT";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnl.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button buttonLoadXml;
        private System.Windows.Forms.Button buttonProcess;
        private System.Windows.Forms.Button buttonLoadExcel;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.TextBox txtBoxProcess;
        private System.Windows.Forms.Panel pnl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_OUTPUT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonView;
        private System.Windows.Forms.Button buttonBanlist;
    }
}
