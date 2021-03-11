using System;
using DfEditor;
using TextEditor.BL;

namespace TextEditor
{
    public class MainPresenter
    {
        private readonly IMainForm _view;
        private readonly IFileManager _manager;
        private readonly IMessageService _messageService;

        string _currentPathFile;

        public MainPresenter(IMainForm view, IFileManager fileManager, IMessageService messageService)
        {
            _view = view;
            _manager = fileManager;
            _messageService = messageService;

            _view.SetSymbolCount(0);
            _view.ContentChanged += _view_ContentChanged;
            _view.FileOpenClick += _view_FileOpenClick;
            _view.FileSaveClick += _view_FileSaveClick;
        }

        private void _view_FileSaveClick(object sender, EventArgs e)
        {
            try
            {
                string context = _view.Content;
                _manager.SaveContent(context, _currentPathFile);
                _messageService.ShowMessage("File saved successfully");
            }
            catch (Exception ex)
            {
                _messageService.ShowError(ex.Message);
            }
        }

        private void _view_FileOpenClick(object sender, System.EventArgs e)
        {
            try
            {
                string filePath = _view.FilePath;
                bool IsExists = _manager.IsExists(filePath);
                if (!IsExists)
                {
                    _messageService.ShowError("The selected file does not exist");
                    return;
                }

                _currentPathFile = filePath;

                string content = _manager.GetContent(filePath);
                _view.Content = content;
                int count = _manager.GetSymbolCount(content);
                _view.SetSymbolCount(count);

            }
            catch (Exception ex)
            {
                _messageService.ShowError(ex.Message);
            }
        }
        private void _view_ContentChanged(object sender, System.EventArgs e)
        {
            string content = _view.Content;
            int count = _manager.GetSymbolCount(content);
            _view.SetSymbolCount(count);
        }
    }
}
