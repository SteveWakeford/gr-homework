using System;
using System.Collections.Generic;
using System.Linq;

namespace gr
{
    public static class PersonDisplay
    {
        public static void Output1(ISet<Person> personSet)
        {
            personSet.OrderBy(p => p.FavoriteColor).ThenBy(p => p.LastName).ToList().ForEach(p => Console.WriteLine(p));
        }

        public static void Output2(ISet<Person> personSet)
        {
            personSet.OrderBy(p => p.DateOfBirth).ToList().ForEach(p => Console.WriteLine(p));
        }

        public static void Output3(ISet<Person> personSet)
        {
            personSet.OrderByDescending(p => p.LastName).ToList().ForEach(p => Console.WriteLine(p));
        }
    }
}
