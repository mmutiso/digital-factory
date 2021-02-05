using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameOfThrones.Models
{
    public class NavigationControls
    {
        public NavigationControls(List<LinkMeta> metas)
        {
            LinkMetas = metas;
        }
        public List<LinkMeta> LinkMetas { get; set; }

        public bool HasNext => LinkMetas.Any(x => x.Type == LinkMetaType.Next);
        public bool HasPrevious => LinkMetas.Any(x => x.Type == LinkMetaType.Previous);
        public bool HasFirst => LinkMetas.Any(x => x.Type == LinkMetaType.First);
        public bool HasLast => LinkMetas.Any(x => x.Type == LinkMetaType.Last);

        public int Next => LinkMetas.Where(x => x.Type == LinkMetaType.Next).Select(x => x.Page).FirstOrDefault();
        public int Previous => LinkMetas.Where(x => x.Type == LinkMetaType.Previous).Select(x => x.Page).FirstOrDefault();
        public int First => LinkMetas.Where(x => x.Type == LinkMetaType.First).Select(x => x.Page).FirstOrDefault();
        public int Last => LinkMetas.Where(x => x.Type == LinkMetaType.Last).Select(x => x.Page).FirstOrDefault();
    }
}
