namespace Elbor8.Bradl.CommandUtility
{
    public interface ICsvCommandHelper
    {
        Task<byte[]> GenerateCsvAsync<T>(IEnumerable<T> records, CancellationToken cancellationToken);
    }
}