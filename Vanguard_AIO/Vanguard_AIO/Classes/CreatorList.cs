using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Vanguard_AIO.Classes
{
    public class CreatorList
    {
        public static List<SubArray> CurrentList { get; set; }
        public static List<SubArray> UpdatedList { get; set; }
        public static string filename = "creatorlist.json";
        public static List<SubArray> GetCreators()
        {
            
            string json = File.ReadAllText(filename);
            var job = JsonConvert.DeserializeObject<List<SubArray>>(json);
            return job;
        }

        public static void UpdateList(List<SubArray> list)
        {
            var finish = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(filename, finish);
        }

    }
}
