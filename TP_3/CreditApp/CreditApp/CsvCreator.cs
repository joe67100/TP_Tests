using System.Text;

namespace CreditApp
{
    public static class CsvCreator
    {
        public static void CreateCsvFile(string fileName, Action<StreamWriter>writeAction)
        {
            using var writer = new StreamWriter(fileName, false, new UTF8Encoding(true));
            writeAction(writer);
        }
    }
}
