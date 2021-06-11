using Presensi_BLE_Beacon_UAJY.API.DAO;
using Presensi_BLE_Beacon_UAJY.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presensi_BLE_Beacon_UAJY.API.BM
{
    public class RuangBeaconBM
    {
        private RuangBeaconDAO dao;
        private OutPutApi output;

        public RuangBeaconBM()
        {
            dao = new RuangBeaconDAO();
            output = new OutPutApi();
        }

        public OutPutApi RuangBeacon()
        {
            var data = dao.GetScanningKelasBeacon();

            output.data = data;

            return output;
        }
    }
}