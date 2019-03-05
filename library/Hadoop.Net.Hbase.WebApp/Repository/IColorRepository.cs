using System.Collections.Generic;
using System.Threading.Tasks;
using Hadoop.Net.Hbase.WebApp.Model;

namespace Hadoop.Net.Hbase.WebApp.Repository
{
    public interface IColorRepository
    {
        Task  AddColor(HtmlColor color);

        Task<bool> IsColorExists(string colorKey);

        Task<HtmlColor> GetColor(string colorKey);

        Task<IEnumerable<HtmlColor>> GetList();

    }
}