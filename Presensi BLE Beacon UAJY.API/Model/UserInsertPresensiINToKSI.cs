using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presensi_BLE_Beacon_UAJY.API.Model
{
    public class UserInsertPresensiINToKSI
    {
        public int ID_KELAS {get; set;}

        public string NPM {get; set;}

        public int PERTEMUAN {get; set;}

        public string TGLIN {get; set;}  
    }
}