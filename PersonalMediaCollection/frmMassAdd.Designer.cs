namespace PersonalMediaCollection
{
  partial class frmMassAdd
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMassAdd));
      this.label1 = new System.Windows.Forms.Label();
      this.udCount = new System.Windows.Forms.NumericUpDown();
      this.panel1 = new System.Windows.Forms.Panel();
      this.panel2 = new System.Windows.Forms.Panel();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnOk = new System.Windows.Forms.Button();
      this.cbAutoNum = new System.Windows.Forms.CheckBox();
      this.label2 = new System.Windows.Forms.Label();
      this.udNumCount = new System.Windows.Forms.NumericUpDown();
      this.label3 = new System.Windows.Forms.Label();
      this.edtPrefix = new System.Windows.Forms.TextBox();
      this.cbParentCover = new System.Windows.Forms.CheckBox();
      this.pbCover = new System.Windows.Forms.PictureBox();
      this.cbDefaultCover = new System.Windows.Forms.CheckBox();
      this.btnDeleteCover = new System.Windows.Forms.Button();
      this.btnSetCover = new System.Windows.Forms.Button();
      this.label4 = new System.Windows.Forms.Label();
      this.udFirstNum = new System.Windows.Forms.NumericUpDown();
      this.dlgImage = new System.Windows.Forms.OpenFileDialog();
      ((System.ComponentModel.ISupportInitialize)(this.udCount)).BeginInit();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.udNumCount)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbCover)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.udFirstNum)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(19, 13);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(66, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Количество";
      // 
      // udCount
      // 
      this.udCount.Location = new System.Drawing.Point(91, 11);
      this.udCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.udCount.Name = "udCount";
      this.udCount.Size = new System.Drawing.Size(47, 20);
      this.udCount.TabIndex = 2;
      this.udCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.udFirstNum);
      this.panel1.Controls.Add(this.label4);
      this.panel1.Controls.Add(this.btnSetCover);
      this.panel1.Controls.Add(this.btnDeleteCover);
      this.panel1.Controls.Add(this.cbDefaultCover);
      this.panel1.Controls.Add(this.pbCover);
      this.panel1.Controls.Add(this.cbParentCover);
      this.panel1.Controls.Add(this.edtPrefix);
      this.panel1.Controls.Add(this.label3);
      this.panel1.Controls.Add(this.udNumCount);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Controls.Add(this.cbAutoNum);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Controls.Add(this.udCount);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(382, 261);
      this.panel1.TabIndex = 3;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.btnOk);
      this.panel2.Controls.Add(this.btnCancel);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel2.Location = new System.Drawing.Point(0, 223);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(382, 38);
      this.panel2.TabIndex = 4;
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(293, 8);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 1;
      this.btnCancel.Text = "Отмена";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // btnOk
      // 
      this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOk.Location = new System.Drawing.Point(212, 8);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(75, 23);
      this.btnOk.TabIndex = 0;
      this.btnOk.Text = "Добавить";
      this.btnOk.UseVisualStyleBackColor = true;
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // cbAutoNum
      // 
      this.cbAutoNum.AutoSize = true;
      this.cbAutoNum.Checked = true;
      this.cbAutoNum.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbAutoNum.Location = new System.Drawing.Point(22, 37);
      this.cbAutoNum.Name = "cbAutoNum";
      this.cbAutoNum.Size = new System.Drawing.Size(105, 17);
      this.cbAutoNum.TabIndex = 3;
      this.cbAutoNum.Text = "Автонумерация";
      this.cbAutoNum.UseVisualStyleBackColor = true;
      this.cbAutoNum.CheckedChanged += new System.EventHandler(this.cbAutoNum_CheckedChanged);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(133, 38);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(119, 13);
      this.label2.TabIndex = 4;
      this.label2.Text = "Число знаков номера";
      // 
      // udNumCount
      // 
      this.udNumCount.Location = new System.Drawing.Point(258, 36);
      this.udNumCount.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
      this.udNumCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.udNumCount.Name = "udNumCount";
      this.udNumCount.Size = new System.Drawing.Size(32, 20);
      this.udNumCount.TabIndex = 5;
      this.udNumCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(19, 83);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(97, 13);
      this.label3.TabIndex = 6;
      this.label3.Text = "Приставка имени";
      // 
      // edtPrefix
      // 
      this.edtPrefix.Location = new System.Drawing.Point(122, 80);
      this.edtPrefix.Name = "edtPrefix";
      this.edtPrefix.Size = new System.Drawing.Size(168, 20);
      this.edtPrefix.TabIndex = 7;
      // 
      // cbParentCover
      // 
      this.cbParentCover.AutoSize = true;
      this.cbParentCover.Checked = true;
      this.cbParentCover.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbParentCover.Location = new System.Drawing.Point(22, 111);
      this.cbParentCover.Name = "cbParentCover";
      this.cbParentCover.Size = new System.Drawing.Size(220, 17);
      this.cbParentCover.TabIndex = 8;
      this.cbParentCover.Text = "Установить обложку с родительского";
      this.cbParentCover.UseVisualStyleBackColor = true;
      this.cbParentCover.CheckedChanged += new System.EventHandler(this.cbParentCover_CheckedChanged);
      // 
      // pbCover
      // 
      this.pbCover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.pbCover.Location = new System.Drawing.Point(293, 102);
      this.pbCover.Name = "pbCover";
      this.pbCover.Size = new System.Drawing.Size(86, 115);
      this.pbCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pbCover.TabIndex = 9;
      this.pbCover.TabStop = false;
      // 
      // cbDefaultCover
      // 
      this.cbDefaultCover.AutoSize = true;
      this.cbDefaultCover.Location = new System.Drawing.Point(22, 134);
      this.cbDefaultCover.Name = "cbDefaultCover";
      this.cbDefaultCover.Size = new System.Drawing.Size(146, 17);
      this.cbDefaultCover.TabIndex = 10;
      this.cbDefaultCover.Text = "Обложка по умолчанию";
      this.cbDefaultCover.UseVisualStyleBackColor = true;
      this.cbDefaultCover.CheckedChanged += new System.EventHandler(this.cbDefaultCover_CheckedChanged);
      // 
      // btnDeleteCover
      // 
      this.btnDeleteCover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnDeleteCover.Enabled = false;
      this.btnDeleteCover.Location = new System.Drawing.Point(212, 194);
      this.btnDeleteCover.Name = "btnDeleteCover";
      this.btnDeleteCover.Size = new System.Drawing.Size(75, 23);
      this.btnDeleteCover.TabIndex = 12;
      this.btnDeleteCover.Text = "Очистить";
      this.btnDeleteCover.UseVisualStyleBackColor = true;
      this.btnDeleteCover.Click += new System.EventHandler(this.btnDeleteCover_Click);
      // 
      // btnSetCover
      // 
      this.btnSetCover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSetCover.Location = new System.Drawing.Point(212, 165);
      this.btnSetCover.Name = "btnSetCover";
      this.btnSetCover.Size = new System.Drawing.Size(75, 23);
      this.btnSetCover.TabIndex = 11;
      this.btnSetCover.Text = "Выбрать";
      this.btnSetCover.UseVisualStyleBackColor = true;
      this.btnSetCover.Click += new System.EventHandler(this.btnSetCover_Click);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(19, 57);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(64, 13);
      this.label4.TabIndex = 13;
      this.label4.Text = "Начинать с";
      // 
      // udFirstNum
      // 
      this.udFirstNum.Location = new System.Drawing.Point(122, 54);
      this.udFirstNum.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
      this.udFirstNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.udFirstNum.Name = "udFirstNum";
      this.udFirstNum.Size = new System.Drawing.Size(58, 20);
      this.udFirstNum.TabIndex = 6;
      this.udFirstNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // dlgImage
      // 
      this.dlgImage.FileName = "dlgImage";
      this.dlgImage.Filter = "Изображения|*.jpg";
      // 
      // frmMassAdd
      // 
      this.AcceptButton = this.btnOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(382, 261);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmMassAdd";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Массовое добавление";
      this.Shown += new System.EventHandler(this.frmMassAdd_Shown);
      ((System.ComponentModel.ISupportInitialize)(this.udCount)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.udNumCount)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbCover)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.udFirstNum)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.NumericUpDown udCount;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.CheckBox cbAutoNum;
    private System.Windows.Forms.NumericUpDown udNumCount;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox edtPrefix;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.CheckBox cbParentCover;
    private System.Windows.Forms.PictureBox pbCover;
    private System.Windows.Forms.CheckBox cbDefaultCover;
    private System.Windows.Forms.Button btnSetCover;
    private System.Windows.Forms.Button btnDeleteCover;
    private System.Windows.Forms.NumericUpDown udFirstNum;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.OpenFileDialog dlgImage;
  }
}