using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Services.Strategies
{
    public class KmpSearch : ISearchStrategy
    {
        public string Name => "KMP";

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

            int[] lps = BuildLps(pattern);

            int i = 0;
            int j = 0;

            while(i < n)
            {
                if(text[i] == pattern[j])
                {
                    i++;
                    j++;
                }

                if(j == m)
                {
                    positions.Add(i - j);
                    j = lps[j - 1];
                }
                else if(i < n && text[i] != pattern[j])
                {
                    if(j != 0) j = lps[j - 1];
                    else i++;
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

        private int[] BuildLps(string pattern)
        {
            int m = pattern.Length;
            int[] lps = new int[m];

            int len = 0;
            int i = 1;

            while(i < m)
            {
                if(pattern[i] == pattern[len])
                {
                    len++;
                    lps[i] = len;
                    i++;
                }
                else
                {
                    if(len != 0) len = lps[len - 1];
                    else
                    {
                        lps[i] = 0;
                        i++;
                    }
                }
            }
            return lps;
        }
    }
}