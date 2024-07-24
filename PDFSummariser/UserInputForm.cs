using System;
using System.Windows.Forms;

namespace Dialogs
{

    public class InputDialog : Form
    {
        private Label label;
        private TextBox textBox;
        private Button buttonOk;
        private Button buttonCancel;

        public string InputText { get; private set; }

        public InputDialog(string prompt)
        {
            label = new Label() { Left = 10, Top = 10, Text = prompt, AutoSize = true };
            textBox = new TextBox() { Left = 10, Top = 40, Width = 260 };
            buttonOk = new Button() { Text = "OK", Left = 60, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            buttonCancel = new Button() { Text = "Cancel", Left = 170, Width = 100, Top = 70, DialogResult = DialogResult.Cancel };

            buttonOk.Click += (sender, e) => { InputText = textBox.Text; Close(); };
            buttonCancel.Click += (sender, e) => { Close(); };

            Controls.Add(label);
            Controls.Add(textBox);
            Controls.Add(buttonOk);
            Controls.Add(buttonCancel);

            AcceptButton = buttonOk;
            CancelButton = buttonCancel;
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            ClientSize = new System.Drawing.Size(280, 110);
        }

        public static string Show(string prompt)
        {
            using (InputDialog dialog = new InputDialog(prompt))
            {
                return dialog.ShowDialog() == DialogResult.OK ? dialog.InputText : null;
            }
        }
    }
}
