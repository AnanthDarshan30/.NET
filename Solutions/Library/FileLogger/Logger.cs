using System;
using System.IO;
using System.Configuration;

namespace FileLogger
{
    public static class Logger
    {
        private static string _filePath; // Default file path

        static Logger()
        {
            _filePath = ConfigurationManager.AppSettings["LogFilePath"];
            if (string.IsNullOrEmpty(_filePath))
            {
                _filePath = @"C:/Users/aadars/SampleFiles/log.txt";
            }
        }
        public static void Configure(string filePath)
        {
            _filePath = filePath;
        }

        public static void Debug(string message)
        {
            Log("DEBUG", message);
        }

        public static void Warning(string message)
        {
            Log("WARNING", message);
        }

        public static void Error(string message)
        {
            Log("ERROR", message);
        }

        private static void Log(string level, string message)
        {
            // Ensure the path is not null or empty
            if (string.IsNullOrWhiteSpace(_filePath))
            {
                throw new ArgumentException("File path cannot be null or empty.", nameof(_filePath));
            }

            var logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}";
            try
            {
                File.AppendAllText(_filePath, logMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to write log: {ex.Message}");
            }//invariant culture property, while converting string to date time.
            // string to object.
        }
    }
}
