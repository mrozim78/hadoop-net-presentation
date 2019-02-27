using System.Collections.Generic;
using System.Linq;
using Hadoop.New.Library.WebHdfs.Client;

namespace Hadoop.Net.Hdfs.Cmd.Commands
{
    public class DeleteCommand:ICommand
    {
        public string GetName()
        {
            return "Delete";
        }

        public void DoCommand(WebHdfsClient client, List<string> parameters)
        {
            string path = parameters?[0];
            bool? recursive = null;
            if (parameters?.Count() == 2 && parameters[1] == "Recursive")
                recursive = true;
            if (parameters?.Count() == 2 && parameters[1] == "NoRecursive")
                recursive = false;
            
            if (client.Delete(path, recursive).Result)
                System.Console.WriteLine($"Object {path} is deleted");
            else
                System.Console.WriteLine($"Object {path} is not deleted");
                
            
        }

        public bool ValidateCommand(List<string> parameters)
        {
            return parameters?.Count() == 1 ||
                   parameters?.Count() == 2 &&
                   (parameters.ToList()[1] == "Recursive" || parameters.ToList()[1] == "NoRecursive");
        }
    

        public void ShowHelp()
        {
            System.Console.WriteLine("{WEB_HDFS_URL} Delete {HDFS_PATH} - delete object (FILE OR DIRECTORY) in HDFS PATH ");
            System.Console.WriteLine("{WEB_HDFS_URL} Delete {HDFS_PATH} Recursive - delete object (FILE OR DIRECTORY) in HDFS PATH recursive");
            System.Console.WriteLine("{WEB_HDFS_URL} Delete {HDFS_PATH} NoRecursive - delete object (FILE OR DIRECTORY) in HDFS PATH no recursive");
            
        }
    }
}