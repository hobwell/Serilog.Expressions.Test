using Serilog.Core;
using Serilog.Events;

namespace SerilogExpressionsTestCore
{
    /// <summary>
    /// Basic enricher, not desctucturing when adding a property
    /// </summary>
    internal class Enricher : ILogEventEnricher
    {

        private static Dictionary<string, string> QueryString
        {
            get
            {
                return new Dictionary<string, string>() {
                    { "x", "NULL" },
                    { "y", "DROP" }
                };
            }
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("QueryString", QueryString));
        }
    }
}
