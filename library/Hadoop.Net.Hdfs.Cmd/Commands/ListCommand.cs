using System;
using System.Linq;
using System.Collections.Generic;
using Hadoop.New.Library.WebHdfs.Client;

namespace Hadoop.Net.Hdfs.Cmd.Commands
{
    public class ListCommand : ICommand
    {
        public ListCommand()
        {
        }

        public void DoCommand(WebHdfsClient client,List<string> parameters)
        {
            string path = parameters?[0];
            IEnumerable<WebHdfsFileStatus> list = client.ListStatus(path).Result;
            if (list != null)
            {
                System.Console.WriteLine($"List {path}");
                System.Console.WriteLine(
                    $"{"Permission",-15}{"Name",-50}{"Length",-10}{"Owner",-20}{"Type",-10}");
                
                foreach (WebHdfsFileStatus status in list)
                {
                    System.Console.WriteLine(
                        $"{status.permission,-15}{status.pathSuffix,-50}{status.length,-10}{status.owner,-20}{status.type,-10}");
                }
            }
        }

        public string GetName()
        {
            return "List";
        }

        public void ShowHelp()
        {
             System.Console.WriteLine("{WEB_HDFS_URL} List {HDFS_PATH} - list directory in HDFS Path");
        }

        public bool ValidateCommand(List<string> parameters)
        {
            return parameters?.Count() == 1;
        }
    }

}