using System.Collections.Generic;
using System.IO;
using Hadoop.New.Library.WebHdfs.Client;

namespace Hadoop.Net.Hdfs.Cmd.Commands
{
    public class DownloadFile:ICommand
    {
        public string GetName()
        {
            return "DownloadFile";
        }

        public void DoCommand(WebHdfsClient client, List<string> parameters)
        {
            string localPath = parameters?[1];
            string remotePath = parameters?[0];
            
            using (var fileStream = new FileStream(localPath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                if (client.ReadStream(fileStream,remotePath).Result)
                    System.Console.WriteLine($"File {remotePath} is downloaded to {localPath}");
                else
                    System.Console.WriteLine($"File {remotePath} is not downloaded to {localPath}");
            }
        }

        public bool ValidateCommand(List<string> parameters)
        {
            return parameters?.Count == 2;
        }

        public void ShowHelp()
        {
            System.Console.WriteLine("{WEB_HDFS_URL} DownloadFile  {HDFS_PATH} {LOCAL_PATH}- download file from HDFS PATH to LOCAL PATH");
        }
    }
}