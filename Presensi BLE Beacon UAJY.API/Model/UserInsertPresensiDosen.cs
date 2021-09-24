using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presensi_BLE_Beacon_UAJY.API.Model
{
    public class UserInsertPresensiDosen
    {
        public int ID_Kelas { get; set; }

        public string NPP { get; set; }

        public int SKS { get; set; }
        public string MATERI { get; set; }
    }
}