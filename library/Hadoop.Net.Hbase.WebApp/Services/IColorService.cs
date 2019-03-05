using Hadoop.Net.Hbase.WebApp.Model;

namespace Hadoop.Net.Hbase.WebApp
{
    public interface IColorService
    {
        void AddRandomColors(int numberOfColors);
        HtmlColor GetRandomColor();
        bool IsColorExists(string color);
    }
}