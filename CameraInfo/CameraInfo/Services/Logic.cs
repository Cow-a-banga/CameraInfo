using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CameraInfo.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CameraInfo
{

    



    class Logic
    {

        static async Task<List<CameraStreamsInfo>> Get()
        {
            var result = await GetResponseStringAsync
                ("http://demo.macroscop.com/command/?type=getchannelsstates&responsetype=json&login=root&password=/");
            var json = result.Substring(result.IndexOf("["));
            return JsonConvert.DeserializeObject<List<CameraStreamsInfo>>(json);
        }

        static async Task<List<CameraConfig>> GetConfigRequestAsync()
        {
            var result = await GetResponseStringAsync
                ("http://demo.macroscop.com/configex/?responsetype=json&login=root&password=/");

            var json = JObject.Parse(result);
            IList<JToken> results = json["Channels"]?.Children().ToList();
            return results.Select(res => res.ToObject<CameraConfig>()).ToList();
        }

        static async Task<string> GetResponseStringAsync(string url)
        {
            var client = new HttpClient();
            var result = await client.GetAsync(url);
            if (!result.IsSuccessStatusCode)
                return null;
            return await result.Content.ReadAsStringAsync();
            
        }
    }
}
