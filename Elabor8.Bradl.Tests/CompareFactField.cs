using Eabor8.Bradl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elabor8.Bradl.Tests
{
    public class CompareFactField : IEqualityComparer<FactCsvField>
    {
        public bool Equals(FactCsvField compare1, FactCsvField compare2)
        {
            return compare1.FullName == compare2.FullName
                && compare1.UpvoteCount == compare2.UpvoteCount;
        }

        public int GetHashCode(FactCsvField obj)
        {
            throw new NotImplementedException();
        }
    }
}
