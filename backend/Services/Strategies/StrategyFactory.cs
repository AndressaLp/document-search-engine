using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services.Strategies
{
    public static class StrategyFactory
    {
        public static ISearchStrategy Create(string algorithm)
        {
            return algorithm.ToLower() switch
            {
                "naive" => new NaiveSearch(),
                "kmp" => new KmpSearch(),
                "rabin-karp" => new RabinKarpSearch(),
                "boyer-moore" => new BoyerMooreSearch(),
                _ => throw new ArgumentException("Algoritmo inválido")
            };
        }

        public static List<string> GetAvailableAlgorithms()
        {
            return new List<string>
            {
                "naive",
                "kmp",
                "rabin-karp",
                "boyer-moore"
            };
        }
    }
}