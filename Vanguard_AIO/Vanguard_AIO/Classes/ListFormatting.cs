using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Vanguard_AIO.Classes
{
    public class ListFormatting
    {
        public static List<string> massList = new();

        public static string[] raritiesToExclude;

        public static void CreateList(List<MainDeckCardInfo> mainDeck)
        {
            foreach (var card in mainDeck)
            {
                card.name = NameCheck(card.name, card.rare);
                var index = card.card_number.IndexOf("/");
                string series = card.card_number.Substring(0, index);
                massList.Add($"{card.num} {card.name} [{series}]");
            }
        }

        public static void CreateList(List<MainDeckCardInfo> mainDeck, List<GZoneCardInfo> gDeck)
        {
            foreach (var card in mainDeck)
            {
                card.name = NameCheck(card.name, card.rare);
                var index = card.card_number.IndexOf("/");
                
                string series = card.card_number.Substring(0, index);
                series = $"[{series}]";
                series = SeriesCheck(series);
                massList.Add($"{card.num} {card.name} {series}");
            }
            foreach (var card in gDeck)
            {
                card.name = NameCheck(card.name, card.rare);
                var index = card.card_number.IndexOf("/");
                string series = card.card_number.Substring(0, index);
                massList.Add($"{card.num} {card.name} [{series}]");
            }
        }

        public static string NameCheck(string name, string rarity)
        {
            name = RarityCHeck(name, rarity);
            if (name.Contains('Я'))
            {
                name = name.Replace("Я", "R");
            }
            if (name.Contains('"'))
            {
                name = name.Replace("\"", "\\\"");
            }
            
            return name;
        }

        public static string SeriesCheck(string series)
        {
            if (series.Contains("[V-PR]"))
            {
                series = series.Replace("[V-PR]", "[VPR]");
            }

            return series;
        }

        public static string RarityCHeck(string name, string rarity)
        {
            using (StreamReader r = new StreamReader("jsconfig.json"))
            {
                string json = r.ReadToEnd();
                var jobL = JsonConvert.DeserializeObject<ExludeList>(json);
                raritiesToExclude = jobL.exclude;
            }
            if(!raritiesToExclude.Contains(rarity.ToUpper()))
            {
                if (rarity.ToUpper() == "10THSP")
                {
                    name += $" (SP)";
                }
                else if (rarity.ToUpper() == "10THSEC")
                {
                    name += $" (10TH SEC)";
                }
                else if (rarity.ToUpper() == "H")
                {
                    name += $" (HOLO)";
                }
                else if (rarity.ToUpper() == "WSP")
                {
                    name += $" (WEDDING SP)";
                }
                else
                {
                    name += $" ({rarity.ToUpper()})";
                }
                
            }
            return name;
        }

        public class ExludeList
        {
            public string[] exclude { get; set; }
        }
    }
}
