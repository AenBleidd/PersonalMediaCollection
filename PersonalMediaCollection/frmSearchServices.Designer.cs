namespace PersonalMediaCollection
{
    partial class frmSearchServices
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchServices));
      this.panel1 = new System.Windows.Forms.Panel();
      this.tblServices = new System.Windows.Forms.DataGridView();
      this.panel2 = new System.Windows.Forms.Panel();
      this.btnClose = new System.Windows.Forms.Button();
      this.splitter1 = new System.Windows.Forms.Splitter();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.tblServices)).BeginInit();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.tblServices);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(650, 327);
      this.panel1.TabIndex = 0;
      // 
      // tblServices
      // 
      this.tblServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.tblServices.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tblServices.Location = new System.Drawing.Point(0, 0);
      this.tblServices.Name = "tblServices";
      this.tblServices.Size = new System.Drawing.Size(650, 327);
      this.tblServices.TabIndex = 0;
      this.tblServices.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.tblServices_CellFormatting);
      this.tblServices.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.tblServices_EditingControlShowing);
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.btnClose);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel2.Location = new System.Drawing.Point(0, 287);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(650, 40);
      this.panel2.TabIndex = 1;
      // 
      // btnClose
      // 
      this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
      this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnClose.Location = new System.Drawing.Point(568, 9);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(75, 23);
      this.btnClose.TabIndex = 0;
      this.btnClose.Text = "Закрыть";
      this.btnClose.UseVisualStyleBackColor = true;
      this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
      // 
      // splitter1
      // 
      this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.splitter1.Location = new System.Drawing.Point(0, 284);
      this.splitter1.Name = "splitter1";
      this.splitter1.Size = new System.Drawing.Size(650, 3);
      this.splitter1.TabIndex = 2;
      this.splitter1.TabStop = false;
      // 
      // frmSearchServices
      // 
      this.AcceptButton = this.btnClose;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(650, 327);
      this.Controls.Add(this.splitter1);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "frmSearchServices";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Настройка поиска постеров";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSearchServices_FormClosing);
      this.Load += new System.EventHandler(this.frmSearchServices_Load);
      this.panel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.tblServices)).EndInit();
      this.panel2.ResumeLayout(false);
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView tblServices;

    }
}