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

        public OutPutApi JadwalMhs(string npm, string semester)
        {
            var data = dao.GetJadwalMhs(npm, semester);

            output.data = data;

            return output;
        }
    }
}