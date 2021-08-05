using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace gr
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var fileName = ParseFileName(args);

            var personSet = BuildSetFromLines(File.OpenRead(fileName), BuildPerson);

            personSet.OrderBy(p => p.FavoriteColor).ThenBy(p => p.LastName).ToList().ForEach(p => Console.WriteLine(p));
            personSet.OrderBy(p => p.DateOfBirth).ToList().ForEach(p => Console.WriteLine(p));
            personSet.OrderByDescending(p => p.LastName).ToList().ForEach(p => Console.WriteLine(p));
        }

        private static ISet<T> BuildSetFromLines<T>(Stream stream, Func<string, T> buildItemFromLine)
        {
            var set = new HashSet<T>();

            using (var streamReader = new StreamReader(stream))
            {
                while (streamReader.Peek() >= 0)
                {
                    var line = streamReader.ReadLine();

                    var item = buildItemFromLine(line);

                    set.Add(item);
                }
            }

            return set;
        }

        public static Person BuildPerson(string line)
        {
            return null;
        }

        public static string ParseFileName(string[] args)
        {
            if (args?.Length != 1) throw new ArgumentException("Must have one argument");

            return args[0];
        }
    }
}
