using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vanguard_AIO.Classes
{
    public class DeckInfo
    {
        public int id { get; set; }
        public string deck_id { get; set; }
        public string title { get; set; }
        public int game_title_id { get; set; }
        public int status { get; set; }
        public string deck_param1 { get; set; }
        public string deck_param2 { get; set; }
        public List<MainDeckCardInfo> list { get; set; }
        public List<GZoneCardInfo> sub_list { get; set; }
    }
}
