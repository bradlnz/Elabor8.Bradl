using Elabor8.Bradl.Entities;
using Elabor8.Bradl.Query;
using Elabor8.Bradl.Repository;
using MediatR;

namespace Elabor8.Bradl.CommandHandler
{
    public class FactReadAllCommandHandler : IRequestHandler<FactReadAllQuery, Fact[]>
    {
        private readonly IFactRepository _factRepository;

        public FactReadAllCommandHandler(IFactRepository factRepository)
        {
            _factRepository = factRepository ?? throw new ArgumentNullException(nameof(factRepository));
        }

        public Task<Fact[]> Handle(FactReadAllQuery request, CancellationToken cancellationToken)
        {
            return _factRepository.ReadAllAsync(request);
        }
    }
}