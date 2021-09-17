using Presensi_BLE_Beacon_UAJY.API.DAO;
using Presensi_BLE_Beacon_UAJY.API.Model;

namespace Presensi_BLE_Beacon_UAJY.API.BM
{
    public class PresensiBM
    {
        private PresensiDAO dao;
        private OutPutApi output;

        public PresensiBM()
        {
            dao = new PresensiDAO();
            output = new OutPutApi();
        }

        public OutPutApi ListKelasDsn(string npp, string semester)
        {
            var data = dao.GetListKelasDosen(npp, semester);

            output.data = data;

            return output;
        }
    }
}