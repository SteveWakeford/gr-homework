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

            Console.WriteLine("Output 1:");
            PersonDisplay.Output1(personSet, Console.Out);

            Console.WriteLine("Output 2:");
            PersonDisplay.Output2(personSet, Console.Out);

            Console.WriteLine("Output 3:");
            PersonDisplay.Output3(personSet, Console.Out);
        }
    }
}
