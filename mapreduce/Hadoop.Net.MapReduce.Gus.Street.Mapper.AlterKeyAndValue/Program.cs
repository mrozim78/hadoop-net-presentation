using System;

namespace Hadoop.Net.MapReduce.Gus.Street.Mapper.AlterKeyAndValue
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine();

            while (line != null)
            {
                var parts = line.Split('\t');
                if (parts!=null && parts.Length==2)
                {
                    var value = parts[0];
                    var key = parts[1];
                    Console.WriteLine($"{key}\t{value}");
                } else
                {
                    Console.Error.WriteLine("reporter:counter:Hadoop.Net.MapReduce.Gus.Street.Mapper.AlterKeyAndValue,Bad input lines,1");
                }
                line = Console.ReadLine();
            }

        }
    }
}
