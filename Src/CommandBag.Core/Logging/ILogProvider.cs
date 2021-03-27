using System;
using System.Collections.Generic;
using System.Text;

namespace CommandBag.Core.Logging
{
    public interface ILogProvider
    {
        void Info(string message);
        void Error(string errorMessage);
        void Warning(string warning);
        void Exception(Exception ex);
    }
}
