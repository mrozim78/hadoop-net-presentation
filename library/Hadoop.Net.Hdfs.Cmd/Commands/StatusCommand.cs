using System;
using System.Linq;
using System.Collections.Generic;
using Hadoop.New.Library.WebHdfs.Client;

namespace Hadoop.Net.Hdfs.Cmd.Commands
{
    public class StatusCommand : ICommand
    {
        public void DoCommand(WebHdfsClient client, List<string> parameters)
        {
            string path = parameters?[0];
            WebHdfsFileStatus status = client.GetFileStatus(path).Result;
            if (status != null)
            {
                System.Console.WriteLine($"Status {path}");
                System.Console.WriteLine(
                    $"{"Permission",-15}{"Length",-10}{"Owner",-20}{"Type",-10}");
                System.Console.WriteLine(
                    $"{status.permission,-15}{status.length,-10}{status.owner,-20}{status.type,-10}");
            }
        }

        public string GetName()
        {
            return "Status";
        }

        public bool ValidateCommand(List<string> parameters)
        {
            return parameters?.Count ==1;
        }

        public void ShowHelp()
        {
           System.Console.WriteLine("{WEB_HDFS_URL} Status {HDFS_PATH} - status object (FILE or DIRECTORY) in HDFS Path");
        }
    }

}