using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class SearchResult
    {
        public List<int> Positions { get; set; } = new();
        public int Occurrences => Positions.Count;
        public bool Found => Positions.Count > 0;
        public long ExecutionTimeMs { get; set; }
        public int TextLength { get; set; }
        public int PatternLength { get; set; }
    }
}