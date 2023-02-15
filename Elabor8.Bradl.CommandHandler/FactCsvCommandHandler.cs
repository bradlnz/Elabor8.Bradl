using CsvHelper;
using CsvHelper.Configuration;
using Elabor8.Bradl.Command;
using Elabor8.Bradl.Repository;
using MediatR;
using System.Formats.Asn1;
using System.Globalization;

namespace Elabor8.Bradl.CommandHandler
{
    public class FactCsvCommandHandler : IRequestHandler<FactCsvCommand, byte[]>
    {
        public async Task<byte[]> Handle(FactCsvCommand request, CancellationToken cancellationToken)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                NewLine = Environment.NewLine,
            };
      
            var memoryStream = new MemoryStream();
            using (var writer = new StreamWriter(memoryStream))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                var records = request.Facts.Select(a => new
                {
                    User = $"{a.User?.FirstName} {a.User?.LastName}",
                    TotalVotes = a.Upvotes
                }).OrderByDescending(f => f.TotalVotes);

                await csv.WriteRecordsAsync(records, cancellationToken);

                await writer.FlushAsync();

                return memoryStream.ToArray();
            };
        }
    }
}