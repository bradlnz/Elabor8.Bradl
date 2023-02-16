namespace Eabor8.Bradl.Models
{
    public class FactCsvField
    {
        private readonly string _fullName;
        private readonly int _upvoteCount;
        public FactCsvField(string fullName, int upvoteCount) 
        {
            _fullName = fullName;
            _upvoteCount = upvoteCount;
        }

        public string FullName => _fullName;
        public int UpvoteCount => _upvoteCount;
    }
}