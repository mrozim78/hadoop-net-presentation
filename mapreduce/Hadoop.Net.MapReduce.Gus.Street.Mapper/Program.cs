using System;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;


namespace Hadoop.Net.MapReduce.Gus.Street.Mapper
{
    public class Program
    {

        private readonly static int FEATURE = 6;
        private readonly static int STREET_FIRST = 7;
        private readonly static int STREET_LAST = 8;


        static void Main(string[] args)
        {
          
            string line = Console.ReadLine();
            Configuration configuration = new Configuration();
            configuration.Delimiter = ";";
            configuration.HasHeaderRecord = true;
            while (line != null)
            {
                using (var reader = new StringReader(line))
                using (var parser = new CsvParser(reader,configuration))
                {
                    string[] fields;
                    try {
                        fields = parser.Read();
                        Console.WriteLine($"{fields[FEATURE]} {fields[STREET_FIRST]} {fields[STREET_LAST]}\t1");
                    } catch(Exception ex){

                         Console.Error.WriteLine($"reporter:counter:Hadoop.Net.MapReduce.Gus.Street.Mapper,{ex.ToString()},1");
                    }
                }
                line = Console.ReadLine();
            }
        }
    }

}
