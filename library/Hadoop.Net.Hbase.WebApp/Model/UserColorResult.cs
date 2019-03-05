using System.Drawing;

namespace Hadoop.Net.Hbase.WebApp.Model
{
    public class UserColorResult
    {
        public HtmlColor Color { get; private set; }
        public int RedNumber { get; private set; }
        public int GreenNumber { get; private set; }
        public int BlueNumber { get; private set; }

        public UserColorResult(HtmlColor color, int redNumber, int greenNumber, int blueNumber)
        {
            this.Color = color;
            this.RedNumber = redNumber;
            this.GreenNumber = greenNumber;
            this.BlueNumber = blueNumber;
        }
        
    }
}