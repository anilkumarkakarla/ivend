namespace CXS.Core.Common.Logging
{
    public static class LoggerFactory
    {
        //public static ILogAgent LoggerInstance()
        //{
        //    return new NLogAgent();
        //}

        //public static ILogAgent LoggerInstance(string loggerName)
        //{
        //    return new NLogAgent(loggerName);
        //}

        public static ILogAgent LoggerInstance(LoggerContext loggerContext)
        {
            return new NLogAgent(loggerContext);
        }
    }
}