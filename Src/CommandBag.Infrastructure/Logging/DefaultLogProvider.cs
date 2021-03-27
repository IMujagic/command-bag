using CommandBag.Core.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CommandBag.Infrastructure.Logging
{
    public class DefaultLogProvider : ILogProvider
    {
        public void Error(string errorMessage)
        {
            Debug.WriteLine($"[ERROR] {errorMessage}");
        }

        public void Exception(Exception ex)
        {
            Debug.WriteLine($"[EXCEPTION] {ex.Message}");
        }

        public void Info(string message)
        {
            Debug.WriteLine($"[INFO] {message}");
        }

        public void Warning(string warning)
        {
            Debug.WriteLine($"[WARNING] {warning}");
        }
    }
}
