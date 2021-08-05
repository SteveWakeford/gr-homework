using System.IO;

namespace gr
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var fileName = ProgramArgs.ParseFileName(args);

            var personSet = SetFromLines.Build(File.OpenRead(fileName), Person.FromLine);

            PersonDisplay.Output1(personSet);
            PersonDisplay.Output2(personSet);
            PersonDisplay.Output3(personSet);
        }
    }
}
