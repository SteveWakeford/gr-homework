using System;
using System.IO;

namespace gr
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var fileName = ProgramArgs.ParseFileName(args);

            var personSet = SetFromLines.Build(File.OpenRead(fileName), Person.Parse);

            PersonDisplay.Output1(personSet, Console.Out);
            PersonDisplay.Output2(personSet, Console.Out);
            PersonDisplay.Output3(personSet, Console.Out);
        }
    }
}
