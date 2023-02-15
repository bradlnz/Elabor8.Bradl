using Elabor8.Bradl.Entities;
using Elabor8.Bradl.Query;
using Elabor8.Bradl.Repository;
using MediatR;

namespace Elabor8.Bradl.CommandHandler
{
    public class FactReadCommandHandler : IRequestHandler<FactReadQuery, Fact>
    {
        private readonly IFactRepository _factRepository;

        public FactReadCommandHandler(IFactRepository factRepository)
        {
            _factRepository = factRepository ?? throw new ArgumentNullException(nameof(factRepository));
        }

        public async Task<Fact> Handle(FactReadQuery request, CancellationToken cancellationToken)
        {
            return await _factRepository.ReadAsync(request);
        }
    }
}