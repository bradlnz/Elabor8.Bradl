using Elabor8.Bradl.Entities;
using Elabor8.Bradl.Command;
using Microsoft.EntityFrameworkCore;
using Elabor8.Bradl.Query;
using Eabor8.Bradl.Models;

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
                Deleted = false
            });
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Fact[]> ReadAllAsync()
        {
            return await _dataContext.Facts.ToArrayAsync();
        }

        public async Task<Fact?> ReadAsync(FactReadQuery command)
        {
            return await _dataContext.Facts.FirstOrDefaultAsync(f => f.Id == command.Id);
        }

        public async Task<FactCsvField[]> ReadCsvDataAsync()
        {
            var facts = await _dataContext.Facts.ToArrayAsync();

            return facts
                .Select(f => new FactCsvField($"{f.User.FirstName} {f.User.LastName}", f.Upvotes))
                .OrderByDescending(f => f.UpvoteCount)
                .ToArray();
        }
    }
}
