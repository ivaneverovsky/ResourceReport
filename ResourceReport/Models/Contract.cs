using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
