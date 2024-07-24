using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Text.Json;

namespace Summariser
{
    internal class FileManager
    {
        private static readonly string PathInformation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private string mLastPath = PathInformation;

        public string LastPath { get => mLastPath; set => mLastPath = value; }


        public FileManager() { } 

        public void IdentifyPdfFilesAndAddToListBox(CheckedListBox list_files)
        {         
            foreach (string file in Directory.GetFileSystemEntries(mLastPath, "*.pdf", SearchOption.AllDirectories))
                list_files.Items.Add(file, true);
        }

        public void SaveArrayAsText(string fileName, string[] strings)
        {
            File.WriteAllLines(fileName, strings);
        }
        public static string EscapeForCsv(string input)
        {
            if (input.Contains("\"") || input.Contains(",") || input.Contains("\n") || input.Contains("\r"))
            {
                input = input.Replace("\"", "\"\"");
            }
            return $"\"{input}\"";
        }
        public void SaveExtractedCommentsCSV(string fileName, Dictionary<string, List<Comment>> commentData)
        {
            using (StreamWriter outputFile = new StreamWriter(fileName))

                foreach (KeyValuePair<string, List<Comment>> PdfCommentBatch in commentData)
                    foreach (Comment Comment in PdfCommentBatch.Value)
                    {
                        outputFile.WriteLine($"{EscapeForCsv(PdfCommentBatch.Key)},{Comment.Page},{EscapeForCsv(Comment.Text)}");
                    }
            //outputFile.WriteLine(PdfCommentBatch.Key + "," + Comment.Page + "," + Comment.Text);
        }

        public void SaveExtractedCommentsAsJson(string fileName, Dictionary<string, List<Comment>> commentData)
        {
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(commentData, jsonOptions);
            File.WriteAllText(fileName, jsonString);
        }
    }
}
