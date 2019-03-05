using System;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Hadoop.Net.Hbase.WebApp.Model
{
    public class UserHtmlColor
    {
        public string Key { get; private set; }
        
        public string ColorKey { get; private set; }
        public bool IsRed { get; private set; }
        public bool IsGreen { get; private set; }
        public bool IsBlue { get; private set; }

        public string RemoteIp { get; private set; }
        
        public string UserAgent { get; private set; }
        
        public UserHtmlColor(string key, bool isRed, bool isGreen, bool isBlue,string remoteIp , string userAgent)
        {
            Key = key;
            string[] split = key.Split('|');
            ColorKey = split[0];
            IsRed = isRed;
            IsGreen = isGreen;
            IsBlue = isBlue;
            RemoteIp = remoteIp;
            UserAgent = userAgent;
        }

        public static UserHtmlColor Create(string colorKey, bool isRed, bool isGreen, bool isBlue , string remoteIp , string userAgent)
        {
            return new UserHtmlColor($"{colorKey}|{Guid.NewGuid().ToString()}",isRed,isGreen,isBlue,remoteIp,userAgent);
        }
        
    }
}