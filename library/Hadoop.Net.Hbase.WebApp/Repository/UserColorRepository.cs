using System;
using System.Threading.Tasks;
using Hadoop.Net.Hbase.WebApp.Model;
using Hadoop.Net.Library.HBase.Stargate.Client.Api;
using Hadoop.Net.Library.HBase.Stargate.Client.Models;

namespace Hadoop.Net.Hbase.WebApp.Repository
{
    public class UserColorRepository:IUserColorRepository
    {
        
        private readonly IStargate _Stargate;
        public UserColorRepository(IStargate Stargate)
        {
            _Stargate = Stargate;
        }
        public async Task AddUserColor(UserHtmlColor userColor)
        {
           
           
                CellSet cellSet = HbaseRowFactory.CreateFactory("user_color", userColor.Key)
                    .AddColumnBooleanValue("answer", "is_red", userColor.IsRed)
                    .AddColumnBooleanValue("answer", "is_green", userColor.IsGreen)
                    .AddColumnBooleanValue("answer", "is_blue", userColor.IsBlue)
                    .AddColumnStringValue("header", "user_agent", userColor.UserAgent)
                    .AddColumnStringValue("header", "remote_ip", userColor.RemoteIp)
                    .MakeCellSet();
                    await _Stargate.WriteCellsAsync(cellSet);
               
        }
       
        
        
    }
}