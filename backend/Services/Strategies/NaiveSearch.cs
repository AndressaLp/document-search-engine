using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Services.Strategies
{
    public class NaiveSearch : ISearchStrategy
    {
        public string Name => "Naive";

        public SearchResult Search(string text, string pattern)
        {
            var stopwatch = Stopwatch.StartNew();
            var positions = new List<int>();

            int n = text.Length;
            int m = pattern.Length;

            if(m == 0 || n == 0 || m > n)
            {
                return new SearchResult
                {
                    Positions = positions,
                    ExecutionTimeMs = 0,
                    TextLength = n,
                    PatternLength = m
                };
            }

            for(int i = 0; i <= n - m; i++)
            {
                int j;
                for(j = 0; j < m; j++)
                {
                    if(text[i + j] != pattern[j]) break;
                }

                if(j == m) positions.Add(i);
            }

            stopwatch.Stop();

            return new SearchResult
            {
                Positions = positions,
                ExecutionTimeMs = stopwatch.ElapsedMilliseconds,
                TextLength = n,
                PatternLength = m
            };
        }
    }
}