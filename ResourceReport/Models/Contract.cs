namespace ResourceReport.Models
{
    internal class Contract
    {
        public string ContractName { get; set; }
        public Contract(string contractName)
        {
            ContractName = contractName;
        }
    }
}
