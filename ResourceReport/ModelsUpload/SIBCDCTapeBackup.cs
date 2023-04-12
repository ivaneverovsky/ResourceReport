namespace ResourceReport.ModelsUpload
{
    internal class SIBCDCTapeBackup
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Size { get; set; }
        public string Time { get; set; }
        public string Info { get; set; }
        public SIBCDCTapeBackup(string name, string fullName, string size, string time, string info)
        {
            Name = name;
            FullName = fullName;
            Size = size;
            Time = time;
            Info = info;
        }
    }
}
