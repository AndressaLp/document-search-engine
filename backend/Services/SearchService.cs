using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using backend.Services.Strategies;
using backend.Telemetry;

namespace backend.Services
{
    public class SearchService
    {
        private readonly ILogger<SearchService> _logger;

        public SearchService(ILogger<SearchService> logger)
        {
            _logger = logger;
        }

        public SearchResult ExecuteSearch(string text, string pattern, string algorithm)
        {
            if(string.IsNullOrWhiteSpace(text)) throw new ArgumentException("Texto vazio");

            if(string.IsNullOrWhiteSpace(pattern)) throw new ArgumentException("Padrão vazio");

            var strategy = StrategyFactory.Create(algorithm);

            int n = text.Length;
            int m = pattern.Length;

            _logger.LogInformation("Iniciando busca. Algoritmo: {Algorithm}, N: {Textsize}, M: {PatternSize}", strategy.Name, n, m);

            SearchMetrics.DocumentSize.Record(n);

            var result = strategy.Search(text, pattern);

            SearchMetrics.SearchRequests.Add(1,
                new KeyValuePair<string, object?>("algorithm", strategy.Name),
                new KeyValuePair<string, object?>("found", result.Found));

            SearchMetrics.SearchDuration.Record(result.ExecutionTimeMs,
                new KeyValuePair<string, object?>("algorithm", strategy.Name),
                new KeyValuePair<string, object?>("found", result.Found));
            
            _logger.LogInformation("Busca finalizada. Tempo: {Time}ms, Ocorrencias: {Occurrences}", result.ExecutionTimeMs, result.Occurrences);

            return result;
        }

        public List<string> GetAlgorithms()
        {
            return StrategyFactory.GetAvailableAlgorithms();
        }
    }
}