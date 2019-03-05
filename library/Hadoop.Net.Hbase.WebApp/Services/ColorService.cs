using System;
using System.Collections.Generic;
using System.Linq;
using Hadoop.Net.Hbase.WebApp.Model;
using Hadoop.Net.Hbase.WebApp.Repository;

namespace Hadoop.Net.Hbase.WebApp
{
    public class ColorService:IColorService
    {
        private IColorRepository _colorRepository;
        public ColorService(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        public void AddRandomColors(int numberOfColors)
        {
            List<HtmlColor> colors = new List<HtmlColor>();
            for (int i = 0; i < numberOfColors; i++)
            {
                HtmlColor color = null;


                while (color == null || _colorRepository.IsColorExists(color.Key).Result)
                    color = HtmlColor.GetRandomHtmlColor();

                colors.Add(color);
            }

            colors.ForEach(color => _colorRepository.AddColor(color));
        }

        public HtmlColor GetRandomColor()
        {
            Random random = new Random();
            List<HtmlColor> colors = _colorRepository.GetList().Result.ToList();
            if (colors.Count > 0)
                return colors[random.Next(0, colors.Count)];
            return null;
         }

        public bool IsColorExists(string color)
        {
            return _colorRepository.IsColorExists(color).Result;
        }



    }
}