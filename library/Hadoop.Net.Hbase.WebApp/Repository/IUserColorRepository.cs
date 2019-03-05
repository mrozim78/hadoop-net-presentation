using System.Threading.Tasks;
using Hadoop.Net.Hbase.WebApp.Model;

namespace Hadoop.Net.Hbase.WebApp.Repository
{
    public interface IUserColorRepository
    {
        Task AddUserColor(UserHtmlColor userColor);

    }
}