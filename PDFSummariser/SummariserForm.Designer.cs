namespace Summariser
{
    partial class SummariserForm
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
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItem_File = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.textToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commaSeparatedValuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jSONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Pdf = new System.Windows.Forms.ToolStripMenuItem();
            this.commentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBlankPageToStartOfFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tickEveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFooterMessageToEveryPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.CheckedListBox_PdfFilenames = new System.Windows.Forms.CheckedListBox();
            this.TextField_PdfComments = new System.Windows.Forms.TextBox();
            this.statusStrip_File = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_Path = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_Selected = new System.Windows.Forms.ToolStripStatusLabel();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip_File.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_File,
            this.ToolStripMenuItem_Pdf});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(929, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItem_File
            // 
            this.ToolStripMenuItem_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.ToolStripMenuItem_File.Name = "ToolStripMenuItem_File";
            this.ToolStripMenuItem_File.Size = new System.Drawing.Size(37, 20);
            this.ToolStripMenuItem_File.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.openToolStripMenuItem.Text = "Open Folder";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenFolder);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textToolStripMenuItem,
            this.commaSeparatedValuesToolStripMenuItem,
            this.jSONToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(212, 22);
            this.toolStripMenuItem1.Text = "Save Extracted Comments";
            // 
            // textToolStripMenuItem
            // 
            this.textToolStripMenuItem.Name = "textToolStripMenuItem";
            this.textToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.textToolStripMenuItem.Text = "Text";
            this.textToolStripMenuItem.Click += new System.EventHandler(this.SaveExtractedCommentsText);
            // 
            // commaSeparatedValuesToolStripMenuItem
            // 
            this.commaSeparatedValuesToolStripMenuItem.Name = "commaSeparatedValuesToolStripMenuItem";
            this.commaSeparatedValuesToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.commaSeparatedValuesToolStripMenuItem.Text = "Comma Separated Values";
            this.commaSeparatedValuesToolStripMenuItem.Click += new System.EventHandler(this.SaveExtractedCommentsCSV);
            // 
            // jSONToolStripMenuItem
            // 
            this.jSONToolStripMenuItem.Name = "jSONToolStripMenuItem";
            this.jSONToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.jSONToolStripMenuItem.Text = "JSON";
            this.jSONToolStripMenuItem.Click += new System.EventHandler(this.SaveExtractedCommentsJson);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitApplication);
            // 
            // ToolStripMenuItem_Pdf
            // 
            this.ToolStripMenuItem_Pdf.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.commentsToolStripMenuItem,
            this.addBlankPageToStartOfFilesToolStripMenuItem,
            this.tickEveToolStripMenuItem,
            this.addFooterMessageToEveryPageToolStripMenuItem});
            this.ToolStripMenuItem_Pdf.Enabled = false;
            this.ToolStripMenuItem_Pdf.Name = "ToolStripMenuItem_Pdf";
            this.ToolStripMenuItem_Pdf.Size = new System.Drawing.Size(70, 20);
            this.ToolStripMenuItem_Pdf.Text = "PDF Tasks";
            // 
            // commentsToolStripMenuItem
            // 
            this.commentsToolStripMenuItem.Name = "commentsToolStripMenuItem";
            this.commentsToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.commentsToolStripMenuItem.Text = "Extract Comments";
            this.commentsToolStripMenuItem.Click += new System.EventHandler(this.ExtractPdfComments);
            // 
            // addBlankPageToStartOfFilesToolStripMenuItem
            // 
            this.addBlankPageToStartOfFilesToolStripMenuItem.Name = "addBlankPageToStartOfFilesToolStripMenuItem";
            this.addBlankPageToStartOfFilesToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.addBlankPageToStartOfFilesToolStripMenuItem.Text = "Add blank page to start of files";
            this.addBlankPageToStartOfFilesToolStripMenuItem.Click += new System.EventHandler(this.AddPageToPdfs);
            // 
            // tickEveToolStripMenuItem
            // 
            this.tickEveToolStripMenuItem.Name = "tickEveToolStripMenuItem";
            this.tickEveToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.tickEveToolStripMenuItem.Text = "Tick every page";
            this.tickEveToolStripMenuItem.Click += new System.EventHandler(this.AddTicksToPdfs);
            // 
            // addFooterMessageToEveryPageToolStripMenuItem
            // 
            this.addFooterMessageToEveryPageToolStripMenuItem.Name = "addFooterMessageToEveryPageToolStripMenuItem";
            this.addFooterMessageToEveryPageToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.addFooterMessageToEveryPageToolStripMenuItem.Text = "Add footer message to every page";
            this.addFooterMessageToEveryPageToolStripMenuItem.Click += new System.EventHandler(this.AddCommentToPdfs);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.CheckedListBox_PdfFilenames);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.TextField_PdfComments);
            this.splitContainer1.Size = new System.Drawing.Size(929, 458);
            this.splitContainer1.SplitterDistance = 309;
            this.splitContainer1.TabIndex = 1;
            // 
            // CheckedListBox_PdfFilenames
            // 
            this.CheckedListBox_PdfFilenames.CheckOnClick = true;
            this.CheckedListBox_PdfFilenames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CheckedListBox_PdfFilenames.FormattingEnabled = true;
            this.CheckedListBox_PdfFilenames.Location = new System.Drawing.Point(0, 0);
            this.CheckedListBox_PdfFilenames.Name = "CheckedListBox_PdfFilenames";
            this.CheckedListBox_PdfFilenames.ScrollAlwaysVisible = true;
            this.CheckedListBox_PdfFilenames.Size = new System.Drawing.Size(309, 458);
            this.CheckedListBox_PdfFilenames.TabIndex = 0;
            this.CheckedListBox_PdfFilenames.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CheckedListBox_ItemCheck);
            // 
            // TextField_PdfComments
            // 
            this.TextField_PdfComments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextField_PdfComments.Location = new System.Drawing.Point(0, 0);
            this.TextField_PdfComments.Multiline = true;
            this.TextField_PdfComments.Name = "TextField_PdfComments";
            this.TextField_PdfComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextField_PdfComments.Size = new System.Drawing.Size(616, 458);
            this.TextField_PdfComments.TabIndex = 0;
            // 
            // statusStrip_File
            // 
            this.statusStrip_File.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_Selected,
            this.toolStripStatusLabel_Path});
            this.statusStrip_File.Location = new System.Drawing.Point(0, 460);
            this.statusStrip_File.Name = "statusStrip_File";
            this.statusStrip_File.Size = new System.Drawing.Size(929, 22);
            this.statusStrip_File.TabIndex = 2;
            // 
            // toolStripStatusLabel_Path
            // 
            this.toolStripStatusLabel_Path.Name = "toolStripStatusLabel_Path";
            this.toolStripStatusLabel_Path.Size = new System.Drawing.Size(733, 17);
            this.toolStripStatusLabel_Path.Spring = true;
            this.toolStripStatusLabel_Path.Text = "Path:";
            this.toolStripStatusLabel_Path.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel_Selected
            // 
            this.toolStripStatusLabel_Selected.AutoSize = false;
            this.toolStripStatusLabel_Selected.Name = "toolStripStatusLabel_Selected";
            this.toolStripStatusLabel_Selected.Size = new System.Drawing.Size(150, 17);
            this.toolStripStatusLabel_Selected.Text = "Selected files: 0";
            this.toolStripStatusLabel_Selected.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SummariserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 482);
            this.Controls.Add(this.statusStrip_File);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SummariserForm";
            this.Text = "PDF Comment Tool";
            this.Load += new System.EventHandler(this.Form_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip_File.ResumeLayout(false);
            this.statusStrip_File.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_File;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Pdf;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox TextField_PdfComments;
        private System.Windows.Forms.CheckedListBox CheckedListBox_PdfFilenames;
        private System.Windows.Forms.StatusStrip statusStrip_File;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Path;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem textToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commaSeparatedValuesToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem jSONToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addBlankPageToStartOfFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tickEveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFooterMessageToEveryPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Selected;
    }
}

