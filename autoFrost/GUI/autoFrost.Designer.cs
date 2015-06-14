namespace autoFrost
{
    partial class autoFrost
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(autoFrost));
            this.executableToImbed_BT = new System.Windows.Forms.Button();
            this.grayFrostCsproj_BT = new System.Windows.Forms.Button();
            this.build_BT = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mainPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // executableToImbed_BT
            // 
            this.executableToImbed_BT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.executableToImbed_BT.Location = new System.Drawing.Point(3, 3);
            this.executableToImbed_BT.Name = "executableToImbed_BT";
            this.executableToImbed_BT.Size = new System.Drawing.Size(374, 119);
            this.executableToImbed_BT.TabIndex = 0;
            this.executableToImbed_BT.Text = "Embed Executable";
            this.executableToImbed_BT.UseVisualStyleBackColor = true;
            this.executableToImbed_BT.Click += new System.EventHandler(this.executableToImbed_BT_Click);
            // 
            // grayFrostCsproj_BT
            // 
            this.grayFrostCsproj_BT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grayFrostCsproj_BT.Location = new System.Drawing.Point(3, 128);
            this.grayFrostCsproj_BT.Name = "grayFrostCsproj_BT";
            this.grayFrostCsproj_BT.Size = new System.Drawing.Size(374, 125);
            this.grayFrostCsproj_BT.TabIndex = 1;
            this.grayFrostCsproj_BT.Text = "Gray Frost .csproj";
            this.grayFrostCsproj_BT.UseVisualStyleBackColor = true;
            this.grayFrostCsproj_BT.Click += new System.EventHandler(this.grayFrostCsproj_BT_Click);
            // 
            // build_BT
            // 
            this.build_BT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.build_BT.Location = new System.Drawing.Point(3, 259);
            this.build_BT.Name = "build_BT";
            this.build_BT.Size = new System.Drawing.Size(374, 141);
            this.build_BT.TabIndex = 2;
            this.build_BT.Text = "Build Gray Frost";
            this.build_BT.UseVisualStyleBackColor = true;
            this.build_BT.Click += new System.EventHandler(this.build_BT_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.tableLayoutPanel1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(380, 403);
            this.mainPanel.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.executableToImbed_BT, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.build_BT, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.grayFrostCsproj_BT, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.9083F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.0917F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 146F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(380, 403);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // autoFrost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 403);
            this.Controls.Add(this.mainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "autoFrost";
            this.Text = "Auto Frost";
            this.mainPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button executableToImbed_BT;
        private System.Windows.Forms.Button grayFrostCsproj_BT;
        private System.Windows.Forms.Button build_BT;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

    }
}

