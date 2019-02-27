using System;
using System.Linq;
using System.Collections.Generic;
using Hadoop.Net.Hdfs.Cmd.Commands;
using Hadoop.New.Library.WebHdfs.Client;

namespace Hadoop.Net.Hdfs.Cmd
{
    class Program
    {
        public static IEnumerable<ICommand> Commands = new List<ICommand>(
            new ICommand[]
            {
                new ListCommand(),
                new StatusCommand(),
                new MakeDirectoryCommand(),
                new DeleteCommand(),
                new UploadFileCommand(),
                new DownloadFile()
            }
          );

        static void Main(string[] args)
        {

            string webHdfs = args?.Length >= 2 ? args[0] : string.Empty; 
            string commandName = args?.Length >= 2 ? args[1] : string.Empty;

            if (string.IsNullOrEmpty(webHdfs) || string.IsNullOrEmpty(commandName))
            {
                ShowHelps();
                return;
            }
            
                
                
            

            List<string> parameters = args?.Where((a, i) => i > 1).ToList();
                
            WebHdfsClient client = new WebHdfsClient(webHdfs, true);
            
            foreach (ICommand command in Commands)
            {
                if (command.GetName() == commandName && command.ValidateCommand(parameters))
                {
                    command.DoCommand(client,parameters);
                    return;
                }

            }
            ShowHelps();
        }

        private static void ShowHelps()
        {
            System.Console.WriteLine("List of commands:");
            Commands?.ToList().ForEach(command=>command.ShowHelp());
        }
        
        
        
    }
}
