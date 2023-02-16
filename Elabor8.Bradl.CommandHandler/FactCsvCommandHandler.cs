using CsvHelper;
using CsvHelper.Configuration;
using Eabor8.Bradl.Models;
using Elabor8.Bradl.Command;
using Elabor8.Bradl.Query;
using Elabor8.Bradl.Repository;
using Elbor8.Bradl.CommandUtility;
using MediatR;
using System.Formats.Asn1;
using System.Globalization;

namespace Elabor8.Bradl.CommandHandler
{
    public class FactCsvCommandHandler : IRequestHandler<FactCsvQuery, byte[]>
    {
        private readonly IFactRepository _factRepository;
        private readonly ICsvCommandHelper _csvCommandHelper;
        public FactCsvCommandHandler(IFactRepository factRepository, ICsvCommandHelper csvCommandHelper) 
        {
            _factRepository = factRepository ?? throw new ArgumentNullException(nameof(factRepository));
            _csvCommandHelper = csvCommandHelper ?? throw new ArgumentNullException(nameof(csvCommandHelper));
        }
        public async Task<byte[]> Handle(FactCsvQuery request, CancellationToken cancellationToken)
        {
            var facts = await _factRepository.ReadCsvDataAsync();
            var data = await _csvCommandHelper.GenerateCsvAsync(facts, cancellationToken);
            return data;
        }
    }
}