using Elabor8.Bradl.Entities;
using Elabor8.Bradl.Command;
using Elabor8.Bradl.Query;

namespace Elabor8.Bradl.Repository
{
    public interface IFactRepository
    {
        Task<Fact[]> ReadAllAsync(FactReadAllQuery query);
        Task<Fact?> ReadAsync(FactReadQuery query);
        Task CreateAsync(FactCreateCommand command);
    }
}
