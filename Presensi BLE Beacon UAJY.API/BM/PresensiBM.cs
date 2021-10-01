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

        public OutPutApi ListKelasDsn(string npp)
        {
            var data = dao.GetListKelasDosen(npp);

            output.data = data;

            return output;
        }

        public OutPutApi ListKelasMhs(string npm)
        {
            var data = dao.GetListKelasMahasiswa(npm);

            output.data = data;

            return output;
        }

        public OutPutApi DosenBukaPresensi(int idkelas, int bukapresensi, int pertemuan)
        {
            var data = dao.DosenBukaPresensi(idkelas, bukapresensi, pertemuan);

            output.data = data;

            return output;
        }

        public OutPutApi ListPesertaKelasDsn(int idkelas)
        {
            var data = dao.GetListPesertaKelas(idkelas);

            output.data = data;

            return output;
        }

        public OutPutApi UpdateINPresensiDosen(string jammasuk, int idkelas, int pertemuan)
        {
            var data = dao.UpdateINPresensiDosen(jammasuk, idkelas, pertemuan);

            output.data = data;

            return output;
        }

        public OutPutApi UpdateOUTPresensiDosen( string jamkeluar, string keterangan, string materi, int idkelas, int pertemuan)
        {
            var data = dao.UpdateOUTPresensiDosen(jamkeluar, keterangan, materi, idkelas, pertemuan);

            output.data = data;

            return output;
        }

        public OutPutApi InsertPresensiINMhsToKSI(int idkelas, string npm ,int pertemuan, string tglin)
        {
            var data = dao.InsertPresensiINMahasiswaToKSI(idkelas, npm, pertemuan, tglin);

            output.data = data;

            return output;
        }

        public OutPutApi UpdatePresensiOUTMhsToKSI(int idkelas, string npm ,int pertemuan, string tglout, string status, string materi)
        {
            var data = dao.UpdatePresensiOUTMahasiswaToKSI(idkelas, npm, pertemuan, tglout, status, materi);

            output.data = data;

            return output;
        }
    }
}