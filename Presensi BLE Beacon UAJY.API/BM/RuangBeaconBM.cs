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

            var data = dao.GetBeacon();
            if (data != null)
            {
                output.data = data;
            }
            else
            {
                output.error = "Data Beacon Gagal Ditampilkan";
                output.data = new { };
            }
                

            return output;
        }

        public OutPutApi TambahBeacon(string uuid, string nama_device, float jarak_min, int major, int minor)
        {
            var data = dao.TambahBeacon(uuid, nama_device, jarak_min, major, minor);
            
            output.data = data;
           
            return output;
        }

        public OutPutApi ListBeacon()
        {
            var data = dao.GetListBeacon();
            if (data != null)
            {
                output.data = data;
            }
            else
            {
                output.error = "Data Beacon Gagal Ditampilkan";
                output.data = new { };
            }

            return output;
        }

        public OutPutApi UpdateBeacon(string uuid, string nama_device, float jarak_min, int major, int minor)
        {
            var data = dao.UpdateBeacon(uuid, nama_device, jarak_min, major, minor);
            
            output.data = data; 
            
            return output;
        }

        public OutPutApi DeleteBeacon(string uuid, int status)
        {
            var data = dao.DeleteBeacon(uuid, status);
           
            output.data = data;
           
            return output;
        }

        public OutPutApi ListRuanganNamaDevice(string ruang)
        {
            var data = dao.PostListRuanganNamaDevice(ruang);
            if (data != null)
            {
                output.data = data;
            }
            else
            {
                output.error = "Data Ruangan Gagal Ditampilkan";
                output.data = new { };
            }

            return output;
        }

        public OutPutApi ListRuangan()
        {
            var data = dao.GetListRuangan();

            if (data != null)
            {
                output.data = data;
            }
            else
            {
                output.error = "Data Ruangan Gagal Ditampilkan";
                output.data = new { };
            }

            return output;
        }

        public OutPutApi ListDetailRuangan()
        {
            var data = dao.GetListDetailRuangan();

            if (data != null)
            {
                output.data = data;
            }
            else
            {
                output.error = "Data Detail Ruangan Gagal Ditampilkan";
                output.data = new { };
            }

            return output;
        }

        public OutPutApi UpdateRuangBeacon(string ruang, string nama_device)
        {
            var data = dao.UpdateRuangBeacon(ruang, nama_device);

            output.data = data;
           
            return output;
        }
    }
}