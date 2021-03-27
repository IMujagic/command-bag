using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CommandBag.Core.Logging
{
    public static class CommandBagLog
    {
        private static ILogProvider _logProvider;

        public static void SetLogProvider(ILogProvider logProvider)
        {
            if (_logProvider != null)
                throw new Exception("Log provider already initialized!");

            _logProvider = logProvider;
        }

        public static void Info(string message)
        {
            _logProvider.Info(message);
        }

        public static void Error(string message)
        {
            _logProvider.Error(message);
        }
    }
}
