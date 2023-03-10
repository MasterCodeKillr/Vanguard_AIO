using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Vanguard_AIO.Classes
{
    public class ApiRequest
    {
        public static async Task request(string code)
        {
            var options = new RestClientOptions($"https://decklog-en.bushiroad.com/view/{code}")
            {
                MaxTimeout = -1,
                UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.0.0 Safari/537.36"
            };
            var client = new RestClient(options);
            var request = new RestRequest($"https://decklog-en.bushiroad.com/system/app/api/view/{code}", Method.Post);
            request.AddHeader("authority", " decklog-en.bushiroad.com");
            request.AddHeader("method", " POST");
            request.AddHeader("path", $" /system/app/api/view/{code}");
            request.AddHeader("scheme", " https");
            request.AddHeader("accept", " application/json, text/plain, */*");
            request.AddHeader("accept-encoding", " gzip, deflate, br");
            request.AddHeader("accept-language", " en-US,en;q=0.9");
            request.AddHeader("content-length", " 0");
            request.AddHeader("cookie", " CAKEPHP=f5oe52k58k1gnj0kh9nne8ako4");
            request.AddHeader("origin", " https://decklog-en.bushiroad.com");
            request.AddHeader("referer", $" https://decklog-en.bushiroad.com/view/{code}");
            request.AddHeader("sec-ch-ua", " \"Chromium\";v=\"110\", \"Not A(Brand\";v=\"24\", \"Google Chrome\";v=\"110\"");
            request.AddHeader("sec-ch-ua-mobile", " ?0");
            request.AddHeader("sec-ch-ua-platform", " \"Windows\"");
            request.AddHeader("sec-fetch-dest", " empty");
            request.AddHeader("sec-fetch-mode", " cors");
            request.AddHeader("sec-fetch-site", " same-origin");
            request.AlwaysMultipartFormData = true;
            request.AddParameter("authority", " decklog-en.bushiroad.com");
            request.AddParameter("method", " POST");
            request.AddParameter("path", $" /system/app/api/view/{code}");
            request.AddParameter("scheme", " https");
            request.AddParameter("accept", " application/json, text/plain, */*");
            request.AddParameter("accept-encoding", " gzip, deflate, br");
            request.AddParameter("accept-language", " en-US,en;q=0.9");
            request.AddParameter("content-length", " 0");
            request.AddParameter("cookie", " CAKEPHP=ksi9auq1j12vvm0v4ltfa9u1le");
            request.AddParameter("origin", " https://decklog-en.bushiroad.com");
            request.AddParameter("referer", $" https://decklog-en.bushiroad.com/view/{code}");
            request.AddParameter("sec-ch-ua", " \"Chromium\";v=\"110\", \"Not A(Brand\";v=\"24\", \"Google Chrome\";v=\"110\"");
            request.AddParameter("sec-ch-ua-mobile", " ?0");
            request.AddParameter("sec-ch-ua-platform", " \"Windows\"");
            request.AddParameter("sec-fetch-dest", " empty");
            request.AddParameter("sec-fetch-mode", " cors");
            request.AddParameter("sec-fetch-site", " same-origin");
            request.AddParameter("user-agent", " Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.0.0 Safari/537.36");
            RestResponse response = await client.ExecuteAsync(request);
            if (response.Content == "[]" || response.Content.Length < 3)
            {
                throw new ArgumentException("DeckLog Response was empty. Please verify deck code is correct.");
            }
            await ExtractInfo(response.Content);
        }

        public static async Task ExtractInfo(string response)
        {
            JObject deckJson = JObject.Parse(response);
            var extractedInfo = JsonConvert.DeserializeObject<DeckInfo>(deckJson.ToString());
            var list = JsonConvert.SerializeObject(extractedInfo.list);
            JArray listArray = JArray.Parse(list);
            var main = JsonConvert.DeserializeObject<JArray>(listArray.ToString()).ToObject<List<MainDeckCardInfo>>();
            if (extractedInfo.sub_list.Count > 0)
            {
                var subList = JsonConvert.SerializeObject(extractedInfo.sub_list);
                JArray subListArray = JArray.Parse(subList);
                var subs = JsonConvert.DeserializeObject<JArray>(subListArray.ToString()).ToObject<List<GZoneCardInfo>>();

                ListFormatting.CreateList(main, subs);
            }
            else
            {
                ListFormatting.CreateList(main);
            }
        }
    }
}
