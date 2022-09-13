using Serilog;
using Serilog.Core;
using Serilog.Templates;
using SerilogExpressionsTestCore;
namespace SerilogExpressionTest
{
    class Program
    {

        private static Logger? Logger;

        static void Main(string[] args)
        {
            Logger = GetLogger();
            Logger.Error("Test");
            Console.ReadKey();
        }

        /// <summary>
        /// Initialize the Logger with a new Logger configuration
        /// </summary>
        private static Logger GetLogger()
        {
            LoggerConfiguration config = new LoggerConfiguration()
            .Enrich.With(new Enricher())
            .WriteTo.Console(new ExpressionTemplate("QueryString[?] like '%DROP%' ci: {#if QueryString[?] like '%DROP%' ci}True{#else}False{#end}\n\n"), restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Verbose, levelSwitch: null)
            .WriteTo.Console(new ExpressionTemplate("QueryString['y'] like '%DROP%' ci: {#if QueryString['y'] like '%DROP%' ci}True{#else}False{#end}\n\n"), restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Verbose, levelSwitch: null)
            .WriteTo.Console(new ExpressionTemplate("{@p}\n\n"), restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Verbose, levelSwitch: null);
            return config.CreateLogger();
        }

    }

}
