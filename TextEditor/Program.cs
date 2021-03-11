using System;
using TextEditor.BL;
using System.Windows.Forms;
using DfEditor;

namespace TextEditor
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm form = new MainForm();
            FileManager manager = new FileManager();
            MessageService service = new MessageService();

            MainPresenter presenter = new MainPresenter(form, manager, service);

            Application.Run(form);
        }
    }
}
