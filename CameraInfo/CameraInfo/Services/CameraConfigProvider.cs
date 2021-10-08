using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CameraInfo.Models;
using Newtonsoft.Json.Linq;

namespace CameraInfo
{
    public class CameraConfigProvider
    {
        private HttpStringResponseProvider _stringResponseProvider;

        public CameraConfigProvider()
        {
            _stringResponseProvider = new HttpStringResponseProvider();
        }
        
        public async Task<IEnumerable<CameraConfig>> GetEnumerableAsync()
        {
            var result = await _stringResponseProvider.GetStringResponseAsync
                ("http://demo.macroscop.com/configex/?responsetype=json&login=root&password=");

            if (result == null)
                return null;
            
            var json = JObject.Parse(result);
            IList<JToken> results = json["Channels"].Children().ToList();
            return results.Select(res => res.ToObject<CameraConfig>()).ToList();
        }
    }
}