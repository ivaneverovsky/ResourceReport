namespace ResourceReport.ModelsUpload
{
    internal class Backup
    {
        public string Volume { get; set; }
        public string UsedCapacity { get; set; }
        public string AvailableCapacity { get; set; }
        public string TotalCapacity { get; set; }
        public string MountPath { get; set; }
        public Backup(string volume, string usedCapacity, string availableCapacity, string totalCapacity, string mountPath)
        {
            Volume = volume;
            UsedCapacity = usedCapacity;
            AvailableCapacity = availableCapacity;
            TotalCapacity = totalCapacity;
            MountPath = mountPath;
        }
    }
}
