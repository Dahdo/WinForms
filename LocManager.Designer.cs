namespace WinFormsLab {
    partial class LocManager {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocManager));
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStrip = new ToolStripMenuItem();
            saveToolStrip = new ToolStripMenuItem();
            saveAsToolStrip = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            newEntryToolStrip = new ToolStripMenuItem();
            deleteEntryToolStrip = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            splitContainer = new SplitContainer();
            treeView = new TreeView();
            tabControl = new TabControl();
            searchTab = new TabPage();
            searchListView = new ListView();
            locKeyColumn = new ColumnHeader();
            pathColumn = new ColumnHeader();
            debugColumn = new ColumnHeader();
            flowLayoutPanel1 = new FlowLayoutPanel();
            searchTextBox = new TextBox();
            searchButton = new Button();
            detailsTab = new TabPage();
            detailsListView = new ListView();
            languageColumn = new ColumnHeader();
            translationColumn = new ColumnHeader();
            groupBox = new GroupBox();
            debugTextBox = new TextBox();
            pathTextBox = new TextBox();
            fileSystemWatcher = new FileSystemWatcher();
            statusStrip = new StatusStrip();
            translateSplitButton = new ToolStripSplitButton();
            translateProgressBar = new ToolStripProgressBar();
            contextMenuStrip1 = new ContextMenuStrip(components);
            translateProgressLabel = new ToolStripStatusLabel();
            menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            tabControl.SuspendLayout();
            searchTab.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            detailsTab.SuspendLayout();
            groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher).BeginInit();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, helpToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(784, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStrip, saveToolStrip, saveAsToolStrip });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // openToolStrip
            // 
            openToolStrip.Name = "openToolStrip";
            openToolStrip.Size = new Size(120, 22);
            openToolStrip.Text = "Open";
            openToolStrip.Click += openToolStrip_Click;
            // 
            // saveToolStrip
            // 
            saveToolStrip.Name = "saveToolStrip";
            saveToolStrip.Size = new Size(120, 22);
            saveToolStrip.Text = "Save";
            // 
            // saveAsToolStrip
            // 
            saveAsToolStrip.Name = "saveAsToolStrip";
            saveAsToolStrip.Size = new Size(120, 22);
            saveAsToolStrip.Text = "Save As..";
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newEntryToolStrip, deleteEntryToolStrip });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 20);
            editToolStripMenuItem.Text = "Edit";
            // 
            // newEntryToolStrip
            // 
            newEntryToolStrip.Name = "newEntryToolStrip";
            newEntryToolStrip.Size = new Size(137, 22);
            newEntryToolStrip.Text = "New Entry";
            // 
            // deleteEntryToolStrip
            // 
            deleteEntryToolStrip.Name = "deleteEntryToolStrip";
            deleteEntryToolStrip.Size = new Size(137, 22);
            deleteEntryToolStrip.Text = "Delete Entry";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(0, 24);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(treeView);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(tabControl);
            splitContainer.Size = new Size(784, 437);
            splitContainer.SplitterDistance = 261;
            splitContainer.TabIndex = 1;
            // 
            // treeView
            // 
            treeView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            treeView.Location = new Point(0, 0);
            treeView.Name = "treeView";
            treeView.Size = new Size(261, 412);
            treeView.TabIndex = 0;
            treeView.NodeMouseClick += treeView_NodeMouseClick;
            // 
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Controls.Add(searchTab);
            tabControl.Controls.Add(detailsTab);
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(519, 412);
            tabControl.TabIndex = 0;
            // 
            // searchTab
            // 
            searchTab.Controls.Add(searchListView);
            searchTab.Controls.Add(flowLayoutPanel1);
            searchTab.Location = new Point(4, 24);
            searchTab.Name = "searchTab";
            searchTab.Padding = new Padding(3);
            searchTab.Size = new Size(511, 384);
            searchTab.TabIndex = 0;
            searchTab.Text = "Search";
            searchTab.UseVisualStyleBackColor = true;
            // 
            // searchListView
            // 
            searchListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            searchListView.Columns.AddRange(new ColumnHeader[] { locKeyColumn, pathColumn, debugColumn });
            searchListView.FullRowSelect = true;
            searchListView.Location = new Point(3, 38);
            searchListView.Name = "searchListView";
            searchListView.Size = new Size(505, 343);
            searchListView.TabIndex = 1;
            searchListView.UseCompatibleStateImageBehavior = false;
            searchListView.View = View.Details;
            // 
            // locKeyColumn
            // 
            locKeyColumn.Text = "LocKey";
            // 
            // pathColumn
            // 
            pathColumn.Text = "Path";
            // 
            // debugColumn
            // 
            debugColumn.Text = "Debug";
            debugColumn.Width = 400;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(searchTextBox);
            flowLayoutPanel1.Controls.Add(searchButton);
            flowLayoutPanel1.Location = new Point(3, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(505, 29);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // searchTextBox
            // 
            searchTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            searchTextBox.Location = new Point(3, 3);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.Size = new Size(416, 23);
            searchTextBox.TabIndex = 0;
            searchTextBox.KeyPress += searchTextBox_KeyPress;
            // 
            // searchButton
            // 
            searchButton.Location = new Point(425, 3);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(75, 23);
            searchButton.TabIndex = 1;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchButton_Click;
            // 
            // detailsTab
            // 
            detailsTab.Controls.Add(detailsListView);
            detailsTab.Controls.Add(groupBox);
            detailsTab.Location = new Point(4, 24);
            detailsTab.Name = "detailsTab";
            detailsTab.Padding = new Padding(3);
            detailsTab.Size = new Size(511, 384);
            detailsTab.TabIndex = 1;
            detailsTab.Text = "Details";
            detailsTab.UseVisualStyleBackColor = true;
            // 
            // detailsListView
            // 
            detailsListView.Columns.AddRange(new ColumnHeader[] { languageColumn, translationColumn });
            detailsListView.Dock = DockStyle.Fill;
            detailsListView.FullRowSelect = true;
            detailsListView.Location = new Point(3, 169);
            detailsListView.Name = "detailsListView";
            detailsListView.Size = new Size(505, 212);
            detailsListView.TabIndex = 1;
            detailsListView.UseCompatibleStateImageBehavior = false;
            detailsListView.View = View.Details;
            // 
            // languageColumn
            // 
            languageColumn.Text = "Language";
            languageColumn.Width = 100;
            // 
            // translationColumn
            // 
            translationColumn.Text = "Translation";
            translationColumn.Width = 400;
            // 
            // groupBox
            // 
            groupBox.Controls.Add(debugTextBox);
            groupBox.Controls.Add(pathTextBox);
            groupBox.Dock = DockStyle.Top;
            groupBox.Location = new Point(3, 3);
            groupBox.Name = "groupBox";
            groupBox.Size = new Size(505, 166);
            groupBox.TabIndex = 0;
            groupBox.TabStop = false;
            groupBox.Text = "Translation Details";
            // 
            // debugTextBox
            // 
            debugTextBox.Dock = DockStyle.Bottom;
            debugTextBox.Location = new Point(3, 48);
            debugTextBox.Multiline = true;
            debugTextBox.Name = "debugTextBox";
            debugTextBox.Size = new Size(499, 115);
            debugTextBox.TabIndex = 1;
            // 
            // pathTextBox
            // 
            pathTextBox.Dock = DockStyle.Top;
            pathTextBox.Location = new Point(3, 19);
            pathTextBox.Name = "pathTextBox";
            pathTextBox.ReadOnly = true;
            pathTextBox.Size = new Size(499, 23);
            pathTextBox.TabIndex = 0;
            pathTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // fileSystemWatcher
            // 
            fileSystemWatcher.EnableRaisingEvents = true;
            fileSystemWatcher.SynchronizingObject = this;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { translateSplitButton, translateProgressLabel, translateProgressBar });
            statusStrip.Location = new Point(0, 439);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(784, 22);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "statusStrip";
            // 
            // translateSplitButton
            // 
            translateSplitButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            translateSplitButton.Image = (Image)resources.GetObject("translateSplitButton.Image");
            translateSplitButton.ImageTransparentColor = Color.Magenta;
            translateSplitButton.Name = "translateSplitButton";
            translateSplitButton.Size = new Size(69, 20);
            translateSplitButton.Text = "Translate";
            // 
            // translateProgressBar
            // 
            translateProgressBar.Alignment = ToolStripItemAlignment.Right;
            translateProgressBar.Name = "translateProgressBar";
            translateProgressBar.RightToLeft = RightToLeft.No;
            translateProgressBar.Size = new Size(100, 16);
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // translateProgressLabel
            // 
            translateProgressLabel.Name = "translateProgressLabel";
            translateProgressLabel.Size = new Size(0, 17);
            // 
            // LocManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(statusStrip);
            Controls.Add(splitContainer);
            Controls.Add(menuStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            MinimumSize = new Size(800, 500);
            Name = "LocManager";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LocManager";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            searchTab.ResumeLayout(false);
            searchTab.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            detailsTab.ResumeLayout(false);
            groupBox.ResumeLayout(false);
            groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStrip;
        private ToolStripMenuItem saveToolStrip;
        private ToolStripMenuItem saveAsToolStrip;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem newEntryToolStrip;
        private ToolStripMenuItem deleteEntryToolStrip;
        private ToolStripMenuItem helpToolStripMenuItem;
        private SplitContainer splitContainer;
        private TreeView treeView;
        private TabControl tabControl;
        private TabPage detailsTab;
        private FileSystemWatcher fileSystemWatcher;
        private StatusStrip statusStrip;
        private TabPage searchTab;
        private GroupBox groupBox;
        private ContextMenuStrip contextMenuStrip1;
        private TextBox debugTextBox;
        private TextBox pathTextBox;
        private ListView detailsListView;
        public ColumnHeader languageColumn;
        public ColumnHeader translationColumn;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
        private TextBox searchTextBox;
        private ListView searchListView;
        public ColumnHeader locKeyColumn;
        private ColumnHeader pathColumn;
        private ColumnHeader debugColumn;
        private Button searchButton;
        private ToolStripSplitButton translateSplitButton;
        private ToolStripProgressBar translateProgressBar;
        private ToolStripStatusLabel translateProgressLabel;
    }
}