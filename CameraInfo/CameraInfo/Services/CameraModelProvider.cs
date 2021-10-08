using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CameraInfo.Models;

namespace CameraInfo
{
    public class CameraModelProvider
    {

        private CameraConfigProvider _configProvider;
        private CameraStreamsInfoProvider _streamsInfoProvider;

        public CameraModelProvider()
        {
            _configProvider = new CameraConfigProvider();
            _streamsInfoProvider = new CameraStreamsInfoProvider();
        }
        
        public async Task<IEnumerable<CameraModel>> GetEnumerableAsync()
        {
            var streamInfos = await _streamsInfoProvider.GetEnumerableAsync();

            var cameraConfigs = await _configProvider.GetEnumerableAsync();

            if (streamInfos == null || cameraConfigs == null)
                return null;
            
            return streamInfos
                .Join(cameraConfigs, camera => camera.Id, config => config.Id, (camera, config) => new CameraModel
                {
                    Name = config.Name,
                    IsRecordingOn = camera.IsRecordingOn,
                    IsSoundOn = config.IsSoundOn,
                    StreamsStates = camera.StreamsStates.Where(state => state.State == "Active").ToArray()
                });
        }
    }
}