using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tests.Unit
{
    public class AlgorithmsTests
    {
        private readonly string _text = "abcabcabc";
        private readonly string _pattern = "abc";

        [Fact]
        public void Naive_Should_Find_All_Positions()
        {
            var strategy = new NaiveSearch();

            var result = strategy.Search(_text, _pattern);

            Assert.Equal(new List<int> { 0, 3, 6 }, result.Positions);
        }

        [Fact]
        public void Kmp_Should_Find_All_Positions()
        {
            var strategy = new KmpSearch();

            var result = strategy.Search(_text, _pattern);

            Assert.Equal(new List<int> { 0, 3, 6 }, result.Positions);
        }

        [Fact]
        public void RabinKarp_Should_Find_All_Positions()
        {
            var strategy = new RabinKarpSearch();

            var result = strategy.Search(_text, _pattern);

            Assert.Equal(new List<int> { 0, 3, 6 }, result.Positions);
        }

        [Fact]
        public void BoyerMoore_Should_Find_All_Positions()
        {
            var strategy = new BoyerMooreSearch();

            var result = strategy.Search(_text, _pattern);

            Assert.Equal(new List<int> { 0, 3, 6 }, result.Positions);
        }
    }
}