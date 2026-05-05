using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using backend.Services.Strategies;

namespace backend.Services
{
    public class SearchService
    {
        public SearchResult ExecuteSearch(string text, string pattern, string algorithm)
        {
            if(string.IsNullOrWhiteSpace(text)) throw new ArgumentException("Texto vazio");

            if(string.IsNullOrWhiteSpace(pattern)) throw new ArgumentException("Padrão vazio");

            var strategy = StrategyFactory.Create(algorithm);

            return strategy.Search(text, pattern);
        }

        public List<string> GetAlgorithms()
        {
            return StrategyFactory.GetAvailableAlgorithms();
        }
    }
}