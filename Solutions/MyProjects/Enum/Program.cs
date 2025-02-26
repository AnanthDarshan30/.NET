using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileLogger;

namespace Enums
{
    public enum Gender
    {
        Male,
        Female,
        PreferNotToSay
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger.Debug($"Starting a enum project, members of the enum are described in the file.");
            List<Gender> count = new List<Gender>();
            count.Add(Gender.Male);
            count.Add(Gender.Female);
            count.Add(Gender.PreferNotToSay);
            Logger.Debug($"{count.Count.ToString()}"); 
            int val = (int)Gender.Male;
            foreach (Gender gender in count)
            {
                Logger.Warning("Values are of the type gender");
                Console.WriteLine(gender);
            }
            Console.WriteLine($"{Enum.GetValues(typeof(Gender))} whose value is {val}");
            
            Console.ReadLine();
        }
    }
}
