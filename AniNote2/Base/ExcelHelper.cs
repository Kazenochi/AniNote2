using AniNote2.MVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniNote2.Base
{
    public static class ExcelHelper
    {
        public static string SingleEntry(AnimeItem animeItem)
        {
            string singleLine = $"{animeItem.Title}\t{animeItem.Episodes}";
            return singleLine;
        }
    }
}
