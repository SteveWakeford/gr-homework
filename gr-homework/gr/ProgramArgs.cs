using System;

namespace gr
{
    public static class ProgramArgs
    {
        public static string ParseFileName(string[] args)
        {
            if (args?.Length != 1) throw new ArgumentException("Must have one argument");

            return args[0];
        }
    }
}
