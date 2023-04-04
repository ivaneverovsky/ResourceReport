using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceReport.Models
{
    internal class KoefBackup
    {
        public double BackupRDS { get; set; }
        public double BackupEML { get; set; }
        public double BackupEMLTape { get; set; }
        public KoefBackup(double backupRDS, double backupEML, double backupEMLTape)
        {
            BackupRDS = backupRDS;
            BackupEML = backupEML;
            BackupEMLTape = backupEMLTape;
        }
    }
}
