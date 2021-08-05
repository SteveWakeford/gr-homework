using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gr
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var fileName = ParseFileName(args);
            
            var personSet = BuildPersonSet(fileName);

            personSet.OrderBy(p => p.FavoriteColor).ThenBy(p => p.LastName).ToList().ForEach(p => Console.WriteLine(p));
            personSet.OrderBy(p => p.DateOfBirth).ToList().ForEach(p => Console.WriteLine(p));
            personSet.OrderByDescending(p => p.LastName).ToList().ForEach(p => Console.WriteLine(p));
        }

        private static ISet<Person> BuildPersonSet(string fileName)
        {
            var set = new HashSet<Person>();

            using (var fileStream = File.OpenRead(fileName))
            using (var fileStreamReader = new StreamReader(fileStream))
            {
                while (fileStreamReader.Peek() >= 0)
                {
                    var line = fileStreamReader.ReadLine();

                    var person = BuildPerson(line);

                    set.Add(person);
                }
            }

            return set;
        }

        public static Person BuildPerson(string line)
        {
            return new Person();
        }

        public static string ParseFileName(string[] args)
        {
            if (args?.Length != 1) throw new ArgumentException("Must have one argument");

            return args[0];
        }
    }
}
