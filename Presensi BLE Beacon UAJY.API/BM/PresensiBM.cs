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

        public OutPutApi ListAllKelasDsn(string npp)
        {
            var data = dao.GetAllListKelasDosen(npp);

            output.data = data;

            return output;
        }

        public OutPutApi ListKelasMhs(string npm)
        {
            var data = dao.GetListKelasMahasiswa(npm);

            output.data = data;

            return output;
        }

        public OutPutApi ListAllKelasMhs(string npm)
        {
            var data = dao.GetAllListKelasMahasiswa(npm);

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

        public OutPutApi ListKehadiranPesertaKelasDsn(int idkelas, int pertemuan)
        {
            var data = dao.GetListKehadiranPesertaKelas(idkelas,pertemuan);

            output.data = data;

            return output;
        }

        public OutPutApi UpdateINPresensiDosen(int idkelas, int pertemuan)
        {
            var data = dao.UpdateINPresensiDosen(idkelas, pertemuan);

            output.data = data;

            return output;
        }

        public OutPutApi UpdateOUTPresensiDosen(string keterangan, string materi, int idkelas, int pertemuan)
        {
            var data = dao.UpdateOUTPresensiDosen(keterangan, materi, idkelas, pertemuan);

            output.data = data;

            return output;
        }

        public OutPutApi InsertPresensiINMhsToKSI(int idkelas, string npm, int pertemuan)
        {
            var data = dao.InsertPresensiINMahasiswaToKSI(idkelas, npm, pertemuan);

            output.data = data;

            return output;
        }

        public OutPutApi UpdatePresensiOUTMhsToKSI(int idkelas, string npm, int pertemuan, string status)
        {
            var data = dao.UpdatePresensiOUTMahasiswaToKSI(idkelas, npm, pertemuan, status);

            output.data = data;

            return output;
        }

        public OutPutApi InsertPresensiINMhsToFBE(int idkelas, string npm, int pertemuan)
        {
            var data = dao.InsertPresensiINMahasiswaToFBE(idkelas, npm, pertemuan);

            output.data = data;

            return output;
        }

        public OutPutApi UpdatePresensiOUTMhsToFBE(int idkelas, string npm, int pertemuan, string status)
        {
            var data = dao.UpdatePresensiOUTMahasiswaToFBE(idkelas, npm, pertemuan, status);

            output.data = data;

            return output;
        }

        public OutPutApi InsertPresensiINMhsToFH(int idkelas, string npm, int pertemuan)
        {
            var data = dao.InsertPresensiINMahasiswaToFH(idkelas, npm, pertemuan);

            output.data = data;

            return output;
        }

        public OutPutApi UpdatePresensiOUTMhsToFH(int idkelas, string npm, int pertemuan, string status)
        {
            var data = dao.UpdatePresensiOUTMahasiswaToFH(idkelas, npm, pertemuan, status);

            output.data = data;

            return output;
        }

        public OutPutApi InsertPresensiINMhsToFISIP(int idkelas, string npm, int pertemuan)
        {
            var data = dao.InsertPresensiINMahasiswaToFISIP(idkelas, npm, pertemuan);

            output.data = data;

            return output;
        }

        public OutPutApi UpdatePresensiOUTMhsToFISIP(int idkelas, string npm, int pertemuan, string status)
        {
            var data = dao.UpdatePresensiOUTMahasiswaToFISIP(idkelas, npm, pertemuan, status);

            output.data = data;

            return output;
        }

        public OutPutApi InsertPresensiINMhsToFT(int idkelas, string npm, int pertemuan)
        {
            var data = dao.InsertPresensiINMahasiswaToFT(idkelas, npm, pertemuan);

            output.data = data;

            return output;
        }

        public OutPutApi UpdatePresensiOUTMhsToFT(int idkelas, string npm, int pertemuan, string status)
        {
            var data = dao.UpdatePresensiOUTMahasiswaToFT(idkelas, npm, pertemuan, status);

            output.data = data;

            return output;
        }

        public OutPutApi InsertPresensiINMhsToFTB(int idkelas, string npm, int pertemuan)
        {
            var data = dao.InsertPresensiINMahasiswaToFTB(idkelas, npm, pertemuan);

            output.data = data;

            return output;
        }

        public OutPutApi UpdatePresensiOUTMhsToFTB(int idkelas, string npm, int pertemuan, string status)
        {
            var data = dao.UpdatePresensiOUTMahasiswaToFTB(idkelas, npm, pertemuan, status);

            output.data = data;

            return output;
        }

        public OutPutApi InsertPresensiINMhsToFTI(int idkelas, string npm, int pertemuan)
        {
            var data = dao.InsertPresensiINMahasiswaToFTI(idkelas, npm, pertemuan);

            output.data = data;

            return output;
        }

        public OutPutApi UpdatePresensiOUTMhsToFTI(int idkelas, string npm, int pertemuan, string status)
        {
            var data = dao.UpdatePresensiOUTMahasiswaToFTI(idkelas, npm, pertemuan, status);

            output.data = data;

            return output;
        }
    }
}