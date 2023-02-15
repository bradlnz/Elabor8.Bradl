using Elabor8.Bradl.Entities;
using MediatR;

namespace Elabor8.Bradl.Command
{
    public class FactCsvCommand : IRequest<byte[]>
    {
        private readonly Fact[] _facts;

        public FactCsvCommand(Fact[] facts)
        {
            _facts = facts ?? throw new ArgumentNullException(nameof(facts));
        }
        public Fact[] Facts => _facts;
    }
}