using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetExamenam.Models
{
    public class UrlFindModel
    {
        public string Url { get; set; }

        public int UrlsLimit { get; set; }

        public int DepthLimit { get; set; }
    }
}
