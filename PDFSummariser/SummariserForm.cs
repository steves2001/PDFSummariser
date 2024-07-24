using System;
using System.IO;
using System.Windows.Forms;
using Dialogs;
namespace Summariser
{
    public partial class SummariserForm : Form
    {
        private readonly PDFEditor pdfEditor = new PDFEditor();
        private readonly FileManager fileManager = new FileManager();

        public SummariserForm()
        {
            InitializeComponent();
        }
        
        private void Form_Load(object sender, EventArgs e)
        {
            UpdateStatusBarPath(fileManager.LastPath);
        }


        /* Tool strip related click methods --------------------------------- */

        /* File Menu */
        private void OpenFolder(object sender, EventArgs e)
        {
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;

            if (!string.IsNullOrEmpty(fileManager.LastPath)
                && Directory.Exists(fileManager.LastPath))
            {
                folderBrowserDialog.SelectedPath = fileManager.LastPath;
            }

            DialogResult dialogResult = folderBrowserDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                fileManager.LastPath = Path.Combine(folderBrowserDialog.SelectedPath, "");
                UpdateStatusBarPath(fileManager.LastPath);

                CheckedListBox_PdfFilenames.Items.Clear();
                try
                {
                    fileManager.IdentifyPdfFilesAndAddToListBox(CheckedListBox_PdfFilenames);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Error opening folder or subfolder: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                
            }

            UpdateStatusBarSelectedFiles(CheckedListBox_PdfFilenames.CheckedItems.Count);

            if(CheckedListBox_PdfFilenames.CheckedItems.Count == 0) 
                return;  
            
            ToolStripMenuItem_Pdf.Enabled = true;
            
        }
        private void SaveExtractedCommentsText(object sender, EventArgs e)
        {
            ConfigureSaveFileDialog(
                "txt",
                "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                "Save Comments as Text",
                "SummarisedText");

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    fileManager.SaveArrayAsText(saveFileDialog.FileName, TextField_PdfComments.Lines);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Error saving file: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void SaveExtractedCommentsCSV(object sender, EventArgs e)
        {
            ConfigureSaveFileDialog(
                "csv",
                "Comma separated value files (*.csv)|*.csv|All files (*.*)|*.*",
                "Save Comments as Comma Separated Values",
                "SummarisedText");

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    fileManager.SaveExtractedCommentsCSV(saveFileDialog.FileName, pdfEditor.AllCommentData);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Error saving file: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void SaveExtractedCommentsJson(object sender, EventArgs e)
        {
            ConfigureSaveFileDialog(
                "json",
                "JSON files (*.json)|*.json|All files (*.*)|*.*",
                "Save Comments as JSON",
                "SummarisedComments");

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    fileManager.SaveExtractedCommentsAsJson(saveFileDialog.FileName, pdfEditor.AllCommentData);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Error saving file: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
        private void ExitApplication(object sender, EventArgs e)
        {
            if (Application.MessageLoop)
            {
                // WinForms app
                Application.Exit();
            }
            else
            {
                // Console app
                Environment.Exit(1);
            }
        }

        /* PDF Menu */
        private void ExtractPdfComments(object sender, EventArgs e)
        {
            if (ZeroFilesAreSelectedInFileList("No files were selected to extract comments from.")) 
                return;

            TextField_PdfComments.Clear();
            pdfEditor.ExtractCommentsFromSelectedPdfFiles(CheckedListBox_PdfFilenames);
            TextField_PdfComments.AppendText(pdfEditor.ConvertAllCommentsToString());
        }

        private void AddPageToPdfs(object sender, EventArgs e)
        {
            if(ZeroFilesAreSelectedInFileList("No files were selected to extract add pages to.")) 
                return;

            pdfEditor.AddBlankPageToSelectedPdfFiles(CheckedListBox_PdfFilenames);
        }

        private void AddTicksToPdfs(object sender, EventArgs e)
        {
            if (ZeroFilesAreSelectedInFileList("No files were selected to extract add pages to.")) 
                return;

            pdfEditor.AddTicksToSelectedPdfFiles(CheckedListBox_PdfFilenames);
        }

        private void AddCommentToPdfs(object sender, EventArgs e)
        {
            if (ZeroFilesAreSelectedInFileList("No files were selected to extract add comment to."))
                return;

            string UserComment = InputDialog.Show("Enter comment text.");
            if (UserComment == null) return;

            pdfEditor.AddFooterCommentToSelectedPdfFiles(CheckedListBox_PdfFilenames, UserComment);
        }

        /* File list box related methods ---------------------------------- */
        private Boolean ZeroFilesAreSelectedInFileList(string errormessage)
        {
            if (string.IsNullOrEmpty(errormessage))
            {
                throw new ArgumentException($"'{nameof(errormessage)}' cannot be null or empty.",
                                            nameof(errormessage));
            }

            if (CheckedListBox_PdfFilenames.CheckedItems.Count == 0)
            {
                MessageBox.Show(errormessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        private void CheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Delay the handling to after the check state is actually updated
            this.BeginInvoke((MethodInvoker)(() =>
            {
                UpdateStatusBarSelectedFiles(CheckedListBox_PdfFilenames.CheckedItems.Count);

                if (CheckedListBox_PdfFilenames.CheckedItems.Count == 0)
                    ToolStripMenuItem_Pdf.Enabled = false;
                else
                    ToolStripMenuItem_Pdf.Enabled = true;
            }));
        }


        /* Status Bar related methods --------------------------------------- */
        private void UpdateStatusBarPath(string path)
        {
            toolStripStatusLabel_Path.Text = $"Path: {path}";
        }

        private void UpdateStatusBarSelectedFiles(int fileCount)
        {
            toolStripStatusLabel_Selected.Text = $"Selected files: {fileCount}";
        }

        /* File Dialog related methods --------------------------------------- */
        private void ConfigureSaveFileDialog(
            string defaultExt,
            string filter,
            string title,
            string defaultFileName)
        {
            saveFileDialog.DefaultExt = defaultExt;
            saveFileDialog.Filter = filter;
            saveFileDialog.Title = title;
            saveFileDialog.FileName = defaultFileName;
        }

        
    }
}
