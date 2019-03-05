using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Hadoop.Net.Hbase.WebApp.Model;
using Hadoop.Net.Library.HBase.Stargate.Client.Api;
using Hadoop.Net.Library.HBase.Stargate.Client.Models;

namespace Hadoop.Net.Hbase.WebApp.Repository
{
    public class ColorRepository:IColorRepository
    {
        private readonly IStargate _Stargate;
        public ColorRepository(IStargate Stargate)
        {
            _Stargate = Stargate;
        }
        
        public async Task AddColor(HtmlColor color)
        {
           CellSet cellSet =  HbaseRowFactory.CreateFactory("colors", color.Key)
                .AddColumnIntValue("definition", "red", color.R)
                .AddColumnIntValue("definition", "green", color.G)
                .AddColumnIntValue("definition", "blue", color.B)
                .AddColumnDecimalValue("definition", "alpha", color.Alpha).MakeCellSet();
            await _Stargate.WriteCellsAsync(cellSet);
        }

        public async Task<bool> IsColorExists(string colorKey)
        {
            CellSet cellSet = await _Stargate.FindCellsAsync("colors", colorKey, "definition");
            return cellSet != null && cellSet.Count > 0;
        }

        public async Task<HtmlColor> GetColor(string colorKey)
        {
            CellSet cellSet = await _Stargate.FindCellsAsync("colors", colorKey, "definition");
            return GetHtmColor(cellSet, colorKey);
        }
        

        public async Task<IEnumerable<HtmlColor>> GetList()
        {
            List<HtmlColor> colors = new List<HtmlColor>();
                
            ScannerOptions scannerOptions = new ScannerOptions();
            scannerOptions.TableName = "colors";
            using (IScanner scanner = await _Stargate.CreateScannerAsync(scannerOptions))
            {
                foreach (CellSet cellSet in scanner)
              
                    colors.AddRange(cellSet.GroupBy(a => a.Identifier.Row).Select(a => GetHtmColor(new CellSet(a), a.Key)));
               
            }

            return colors;
        }


        private HtmlColor GetHtmColor(CellSet cellSet , string Key)
        {
            HtmlColor htmlColor = new HtmlColor(
                Key: Key,
                R:cellSet.GetInt("definition","red"),
                G:cellSet.GetInt("definition","green"),
                B:cellSet.GetInt("definition","blue"),
                Alpha:cellSet.GetDecimal("definition","alpha")
            );
            return htmlColor;
        }
    }
}