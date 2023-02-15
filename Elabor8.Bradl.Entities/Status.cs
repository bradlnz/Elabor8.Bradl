using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elabor8.Bradl.Entities
{
    public class Status
    {
        public int Id { get; set; }
        public bool Verified { get; set; }
        public int SentCount { get; set; } = new Random().Next(0, 10);
    }
}
