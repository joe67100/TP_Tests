using System.Text;

namespace CreditApp
{
    public static class CsvCreator
    {
        public static void CreateCsvFile(string fileName, Action<StreamWriter>writeAction)
        {
            using StreamWriter writer = new(fileName, false, new UTF8Encoding(true));
            writeAction(writer);
        }
    }
}
