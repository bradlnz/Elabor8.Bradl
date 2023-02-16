using Elabor8.Bradl.Entities;
using Elabor8.Bradl.Command;
using Elabor8.Bradl.Query;
using Eabor8.Bradl.Models;

namespace Elabor8.Bradl.Repository
{
    public interface IFactRepository
    {
        Task<FactCsvField[]> ReadCsvDataAsync();
        Task<Fact[]> ReadAllAsync();
        Task<Fact?> ReadAsync(FactReadQuery query);
        Task CreateAsync(FactCreateCommand command);
    }
}
