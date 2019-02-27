using System.Collections.Generic;
using System.Linq;
using Hadoop.New.Library.WebHdfs.Client;

namespace Hadoop.Net.Hdfs.Cmd.Commands
{
    public class MakeDirectoryCommand:ICommand
    {
        public string GetName()
        {
            return "MakeDirectory";
        }

        public void DoCommand(WebHdfsClient client, List<string> parameters)
        {
            string path = parameters?[0];
            if (client.MakeDirectory(path).Result)
                System.Console.WriteLine($"Directory {path} is created");
            else
                System.Console.WriteLine($"Directory {path} is not created");
        }

        public bool ValidateCommand(List<string> parameters)
        {
            return parameters?.Count() == 1;
        }

        public void ShowHelp()
        {
            System.Console.WriteLine("{WEB_HDFS_URL} MakeDirectory {HDFS_PATH} - make directory in HDFS PATH");
        }
    }
}