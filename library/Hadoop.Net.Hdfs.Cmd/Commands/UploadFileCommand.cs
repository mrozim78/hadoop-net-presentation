using System.Collections.Generic;
using System.IO;
using Hadoop.New.Library.WebHdfs.Client;

namespace Hadoop.Net.Hdfs.Cmd.Commands
{
    public class UploadFileCommand:ICommand
    {
        public string GetName()
        {
            return "UploadFile";
        }

        public void DoCommand(WebHdfsClient client, List<string> parameters)
        {
            string localPath = parameters?[0];
            string remotePath = parameters?[1];

            using (FileStream fileStream = new FileStream(localPath, FileMode.Open))
            {
                if (client.WriteStream(fileStream, remotePath).Result)
                    System.Console.WriteLine($"File {remotePath} is uploaded from {localPath}");
                else
                    System.Console.WriteLine($"File {remotePath} is not uploaded from {localPath}");

            }
        }

        public bool ValidateCommand(List<string> parameters)
        {
            return parameters?.Count == 2;
        }

        public void ShowHelp()
        {
            System.Console.WriteLine("{WEB_HDFS_URL} UploadFile {LOCAL_PATH} {HDFS_PATH} - upload file from LOCAL PATH to HDFS PATH ");

        }
    }
}