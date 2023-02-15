using Elabor8.Bradl.Command;
using Elabor8.Bradl.Repository;
using MediatR;

namespace Elabor8.Bradl.CommandHandler
{
    public class FactCreateCommandHandler : IRequestHandler<FactCreateCommand>
    {
        private readonly IFactRepository _factRepository;

        public FactCreateCommandHandler(IFactRepository factRepository)
        {
            _factRepository = factRepository ?? throw new ArgumentNullException(nameof(factRepository));
        }
        
        public async Task Handle(FactCreateCommand request, CancellationToken cancellationToken)
        {
            await _factRepository.CreateAsync(request);
        }
    }
}