using Presensi_BLE_Beacon_UAJY.API.DAO;
using Presensi_BLE_Beacon_UAJY.API.Model;

namespace Presensi_BLE_Beacon_UAJY.API.BM
{
    public class JadwalMhsBM
    {
        private JadwalMhsDAO dao;
        private OutPutApi output;

        public JadwalMhsBM()
        {
            dao = new JadwalMhsDAO();
            output = new OutPutApi();
        }

        public OutPutApi JadwalMhs(string npm)
        {
            var data = dao.GetJadwalMhs(npm);

            output.data = data;

            return output;
        }
    }
}