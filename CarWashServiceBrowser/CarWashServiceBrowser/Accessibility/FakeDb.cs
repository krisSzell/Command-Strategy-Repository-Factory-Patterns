using System.IO;

namespace CarWashServiceBrowser.Accessibility
{
    public class FakeDb
    {
        private readonly string _filePath = "services.json";

        public string Read()
        {
            return File.ReadAllText(_filePath);
        }

        public void Write(string text)
        {
            File.WriteAllText(_filePath, text);
        }

        public void Append(string text)
        {
            File.AppendAllText(_filePath, text);
        }
    }
}
