using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUsageExceptionHandling
{
    public class FileEmptyException : Exception
    {
        public FileEmptyException(string message) : base(message)
        {
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\aadars\sample.txt.txt";

            try
            {
                CreateAndWriteFile(filePath);
                string fileContent = ReadFile(filePath);
                fileContent = null;
                if (string.IsNullOrEmpty(fileContent))
                {
                    throw new FileEmptyException("The file is empty. Cannot proceed with reading.");
                }

                Console.WriteLine("File Content: ");
                Console.WriteLine(fileContent);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Error: File not found - " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                //Example File path - @"C:\Windows\win.ini"
                Console.WriteLine("Error: Unauthorized access - " + ex.Message);
            }
            catch (FileEmptyException ex)
            {
                Console.WriteLine("Custom Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Process completed.");
            }
            Console.ReadLine();
        }

        static void CreateAndWriteFile(string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("Hello, this is a sample text file.");
                    writer.WriteLine("You are learning file handling in C#!");
                }
                Console.WriteLine("File created and written successfully.");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Error: Unauthorized access to " + filePath + " - " + ex.Message);
            }
        }

        static string ReadFile(string filePath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Error: Unauthorized access to " + filePath + " - " + ex.Message);
                return null;
            }
        }
    }
}