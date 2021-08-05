using System;
using System.Collections.Generic;
using System.IO;

namespace gr
{
    public static class SetFromLines
    {
        public static ISet<T> Build<T>(Stream stream, Func<string, T> buildItemFromLine)
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
    }
}
