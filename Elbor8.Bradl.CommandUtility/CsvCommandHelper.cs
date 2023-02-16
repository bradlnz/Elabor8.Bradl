using CsvHelper;
using System.Globalization;

namespace Elbor8.Bradl.CommandUtility
{
    public class CsvCommandHelper: ICsvCommandHelper
    {
        public async Task<byte[]> GenerateCsvAsync<T>(IEnumerable<T> records, CancellationToken cancellationToken)
        {
            var memoryStream = new MemoryStream();
            using (var writer = new StreamWriter(memoryStream))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                await csv.WriteRecordsAsync(records, cancellationToken);
                await writer.FlushAsync();

                return memoryStream.ToArray();
            };
        }
    }
}