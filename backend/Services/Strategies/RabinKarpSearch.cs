using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Services.Strategies
{
    public class RabinKarpSearch : ISearchStrategy
    {
        public string Name => "Rabin-Karp";

        private const int Prime = 101;

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
                    TextLength = n,
                    PatternLength = m
                };
            }

            long patternHash = 0;
            long windowHash = 0;
            long h = 1;

            for(int i = 0; i < m - 1; i++)
            {
                h = (h * 256) % Prime;
            }

            for(int i = 0; i < m; i++)
            {
                patternHash = (256 * patternHash + pattern[i]) % Prime;
                windowHash = (256 * windowHash + text[i]) % Prime;
            }

            for(int i = 0; i <= n - m; i++)
            {
                if(patternHash == windowHash)
                {
                    bool match = true;
                    for(int j = 0; j < m; j++)
                    {
                        if(text[i + j] != pattern[j])
                        {
                            match = false;
                            break;
                        }
                    }
                    if(match) positions.Add(i);
                }

                if(i < n - m)
                {
                    windowHash = (256 * (windowHash - text[i] * h) + text[i + m]) % Prime;
                    if(windowHash < 0) windowHash += Prime;
                }
            }

            stopwatch.Stop();

            return new SearchResult
            {
                Positions = positions,
                ExecutionTimeMs = stopwatch.Elapsed.TotalMilliseconds,
                TextLength = n,
                PatternLength = m
            };
        }
    }
}