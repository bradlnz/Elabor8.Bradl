using Elabor8.Bradl.Entities;
using Elabor8.Bradl.Command;
using Microsoft.EntityFrameworkCore;
using Elabor8.Bradl.Query;

namespace Elabor8.Bradl.Repository
{
    public class FactRepository : IFactRepository
    {
        private readonly DataContext _dataContext;

        public FactRepository()
        {
            _dataContext = new DataContext();
        }
        public async Task CreateAsync(FactCreateCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            await _dataContext.Facts.AddAsync(new Fact
            {
                Id = command.Id,
                Text = command.Text,
                Type = command.Type,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Deleted = false,
                Status = new Status
                {
                    SentCount = 0,
                    Verified = true
                }
            });
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Fact[]> ReadAllAsync(FactReadAllQuery query)
        {
            return await _dataContext.Facts.ToArrayAsync();
        }

        public async Task<Fact?> ReadAsync(FactReadQuery command)
        {
            return await _dataContext.Facts.FirstOrDefaultAsync(f => f.Id == command.Id);
        }
    }
}
