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

        public OutPutApi TambahBeacon(string uuid, string nama_device, float jarak_min)
        {
            var data = dao.TambahBeacon(uuid, nama_device, jarak_min);

            output.data = data;

            return output;
        }

        public OutPutApi ListBeacon()
        {
            var data = dao.GetListBeacon();

            output.data = data;

            return output;
        }

        public OutPutApi DeleteBeacon(string uuid)
        {
            var data = dao.DeleteBcn(uuid);

            output.data = data;

            return output;
        }
    }
}