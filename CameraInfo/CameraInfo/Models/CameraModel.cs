using System.Linq;

namespace CameraInfo.Models
{
    public class CameraModel
    {
        public string Name { get; set; }
        public bool IsSoundOn { get; set; }
        public bool IsRecordingOn { get; set; }
        public StreamState[] StreamsStates { get; set; }

        public string Streams => string.Join("\n", StreamsStates.Select(c=>c.Type));
    }
}