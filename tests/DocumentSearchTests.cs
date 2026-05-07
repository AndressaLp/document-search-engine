using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Services.Strategies;

namespace tests
{
    public class DocumentSearchTests
    {
        private readonly string _documentsPath =
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
        "..", "..", "..", "..",
        "tests",
        "TestDocuments");

        [Theory]
        [InlineData("biblia.txt", "Deus")]
        [InlineData("os-lusiadas.txt", "Portugal")]
        [InlineData("a-catedral-e-o-bazar.txt", "software")]
        [InlineData("dom-casmurro.txt", "Capitu")]
        public void All_Algorithms_Should_Find_Text_In_Real_Documents(
            string fileName,
            string pattern)
        {
            string fullPath = Path.Combine(_documentsPath, fileName);

            string text = File.ReadAllText(fullPath, System.Text.Encoding.GetEncoding("iso-8859-1"));

            var algorithms = new List<ISearchStrategy>
            {
                new NaiveSearch(),
                new KmpSearch(),
                new RabinKarpSearch(),
                new BoyerMooreSearch()
            };

            foreach (var algorithm in algorithms)
            {
                var result = algorithm.Search(text, pattern);

                Assert.True(result.Found);
                Assert.True(result.Occurrences > 0);
                Assert.NotEmpty(result.Positions);
            }
        }
    }
}