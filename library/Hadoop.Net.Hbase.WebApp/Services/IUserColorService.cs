using System.Threading.Tasks;
using Hadoop.Net.Hbase.WebApp.Model;

namespace Hadoop.Net.Hbase.WebApp
{
    public interface IUserColorService
    {
        void AddUserColor(UserHtmlColor userHtmlColor);
    }
}