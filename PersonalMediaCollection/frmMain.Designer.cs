namespace PersonalMediaCollection
{
  partial class frmMain
  {
    /// <summary>
    /// Требуется переменная конструктора.
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
    /// Обязательный метод для поддержки конструктора - не изменяйте
    /// содержимое данного метода при помощи редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.menuAddGroup = new System.Windows.Forms.ToolStripMenuItem();
      this.menuAddFile = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.menuDelete = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
      this.menuRefresh = new System.Windows.Forms.ToolStripMenuItem();
      this.настройкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.menuSearchServices = new System.Windows.Forms.ToolStripMenuItem();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.MediaPath = new System.Windows.Forms.ToolStripStatusLabel();
      this.panel2 = new System.Windows.Forms.Panel();
      this.btnRefresh = new System.Windows.Forms.Button();
      this.imageListInterface = new System.Windows.Forms.ImageList(this.components);
      this.btnDelete = new System.Windows.Forms.Button();
      this.btnAddFile = new System.Windows.Forms.Button();
      this.btnAddGroup = new System.Windows.Forms.Button();
      this.pathBack = new System.Windows.Forms.Button();
      this.splitter2 = new System.Windows.Forms.Splitter();
      this.panel4 = new System.Windows.Forms.Panel();
      this.lbTitle = new System.Windows.Forms.Label();
      this.cbWatched = new System.Windows.Forms.CheckBox();
      this.btnFindCover = new System.Windows.Forms.Button();
      this.btnChangeInfo = new System.Windows.Forms.Button();
      this.btnOpen = new System.Windows.Forms.Button();
      this.btnPlay = new System.Windows.Forms.Button();
      this.pictureBox = new System.Windows.Forms.PictureBox();
      this.menuPoster = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.mSetPosterFromParent = new System.Windows.Forms.ToolStripMenuItem();
      this.menuSetCoverFromClipboard = new System.Windows.Forms.ToolStripMenuItem();
      this.menuDeletePoster = new System.Windows.Forms.ToolStripMenuItem();
      this.tbTitle = new System.Windows.Forms.TextBox();
      this.splitter4 = new System.Windows.Forms.Splitter();
      this.panel5 = new System.Windows.Forms.Panel();
      this.listViewMainContent = new System.Windows.Forms.ListView();
      this.menuMainList = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.menuMainListAddGroup = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMainListAddElement = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
      this.menuMainListSetCoverFromParent = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
      this.menuMainListCut = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMainListCopy = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMainListPaste = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
      this.menuMainListDelete = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
      this.menuMainListRefresh = new System.Windows.Forms.ToolStripMenuItem();
      this.imageListView = new System.Windows.Forms.ImageList(this.components);
      this.dlgOpenImage = new System.Windows.Forms.OpenFileDialog();
      this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
      this.imagePoster = new System.Windows.Forms.ImageList(this.components);
      this.загрузитьПостерИзБуфераОбменаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.удалитьПостерToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.menuStrip1.SuspendLayout();
      this.statusStrip1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
      this.menuPoster.SuspendLayout();
      this.panel5.SuspendLayout();
      this.menuMainList.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.изменитьToolStripMenuItem,
            this.настройкаToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
      this.menuStrip1.Size = new System.Drawing.Size(839, 24);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // файлToolStripMenuItem
      // 
      this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
      this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
      this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
      this.файлToolStripMenuItem.Text = "Файл";
      // 
      // выходToolStripMenuItem
      // 
      this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
      this.выходToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.выходToolStripMenuItem.Text = "Выход";
      this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
      // 
      // изменитьToolStripMenuItem
      // 
      this.изменитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddGroup,
            this.menuAddFile,
            this.toolStripMenuItem1,
            this.menuDelete,
            this.toolStripMenuItem2,
            this.menuRefresh});
      this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
      this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
      this.изменитьToolStripMenuItem.Text = "Изменить";
      // 
      // menuAddGroup
      // 
      this.menuAddGroup.Image = ((System.Drawing.Image)(resources.GetObject("menuAddGroup.Image")));
      this.menuAddGroup.Name = "menuAddGroup";
      this.menuAddGroup.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Insert)));
      this.menuAddGroup.Size = new System.Drawing.Size(248, 22);
      this.menuAddGroup.Text = "Добавить группу";
      this.menuAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
      // 
      // menuAddFile
      // 
      this.menuAddFile.Image = ((System.Drawing.Image)(resources.GetObject("menuAddFile.Image")));
      this.menuAddFile.Name = "menuAddFile";
      this.menuAddFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Insert)));
      this.menuAddFile.Size = new System.Drawing.Size(248, 22);
      this.menuAddFile.Text = "Добавить элемент";
      this.menuAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(245, 6);
      // 
      // menuDelete
      // 
      this.menuDelete.Image = ((System.Drawing.Image)(resources.GetObject("menuDelete.Image")));
      this.menuDelete.Name = "menuDelete";
      this.menuDelete.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
      this.menuDelete.Size = new System.Drawing.Size(248, 22);
      this.menuDelete.Text = "Удалить";
      this.menuDelete.Click += new System.EventHandler(this.btnDelete_Click);
      // 
      // toolStripMenuItem2
      // 
      this.toolStripMenuItem2.Name = "toolStripMenuItem2";
      this.toolStripMenuItem2.Size = new System.Drawing.Size(245, 6);
      // 
      // menuRefresh
      // 
      this.menuRefresh.Image = ((System.Drawing.Image)(resources.GetObject("menuRefresh.Image")));
      this.menuRefresh.Name = "menuRefresh";
      this.menuRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
      this.menuRefresh.Size = new System.Drawing.Size(248, 22);
      this.menuRefresh.Text = "Обновить";
      this.menuRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
      // 
      // настройкаToolStripMenuItem
      // 
      this.настройкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSearchServices});
      this.настройкаToolStripMenuItem.Name = "настройкаToolStripMenuItem";
      this.настройкаToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
      this.настройкаToolStripMenuItem.Text = "Настройка";
      // 
      // menuSearchServices
      // 
      this.menuSearchServices.Name = "menuSearchServices";
      this.menuSearchServices.Size = new System.Drawing.Size(210, 22);
      this.menuSearchServices.Text = "Сервис поиска постеров";
      this.menuSearchServices.Click += new System.EventHandler(this.menuSearchServices_Click);
      // 
      // statusStrip1
      // 
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MediaPath});
      this.statusStrip1.Location = new System.Drawing.Point(0, 520);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(839, 22);
      this.statusStrip1.TabIndex = 2;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // MediaPath
      // 
      this.MediaPath.Name = "MediaPath";
      this.MediaPath.Size = new System.Drawing.Size(0, 17);
      // 
      // panel2
      // 
      this.panel2.BackColor = System.Drawing.SystemColors.Control;
      this.panel2.Controls.Add(this.btnRefresh);
      this.panel2.Controls.Add(this.btnDelete);
      this.panel2.Controls.Add(this.btnAddFile);
      this.panel2.Controls.Add(this.btnAddGroup);
      this.panel2.Controls.Add(this.pathBack);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel2.Location = new System.Drawing.Point(0, 24);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(839, 44);
      this.panel2.TabIndex = 5;
      // 
      // btnRefresh
      // 
      this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnRefresh.ImageIndex = 2;
      this.btnRefresh.ImageList = this.imageListInterface;
      this.btnRefresh.Location = new System.Drawing.Point(455, 3);
      this.btnRefresh.Name = "btnRefresh";
      this.btnRefresh.Size = new System.Drawing.Size(100, 38);
      this.btnRefresh.TabIndex = 5;
      this.btnRefresh.Text = "Обновить";
      this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnRefresh.UseVisualStyleBackColor = true;
      this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
      // 
      // imageListInterface
      // 
      this.imageListInterface.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListInterface.ImageStream")));
      this.imageListInterface.TransparentColor = System.Drawing.Color.Transparent;
      this.imageListInterface.Images.SetKeyName(0, "back-icon.ico");
      this.imageListInterface.Images.SetKeyName(1, "add-files-to-archive_2181.ico");
      this.imageListInterface.Images.SetKeyName(2, "application-x-trash_8500.ico");
      this.imageListInterface.Images.SetKeyName(3, "file_document_paper_green_g11822_9920.ico");
      this.imageListInterface.Images.SetKeyName(4, "file_document_paper_red_g38129_6746.ico");
      // 
      // btnDelete
      // 
      this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnDelete.ImageIndex = 4;
      this.btnDelete.ImageList = this.imageListInterface;
      this.btnDelete.Location = new System.Drawing.Point(349, 3);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new System.Drawing.Size(100, 38);
      this.btnDelete.TabIndex = 4;
      this.btnDelete.Text = "Удалить";
      this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnDelete.UseVisualStyleBackColor = true;
      this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
      // 
      // btnAddFile
      // 
      this.btnAddFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnAddFile.ImageIndex = 3;
      this.btnAddFile.ImageList = this.imageListInterface;
      this.btnAddFile.Location = new System.Drawing.Point(200, 3);
      this.btnAddFile.Name = "btnAddFile";
      this.btnAddFile.Size = new System.Drawing.Size(143, 38);
      this.btnAddFile.TabIndex = 3;
      this.btnAddFile.Text = "Добавить элемент";
      this.btnAddFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnAddFile.UseVisualStyleBackColor = true;
      this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
      // 
      // btnAddGroup
      // 
      this.btnAddGroup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnAddGroup.ImageIndex = 1;
      this.btnAddGroup.ImageList = this.imageListInterface;
      this.btnAddGroup.Location = new System.Drawing.Point(51, 3);
      this.btnAddGroup.Name = "btnAddGroup";
      this.btnAddGroup.Size = new System.Drawing.Size(143, 38);
      this.btnAddGroup.TabIndex = 2;
      this.btnAddGroup.Text = "Добавить группу";
      this.btnAddGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnAddGroup.UseVisualStyleBackColor = true;
      this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
      // 
      // pathBack
      // 
      this.pathBack.ImageIndex = 0;
      this.pathBack.ImageList = this.imageListInterface;
      this.pathBack.Location = new System.Drawing.Point(3, 3);
      this.pathBack.Name = "pathBack";
      this.pathBack.Size = new System.Drawing.Size(42, 38);
      this.pathBack.TabIndex = 1;
      this.pathBack.UseVisualStyleBackColor = true;
      this.pathBack.Click += new System.EventHandler(this.pathBack_Click);
      // 
      // splitter2
      // 
      this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
      this.splitter2.Location = new System.Drawing.Point(0, 68);
      this.splitter2.Name = "splitter2";
      this.splitter2.Size = new System.Drawing.Size(839, 3);
      this.splitter2.TabIndex = 6;
      this.splitter2.TabStop = false;
      // 
      // panel4
      // 
      this.panel4.BackColor = System.Drawing.SystemColors.Control;
      this.panel4.Controls.Add(this.lbTitle);
      this.panel4.Controls.Add(this.cbWatched);
      this.panel4.Controls.Add(this.btnFindCover);
      this.panel4.Controls.Add(this.btnChangeInfo);
      this.panel4.Controls.Add(this.btnOpen);
      this.panel4.Controls.Add(this.btnPlay);
      this.panel4.Controls.Add(this.pictureBox);
      this.panel4.Controls.Add(this.tbTitle);
      this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
      this.panel4.Location = new System.Drawing.Point(639, 71);
      this.panel4.Name = "panel4";
      this.panel4.Size = new System.Drawing.Size(200, 449);
      this.panel4.TabIndex = 9;
      // 
      // lbTitle
      // 
      this.lbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lbTitle.Location = new System.Drawing.Point(10, 255);
      this.lbTitle.Name = "lbTitle";
      this.lbTitle.Size = new System.Drawing.Size(179, 113);
      this.lbTitle.TabIndex = 11;
      this.lbTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      this.lbTitle.UseMnemonic = false;
      this.lbTitle.DoubleClick += new System.EventHandler(this.lbTitle_DoubleClick);
      // 
      // cbWatched
      // 
      this.cbWatched.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.cbWatched.AutoSize = true;
      this.cbWatched.Enabled = false;
      this.cbWatched.Location = new System.Drawing.Point(10, 371);
      this.cbWatched.Name = "cbWatched";
      this.cbWatched.Size = new System.Drawing.Size(95, 17);
      this.cbWatched.TabIndex = 10;
      this.cbWatched.Text = "Просмотрено";
      this.cbWatched.UseVisualStyleBackColor = true;
      this.cbWatched.Click += new System.EventHandler(this.cbWatched_Click);
      // 
      // btnFindCover
      // 
      this.btnFindCover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnFindCover.Enabled = false;
      this.btnFindCover.Location = new System.Drawing.Point(104, 394);
      this.btnFindCover.Name = "btnFindCover";
      this.btnFindCover.Size = new System.Drawing.Size(85, 23);
      this.btnFindCover.TabIndex = 9;
      this.btnFindCover.Text = "Найти";
      this.btnFindCover.UseVisualStyleBackColor = true;
      this.btnFindCover.Click += new System.EventHandler(this.btnFindCover_Click);
      // 
      // btnChangeInfo
      // 
      this.btnChangeInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnChangeInfo.Enabled = false;
      this.btnChangeInfo.Location = new System.Drawing.Point(10, 394);
      this.btnChangeInfo.Name = "btnChangeInfo";
      this.btnChangeInfo.Size = new System.Drawing.Size(85, 23);
      this.btnChangeInfo.TabIndex = 8;
      this.btnChangeInfo.Text = "Изменить";
      this.btnChangeInfo.UseVisualStyleBackColor = true;
      this.btnChangeInfo.Click += new System.EventHandler(this.btnChangeInfo_Click);
      // 
      // btnOpen
      // 
      this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOpen.Enabled = false;
      this.btnOpen.Location = new System.Drawing.Point(10, 423);
      this.btnOpen.Name = "btnOpen";
      this.btnOpen.Size = new System.Drawing.Size(85, 23);
      this.btnOpen.TabIndex = 7;
      this.btnOpen.Text = "Откр. папку";
      this.btnOpen.UseVisualStyleBackColor = true;
      // 
      // btnPlay
      // 
      this.btnPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnPlay.Enabled = false;
      this.btnPlay.Location = new System.Drawing.Point(104, 423);
      this.btnPlay.Name = "btnPlay";
      this.btnPlay.Size = new System.Drawing.Size(85, 23);
      this.btnPlay.TabIndex = 6;
      this.btnPlay.Text = "Играть";
      this.btnPlay.UseVisualStyleBackColor = true;
      this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
      // 
      // pictureBox
      // 
      this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.pictureBox.ContextMenuStrip = this.menuPoster;
      this.pictureBox.Location = new System.Drawing.Point(10, 3);
      this.pictureBox.Name = "pictureBox";
      this.pictureBox.Size = new System.Drawing.Size(180, 240);
      this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureBox.TabIndex = 0;
      this.pictureBox.TabStop = false;
      this.pictureBox.DoubleClick += new System.EventHandler(this.pictureBox_DoubleClick);
      // 
      // menuPoster
      // 
      this.menuPoster.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mSetPosterFromParent,
            this.menuSetCoverFromClipboard,
            this.menuDeletePoster});
      this.menuPoster.Name = "menuPoster";
      this.menuPoster.Size = new System.Drawing.Size(347, 70);
      this.menuPoster.Opening += new System.ComponentModel.CancelEventHandler(this.menuPoster_Opening);
      // 
      // mSetPosterFromParent
      // 
      this.mSetPosterFromParent.Name = "mSetPosterFromParent";
      this.mSetPosterFromParent.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
      this.mSetPosterFromParent.Size = new System.Drawing.Size(346, 22);
      this.mSetPosterFromParent.Text = "Установить постер с родительского";
      this.mSetPosterFromParent.Click += new System.EventHandler(this.mSetPosterFromParent_Click);
      // 
      // menuSetCoverFromClipboard
      // 
      this.menuSetCoverFromClipboard.Name = "menuSetCoverFromClipboard";
      this.menuSetCoverFromClipboard.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.P)));
      this.menuSetCoverFromClipboard.Size = new System.Drawing.Size(346, 22);
      this.menuSetCoverFromClipboard.Text = "Загрузить постер из буфера обмена";
      this.menuSetCoverFromClipboard.Click += new System.EventHandler(this.menuSetCoverFromClipboard_Click);
      // 
      // menuDeletePoster
      // 
      this.menuDeletePoster.Name = "menuDeletePoster";
      this.menuDeletePoster.Size = new System.Drawing.Size(346, 22);
      this.menuDeletePoster.Text = "Удалить постер";
      this.menuDeletePoster.Click += new System.EventHandler(this.menuDeletePoster_Click);
      // 
      // tbTitle
      // 
      this.tbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbTitle.Location = new System.Drawing.Point(10, 255);
      this.tbTitle.Multiline = true;
      this.tbTitle.Name = "tbTitle";
      this.tbTitle.Size = new System.Drawing.Size(179, 113);
      this.tbTitle.TabIndex = 12;
      this.tbTitle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbTitle_KeyDown);
      // 
      // splitter4
      // 
      this.splitter4.Dock = System.Windows.Forms.DockStyle.Right;
      this.splitter4.Location = new System.Drawing.Point(636, 71);
      this.splitter4.Name = "splitter4";
      this.splitter4.Size = new System.Drawing.Size(3, 449);
      this.splitter4.TabIndex = 10;
      this.splitter4.TabStop = false;
      // 
      // panel5
      // 
      this.panel5.BackColor = System.Drawing.SystemColors.Control;
      this.panel5.Controls.Add(this.listViewMainContent);
      this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel5.Location = new System.Drawing.Point(0, 71);
      this.panel5.Name = "panel5";
      this.panel5.Size = new System.Drawing.Size(636, 449);
      this.panel5.TabIndex = 11;
      // 
      // listViewMainContent
      // 
      this.listViewMainContent.ContextMenuStrip = this.menuMainList;
      this.listViewMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
      this.listViewMainContent.HideSelection = false;
      this.listViewMainContent.LargeImageList = this.imageListView;
      this.listViewMainContent.Location = new System.Drawing.Point(0, 0);
      this.listViewMainContent.Name = "listViewMainContent";
      this.listViewMainContent.Size = new System.Drawing.Size(636, 449);
      this.listViewMainContent.TabIndex = 0;
      this.listViewMainContent.UseCompatibleStateImageBehavior = false;
      this.listViewMainContent.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewMainContent_ItemSelectionChanged);
      this.listViewMainContent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listViewMainContent_KeyPress);
      this.listViewMainContent.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewMainContent_MouseDoubleClick);
      // 
      // menuMainList
      // 
      this.menuMainList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMainListAddGroup,
            this.menuMainListAddElement,
            this.toolStripMenuItem3,
            this.menuMainListSetCoverFromParent,
            this.загрузитьПостерИзБуфераОбменаToolStripMenuItem,
            this.удалитьПостерToolStripMenuItem,
            this.toolStripMenuItem6,
            this.menuMainListCut,
            this.menuMainListCopy,
            this.menuMainListPaste,
            this.toolStripMenuItem4,
            this.menuMainListDelete,
            this.toolStripMenuItem5,
            this.menuMainListRefresh});
      this.menuMainList.Name = "contextMenuStrip1";
      this.menuMainList.Size = new System.Drawing.Size(347, 248);
      this.menuMainList.Opening += new System.ComponentModel.CancelEventHandler(this.menuMainList_Opening);
      // 
      // menuMainListAddGroup
      // 
      this.menuMainListAddGroup.Image = ((System.Drawing.Image)(resources.GetObject("menuMainListAddGroup.Image")));
      this.menuMainListAddGroup.Name = "menuMainListAddGroup";
      this.menuMainListAddGroup.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Insert)));
      this.menuMainListAddGroup.Size = new System.Drawing.Size(346, 22);
      this.menuMainListAddGroup.Text = "Добавить группу";
      this.menuMainListAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
      // 
      // menuMainListAddElement
      // 
      this.menuMainListAddElement.Image = ((System.Drawing.Image)(resources.GetObject("menuMainListAddElement.Image")));
      this.menuMainListAddElement.Name = "menuMainListAddElement";
      this.menuMainListAddElement.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Insert)));
      this.menuMainListAddElement.Size = new System.Drawing.Size(346, 22);
      this.menuMainListAddElement.Text = "Добавить элемент";
      this.menuMainListAddElement.Click += new System.EventHandler(this.btnAddFile_Click);
      // 
      // toolStripMenuItem3
      // 
      this.toolStripMenuItem3.Name = "toolStripMenuItem3";
      this.toolStripMenuItem3.Size = new System.Drawing.Size(343, 6);
      // 
      // menuMainListSetCoverFromParent
      // 
      this.menuMainListSetCoverFromParent.Name = "menuMainListSetCoverFromParent";
      this.menuMainListSetCoverFromParent.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
      this.menuMainListSetCoverFromParent.Size = new System.Drawing.Size(346, 22);
      this.menuMainListSetCoverFromParent.Text = "Установить обложку с родительского";
      this.menuMainListSetCoverFromParent.Click += new System.EventHandler(this.mSetPosterFromParent_Click);
      // 
      // toolStripMenuItem6
      // 
      this.toolStripMenuItem6.Name = "toolStripMenuItem6";
      this.toolStripMenuItem6.Size = new System.Drawing.Size(343, 6);
      // 
      // menuMainListCut
      // 
      this.menuMainListCut.Image = ((System.Drawing.Image)(resources.GetObject("menuMainListCut.Image")));
      this.menuMainListCut.Name = "menuMainListCut";
      this.menuMainListCut.Size = new System.Drawing.Size(346, 22);
      this.menuMainListCut.Text = "Вырезать";
      this.menuMainListCut.Click += new System.EventHandler(this.menuMainListCut_Click);
      // 
      // menuMainListCopy
      // 
      this.menuMainListCopy.Image = ((System.Drawing.Image)(resources.GetObject("menuMainListCopy.Image")));
      this.menuMainListCopy.Name = "menuMainListCopy";
      this.menuMainListCopy.Size = new System.Drawing.Size(346, 22);
      this.menuMainListCopy.Text = "Копировать";
      this.menuMainListCopy.Click += new System.EventHandler(this.menuMainListCopy_Click);
      // 
      // menuMainListPaste
      // 
      this.menuMainListPaste.Image = ((System.Drawing.Image)(resources.GetObject("menuMainListPaste.Image")));
      this.menuMainListPaste.Name = "menuMainListPaste";
      this.menuMainListPaste.Size = new System.Drawing.Size(346, 22);
      this.menuMainListPaste.Text = "Вставить";
      this.menuMainListPaste.Click += new System.EventHandler(this.menuMainListPaste_Click);
      // 
      // toolStripMenuItem4
      // 
      this.toolStripMenuItem4.Name = "toolStripMenuItem4";
      this.toolStripMenuItem4.Size = new System.Drawing.Size(343, 6);
      // 
      // menuMainListDelete
      // 
      this.menuMainListDelete.Image = ((System.Drawing.Image)(resources.GetObject("menuMainListDelete.Image")));
      this.menuMainListDelete.Name = "menuMainListDelete";
      this.menuMainListDelete.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
      this.menuMainListDelete.Size = new System.Drawing.Size(346, 22);
      this.menuMainListDelete.Text = "Удалить";
      this.menuMainListDelete.Click += new System.EventHandler(this.btnDelete_Click);
      // 
      // toolStripMenuItem5
      // 
      this.toolStripMenuItem5.Name = "toolStripMenuItem5";
      this.toolStripMenuItem5.Size = new System.Drawing.Size(343, 6);
      // 
      // menuMainListRefresh
      // 
      this.menuMainListRefresh.Image = ((System.Drawing.Image)(resources.GetObject("menuMainListRefresh.Image")));
      this.menuMainListRefresh.Name = "menuMainListRefresh";
      this.menuMainListRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
      this.menuMainListRefresh.Size = new System.Drawing.Size(346, 22);
      this.menuMainListRefresh.Text = "Обновить";
      this.menuMainListRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
      // 
      // imageListView
      // 
      this.imageListView.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
      this.imageListView.ImageSize = new System.Drawing.Size(90, 128);
      this.imageListView.TransparentColor = System.Drawing.Color.Transparent;
      // 
      // dlgOpenImage
      // 
      this.dlgOpenImage.Filter = "Изображения|*.jpg";
      // 
      // dlgOpenFile
      // 
      this.dlgOpenFile.Filter = "Все файлы|*.*";
      // 
      // imagePoster
      // 
      this.imagePoster.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
      this.imagePoster.ImageSize = new System.Drawing.Size(180, 256);
      this.imagePoster.TransparentColor = System.Drawing.Color.Transparent;
      // 
      // загрузитьПостерИзБуфераОбменаToolStripMenuItem
      // 
      this.загрузитьПостерИзБуфераОбменаToolStripMenuItem.Name = "загрузитьПостерИзБуфераОбменаToolStripMenuItem";
      this.загрузитьПостерИзБуфераОбменаToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.P)));
      this.загрузитьПостерИзБуфераОбменаToolStripMenuItem.Size = new System.Drawing.Size(346, 22);
      this.загрузитьПостерИзБуфераОбменаToolStripMenuItem.Text = "Загрузить постер из буфера обмена";
      this.загрузитьПостерИзБуфераОбменаToolStripMenuItem.Click += new System.EventHandler(this.menuSetCoverFromClipboard_Click);
      // 
      // удалитьПостерToolStripMenuItem
      // 
      this.удалитьПостерToolStripMenuItem.Name = "удалитьПостерToolStripMenuItem";
      this.удалитьПостерToolStripMenuItem.Size = new System.Drawing.Size(346, 22);
      this.удалитьПостерToolStripMenuItem.Text = "Удалить постер";
      this.удалитьПостерToolStripMenuItem.Click += new System.EventHandler(this.menuDeletePoster_Click);
      // 
      // frmMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(839, 542);
      this.Controls.Add(this.panel5);
      this.Controls.Add(this.splitter4);
      this.Controls.Add(this.panel4);
      this.Controls.Add(this.splitter2);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this.menuStrip1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.KeyPreview = true;
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "frmMain";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Персональная Медиа Коллекция";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
      this.Load += new System.EventHandler(this.frmMain_Load);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel4.ResumeLayout(false);
      this.panel4.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
      this.menuPoster.ResumeLayout(false);
      this.panel5.ResumeLayout(false);
      this.menuMainList.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Splitter splitter2;
    private System.Windows.Forms.Panel panel4;
    private System.Windows.Forms.Splitter splitter4;
    private System.Windows.Forms.Panel panel5;
    private System.Windows.Forms.ListView listViewMainContent;
    private System.Windows.Forms.ImageList imageListView;
    private System.Windows.Forms.Button pathBack;
    private System.Windows.Forms.ImageList imageListInterface;
    private System.Windows.Forms.PictureBox pictureBox;
    private System.Windows.Forms.Button btnFindCover;
    private System.Windows.Forms.Button btnChangeInfo;
    private System.Windows.Forms.Button btnOpen;
    private System.Windows.Forms.Button btnPlay;
    private System.Windows.Forms.CheckBox cbWatched;
    private System.Windows.Forms.Label lbTitle;
    private System.Windows.Forms.Button btnAddGroup;
    private System.Windows.Forms.Button btnAddFile;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.Button btnRefresh;
    private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem menuAddGroup;
    private System.Windows.Forms.ToolStripMenuItem menuAddFile;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem menuDelete;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    private System.Windows.Forms.ToolStripMenuItem menuRefresh;
    private System.Windows.Forms.OpenFileDialog dlgOpenImage;
    private System.Windows.Forms.TextBox tbTitle;
    private System.Windows.Forms.OpenFileDialog dlgOpenFile;
    public System.Windows.Forms.ImageList imagePoster;
    private System.Windows.Forms.ContextMenuStrip menuPoster;
    private System.Windows.Forms.ToolStripMenuItem mSetPosterFromParent;
    private System.Windows.Forms.ToolStripStatusLabel MediaPath;
    private System.Windows.Forms.ToolStripMenuItem настройкаToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem menuSearchServices;
    private System.Windows.Forms.ContextMenuStrip menuMainList;
    private System.Windows.Forms.ToolStripMenuItem menuMainListAddGroup;
    private System.Windows.Forms.ToolStripMenuItem menuMainListAddElement;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
    private System.Windows.Forms.ToolStripMenuItem menuMainListSetCoverFromParent;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
    private System.Windows.Forms.ToolStripMenuItem menuMainListCut;
    private System.Windows.Forms.ToolStripMenuItem menuMainListCopy;
    private System.Windows.Forms.ToolStripMenuItem menuMainListPaste;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
    private System.Windows.Forms.ToolStripMenuItem menuMainListDelete;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
    private System.Windows.Forms.ToolStripMenuItem menuMainListRefresh;
    private System.Windows.Forms.ToolStripMenuItem menuSetCoverFromClipboard;
    private System.Windows.Forms.ToolStripMenuItem menuDeletePoster;
    private System.Windows.Forms.ToolStripMenuItem загрузитьПостерИзБуфераОбменаToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem удалитьПостерToolStripMenuItem;
  }
}

