using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Telemetry
{
    public static class SearchMetrics
    {
        private static readonly Meter Meter = new("DocumentSearchMetrics");

        public static readonly Counter<int> SearchRequests = Meter.CreateCounter<int>("search_requests_total");

        public static readonly Histogram<double> SearchDuration = Meter.CreateHistogram<double>("search_duration_ms");

        public static readonly Histogram<int> DocumentSize = Meter.CreateHistogram<int>("document_size_chars");
    }
}