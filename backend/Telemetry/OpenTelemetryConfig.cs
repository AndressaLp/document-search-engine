using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace backend.Telemetry
{
    public static class OpenTelemetryConfig
    {
        public static IServiceCollection AddOpenTelemetryConfig(this IServiceCollection services)
        {
            var resource = ResourceBuilder.CreateDefault().AddService("backend");

            services.AddOpenTelemetry().WithTracing(tracing =>
            {
                tracing
                    .SetResourceBuilder(resource)
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()
                    .AddOtlpExporter();
            })
            .WithMetrics(metrics =>
            {
                metrics
                    .SetResourceBuilder(resource)
                    .AddAspNetCoreInstrumentation()
                    .AddRuntimeInstrumentation()
                    .AddPrometheusExporter();
            });
            return services;
        }
    }
}