namespace CameraInfo.Models
{
    public class CameraStreamsInfo
    {
        public string Id { get; set; }
        public bool IsRecordingOn { get; set; }
        public StreamState[] StreamsStates { get; set; }
    }
}