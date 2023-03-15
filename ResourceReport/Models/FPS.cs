namespace ResourceReport.Models
{
    internal class FPS
    {
        public string Volume { get; set; }
        public string VolumeCapacity { get; set; }
        public string FreeSpace { get; set; }
        public string Backup { get; set; }
        public string SharingFolder { get; set; }
        public FPS(string volume, string volumeCapacity, string freeSpace, string backup, string sharingFolder)
        {
            Volume = volume;
            VolumeCapacity = volumeCapacity;
            FreeSpace = freeSpace;
            Backup = backup;
            SharingFolder = sharingFolder;
        }
    }
}
