using System.IO;
using System.Text;

namespace TextEditor.BL
{
    public class FileManager:IFileManager
    {
        private readonly Encoding _defaultEncoding = Encoding.GetEncoding(1251);

        public bool IsExists(string filePath)
        {
            bool isExists = File.Exists(filePath);
            return isExists;
        }
        public string GetContent(string filePath)
        {
            return GetContent(filePath, _defaultEncoding);
        }
        public string GetContent(string filePath, Encoding encoding)
        {
            string content = File.ReadAllText(filePath, encoding);
            return content;
        }
    
        public void SaveContent(string content, string filePath)
        {
            SaveContent(content, filePath, _defaultEncoding);
        }
        public void SaveContent(string content, string filePath, Encoding encoding)
        {
            File.WriteAllText(filePath, content, encoding);
        }
   
        public int GetSymbolCount(string content)
        {
            int count = content.Length;
            return count;
        }
    }
}
