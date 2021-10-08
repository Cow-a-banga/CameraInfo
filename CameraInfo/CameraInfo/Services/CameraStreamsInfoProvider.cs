using System.Collections.Generic;
using System.Threading.Tasks;
using CameraInfo.Models;
using Newtonsoft.Json;

namespace CameraInfo
{
    public class CameraStreamsInfoProvider
    {
        
        private HttpStringResponseProvider _stringResponseProvider;

        public CameraStreamsInfoProvider()
        {
            _stringResponseProvider = new HttpStringResponseProvider();
        }
        
        public async Task<IEnumerable<CameraStreamsInfo>> GetEnumerableAsync()
        {
            var result = await _stringResponseProvider.GetStringResponseAsync
                ("http://demo.macroscop.com/command/?type=getchannelsstates&responsetype=json&login=root&password=");

            if (result == null)
                return null;
            
            var json = result.Substring(result.IndexOf("["));
            return JsonConvert.DeserializeObject<List<CameraStreamsInfo>>(json);
        }
    }
}