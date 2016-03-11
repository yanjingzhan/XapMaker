using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneDirect3DXamlAppInterop.Entity
{
    public class AppRecommandEntity
    {
        public int SortIndex { get; set; }
        public string ProductID { get; set; }
        public string AppTitle { get; set; }
        public string AppImageUrl { get; set; }
        public string AppDescription { get; set; }
        public string DownloadCount { get; set; }
    }

    public class AppRecommandList
    {
        public List<AppRecommandEntity> AppRecommandEntity { get; set; }
    }
}
