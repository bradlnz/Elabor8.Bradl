using Elabor8.Bradl.Entities;
using MediatR;

namespace Elabor8.Bradl.Query
{
    public class FactReadQuery : IRequest<Fact>
    {
        private readonly Guid _id;

        public FactReadQuery(Guid id)
        {
            _id = id;
        }
        public Guid Id => _id;
    }
}