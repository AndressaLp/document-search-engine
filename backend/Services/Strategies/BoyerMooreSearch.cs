using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Services.Strategies
{
    public class BoyerMooreSearch : ISearchStrategy
    {
        public string Name => "Boyer-Moore";

        private const int AlphabetSize = 256;

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

            int[] badChar = BuildBadCharTable(pattern);

            int shift = 0;

            while(shift <= n - m)
            {
                int j = m - 1;

                while(j >= 0 && pattern[j] == text[shift + j]) j--;

                if(j < 0)
                {
                    positions.Add(shift);

                    shift += (shift + m < n) ? m - badChar[text[shift + m]] : 1;
                }
                else
                {
                    shift += Math.Max(1, j - badChar[text[shift + j]]);
                }
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

        private int[] BuildBadCharTable(string pattern)
        {
            int[] table = new int[AlphabetSize];

            for(int i = 0; i < AlphabetSize; i++) table[i] = -1;
            for(int i = 0; i < pattern.Length; i++) table[pattern[i]] = i;

            return table;
        }
    }
}