using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace gr
{
    public static class PersonDisplay
    {
        public static void Output1(ISet<Person> personSet, TextWriter textWriter)
        {
            personSet.OrderBy(p => p.FavoriteColor).ThenBy(p => p.LastName).ToList().ForEach(p => textWriter.WriteLine(p));
        }

        public static void Output2(ISet<Person> personSet, TextWriter textWriter)
        {
            personSet.OrderBy(p => p.DateOfBirth).ToList().ForEach(p => textWriter.WriteLine(p));
        }

        public static void Output3(ISet<Person> personSet, TextWriter textWriter)
        {
            personSet.OrderByDescending(p => p.LastName).ToList().ForEach(p => textWriter.WriteLine(p));
        }
    }
}
