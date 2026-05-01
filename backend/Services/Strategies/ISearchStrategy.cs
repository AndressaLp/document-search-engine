using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Services.Strategies
{
    public interface ISearchStrategy
    {
        string Name { get; }
        SearchResult Search(string text, string pattern);
    }
}