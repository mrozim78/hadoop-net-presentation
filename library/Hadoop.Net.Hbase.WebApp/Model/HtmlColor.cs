using System;
using Microsoft.AspNetCore.Razor.Language;

namespace Hadoop.Net.Hbase.WebApp.Model
{
    public class HtmlColor
    {
        
        public String Key {get; private set; }
        
        public int R { get; private set;}
        public int G { get; private set; }
        public int B { get; private set;}
        public decimal Alpha { get; private set; }


        private HtmlColor()
        {
            
        }
        public HtmlColor(string Key, int R, int G, int B, decimal Alpha)
        {
            this.Key = Key;
            this.R = R;
            this.G = G;
            this.B = B;
            this.Alpha = Alpha;
        }
        

        public static HtmlColor GetRandomHtmlColor()
        {
            Random random = new Random();
            HtmlColor color = new HtmlColor(); 
                
            
            
            color.R = random.Next(0, 255);
            color.G = random.Next(0, 255);
            color.B = random.Next(0, 255);
            color.Alpha = (decimal) (random.Next(0, 101)) / 100;

            color.Key = $"{color.R,0:D3}_{color.G,0:D3}_{color.B,0:D3}_{(int) (color.Alpha * 100),0:D3}";
            
            return color;
        }
        
    }
}