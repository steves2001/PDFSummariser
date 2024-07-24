using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Annot;
using iText.Kernel.Pdf.Canvas;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
namespace Summariser
{
    internal class PDFEditor
    {
        private Dictionary<string, List<Comment>> mAllCommentData = new Dictionary<string, List<Comment>>();

        public Dictionary<string, List<Comment>> AllCommentData { get => mAllCommentData; set => mAllCommentData = value; }

        public void ExtractCommentsFromSelectedPdfFiles(CheckedListBox checkedFileList)
        {
            AllCommentData.Clear();

            foreach (string file in checkedFileList.CheckedItems)
                AllCommentData.Add(file, GetCommentsAsListFromPdfFile(file));
        }

        public void AddBlankPageToSelectedPdfFiles(CheckedListBox checkedFileList)
        {
            foreach (string file in checkedFileList.CheckedItems)
                AddBlankPageToFront(file);
        }

        public void AddTicksToSelectedPdfFiles(CheckedListBox checkedFileList)
        {
            foreach (string file in checkedFileList.CheckedItems)
                AddGreenTickToEveryPage(file);
        }

        public void AddFooterCommentToSelectedPdfFiles(CheckedListBox checkedFileList, string comment)
        {
            foreach (string file in checkedFileList.CheckedItems)
                AddTextToFootOfEveryPage(file, comment);
        }

        public List<Comment> GetCommentsAsListFromPdfFile(string fileName)
        {
            List<Comment> CommentData = new List<Comment>();

            using (PdfDocument pdfDoc = new PdfDocument(new PdfReader(fileName)))
            {
                for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
                {
                    var page = pdfDoc.GetPage(i);
                    var annotator = page.GetAnnotations();

                    foreach (var annot in annotator)
                    {
                        string text = string.Empty;
                        switch (annot)
                        {
                            case PdfFreeTextAnnotation freeTextAnnot:
                                text = freeTextAnnot.GetContents().ToUnicodeString();
                                break;
                            case PdfTextAnnotation textAnnot:
                                text = textAnnot.GetContents().ToUnicodeString();
                                break;
                            case PdfStampAnnotation stampAnnot:
                                text = stampAnnot.GetContents().ToUnicodeString();
                                break;
                            case PdfLinkAnnotation linkAnnot:
                                text = linkAnnot.GetContents().ToUnicodeString();
                                break;
                            case PdfFileAttachmentAnnotation fileAnnot:
                                text = fileAnnot.GetContents().ToUnicodeString();
                                break;
                            case PdfTextMarkupAnnotation markupAnnot:
                                text = markupAnnot.GetContents().ToUnicodeString();
                                break;                              
                        }

                        if (!string.IsNullOrEmpty(text))
                        {
                            Comment comment = new Comment(i.ToString(), text);
                            CommentData.Add(comment);
                        }
                    }
                }
            }

            return CommentData;
        }

        public string ConvertAllCommentsToString()
        {
            StringBuilder CommentText = new StringBuilder();

            foreach (KeyValuePair<string, List<Comment>> PdfCommentBatch in AllCommentData)
            {
                CommentText.Append(PdfCommentBatch.Key);
                CommentText.AppendLine();

                foreach (Comment Comment in PdfCommentBatch.Value)
                {
                    CommentText.Append($"Page {Comment.Page} : {Comment.Text}");
                    CommentText.AppendLine();
                }
            }

            return CommentText.ToString();
        }

        public void AddBlankPageToFront(string filePath)
        {
            using (var reader = new PdfReader(filePath))
            using (var memoryStream = new MemoryStream())
            {
                using (var pdfDoc = new PdfDocument(reader, new PdfWriter(memoryStream)))
                {
                    pdfDoc.AddNewPage(1, PageSize.A4);
                }
                File.WriteAllBytes(filePath, memoryStream.ToArray());
            }
        }

        public void AddGreenTickToEveryPage(string filePath)
        {
            using (var reader = new PdfReader(filePath))
            using (var memoryStream = new MemoryStream())
            {
                using (var pdfDoc = new PdfDocument(reader, new PdfWriter(memoryStream)))
                {
                    float tickSize = 10f; // Half the size of the original tick
                    float margin = 20f; // Margin from the top-left corner

                    for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
                    {
                        PdfPage page = pdfDoc.GetPage(i);
                        PdfCanvas canvas = new PdfCanvas(page);
                        canvas.SetStrokeColor(ColorConstants.GREEN);
                        canvas.SetLineWidth(1.5f);

                        // Get page height for positioning the tick at the top left
                        float pageHeight = page.GetPageSize().GetHeight();

                        // Draw the tick in the top-left corner
                        canvas.MoveTo(margin, pageHeight - margin);
                        canvas.LineTo(margin + tickSize / 2, pageHeight - margin - tickSize / 2);
                        canvas.LineTo(margin + tickSize, pageHeight - margin + tickSize);
                        canvas.Stroke();
                    }
                }
                File.WriteAllBytes(filePath, memoryStream.ToArray());
            }
        }



        public void AddTextToFootOfEveryPage(string filePath, string footerText)
        {
            using (var reader = new PdfReader(filePath))
            using (var memoryStream = new MemoryStream())
            {
                using (var pdfDoc = new PdfDocument(reader, new PdfWriter(memoryStream)))
                {
                    PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
                    for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
                    {
                        PdfPage page = pdfDoc.GetPage(i);
                        PdfCanvas canvas = new PdfCanvas(page);
                        canvas.BeginText();
                        canvas.SetFontAndSize(font, 10);
                        canvas.MoveText(15, 15);
                        canvas.ShowText(footerText);
                        canvas.EndText();
                    }
                }
                File.WriteAllBytes(filePath, memoryStream.ToArray());
            }
        }
    }

}


