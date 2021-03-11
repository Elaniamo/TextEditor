using System;
using System.Drawing;
using System.Windows.Forms;

namespace TextEditor
{
    public interface IMainForm
    {
        string FilePath { get; }
        string Content { get; set; }
        void SetSymbolCount(int count);
        event EventHandler FileOpenClick;
        event EventHandler FileSaveClick;
        event EventHandler ContentChanged;
    }

    public partial class MainForm : Form, IMainForm
    {
        public MainForm()
        {
            InitializeComponent();
            bOpenFile.Click += BOpenFile_Click;
            bSaveFile.Click += BSaveFile_Click;
            fldContent.TextChanged += FldContent_TextChanged;
            bSelectFile.Click += BSelectFile_Click;
            numSizeFont.Click += NumSizeFont_Click;

        }

        #region forwarding events
        private void FldContent_TextChanged(object sender, EventArgs e)
        {
            ContentChanged?.Invoke(this, EventArgs.Empty);
        }

        private void BSaveFile_Click(object sender, EventArgs e)
        {
            FileSaveClick?.Invoke(this, EventArgs.Empty);
        }

        private void BOpenFile_Click(object sender, EventArgs e)
        {
            FileOpenClick?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region realisation IMainForm
        public string FilePath { get { return fldFilePath.Text; } }
        public string Content { get { return fldContent.Text; } set { fldContent.Text = value; } }

        public void SetSymbolCount(int count)
        {
            toolStripStatusLabelSymbolCount.Text = count.ToString();
        }

        public event EventHandler FileOpenClick;
        public event EventHandler FileSaveClick;
        public event EventHandler ContentChanged;
        #endregion 
        
        private void BSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = "Text files|*.txt|All files|*.*"
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fldFilePath.Text = dlg.FileName;
                FileOpenClick?.Invoke(this, EventArgs.Empty);
            }
        }
        private void NumSizeFont_Click(object sender, EventArgs e)
        {
            fldContent.Font = new Font("Calibri", (float)numSizeFont.Value);
        }
    }
}
