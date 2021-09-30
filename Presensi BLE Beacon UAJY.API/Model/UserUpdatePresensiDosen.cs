using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presensi_BLE_Beacon_UAJY.API.Model
{
    public class UserUpdatePresensiDosen
    {
        public string JAM_MASUK {get; set;}
        public string JAM_KELUAR {get; set;}
        public string KETERANGAN {get; set;}
        public string MATERI {get; set;}
        public int ID_Kelas {get; set;}
        public int PERTEMUAN_KE {get; set;}
    }
}