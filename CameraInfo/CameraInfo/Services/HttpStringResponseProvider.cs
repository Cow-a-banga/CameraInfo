using System.Net.Http;
using System.Threading.Tasks;

namespace CameraInfo
{
    public class HttpStringResponseProvider
    {
        public async Task<string> GetStringResponseAsync(string url)
        {
            var client = new HttpClient();
            var result = await client.GetAsync(url);
            
            if (!result.IsSuccessStatusCode)
                return null;
            
            return await result.Content.ReadAsStringAsync();
            
        }
    }
}