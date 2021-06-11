using Presensi_BLE_Beacon_UAJY.API.DAO;
using Presensi_BLE_Beacon_UAJY.API.Model;

namespace Presensi_BLE_Beacon_UAJY.API.BM
{
    public class RiwayatMhsBM
    {
        private RiwayatMhsDAO dao;
        private OutPutApi output;

        public RiwayatMhsBM()
        {
            dao = new RiwayatMhsDAO();
            output = new OutPutApi();
        }

        public OutPutApi RiwayatMhs(string npm, string semester)
        {
            var data = dao.GetRiwayatMhs(npm, semester);

            output.data = data;

            return output;
        }
    }
}