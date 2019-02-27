using System;
using System.Collections.Generic;
using Hadoop.New.Library.WebHdfs.Client;

namespace Hadoop.Net.Hdfs.Cmd.Commands
{
    public interface ICommand 
    {
        string GetName();
        void DoCommand(WebHdfsClient client, List<string> parameters);
        bool ValidateCommand(List<string> parameters);

        void ShowHelp();

    }
}