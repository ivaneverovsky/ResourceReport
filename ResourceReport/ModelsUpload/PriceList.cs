namespace ResourceReport.ModelsUpload
{
    internal class PriceList
    {
        public string Item { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public PriceList(string item, double price, string description)
        {
            Item = item;
            Price = price;
            Description = description;
        }
    }
}
