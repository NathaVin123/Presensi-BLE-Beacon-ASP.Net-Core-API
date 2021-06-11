using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

using Presensi_BLE_Beacon_UAJY.API.Model;

namespace Presensi_BLE_Beacon_UAJY.API.DAO
{
    public class RiwayatMhsDAO
    {
        public dynamic GetRiwayatMhs(string npm, string semester)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.koneksi);

                string query = @"SELECT
	                                sia.ID_Kelas,
	                                kls.NAMA_MK,
	                                sia.PERTEMUAN_KE,
	                                sia.STATUS,
	                                sia.TGL_IN,
	                                sia.TGL_OUT,
	                                sia.TGL_VERIFIKASI,
									mk.SEMESTER
                                FROM SIATMAX_121212.dbo.tbl_kelas kls
	                                JOIN SIATMA_UAJY.dbo.TBL_PRESENSI_MHS sia ON kls.ID_KELAS = sia.ID_Kelas
									JOIN dbo.tbl_matakuliah mk ON kls.ID_MK = mk.ID_MK
	                                JOIN dbo.REF_HARI hr ON kls.ID_HARI1 = hr.ID_HARI
	                                JOIN dbo.REF_SESI si ON kls.ID_SESI_KULIAH1 = si.ID_SESI
	                                JOIN dbo.mst_dosen ds ON kls.NPP_DOSEN1 = ds.NPP
                                WHERE (sia.NPM = @npm) AND (mk.SEMESTER = @semester) AND TGL_IN IS NOT NULL
                                ORDER BY TGL_IN ASC";

                var param = new { NPM = npm, SEMESTER = semester };
                var data = conn.Query<dynamic>(query, param).ToList();

                return data;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                conn.Dispose();
            }
        }
    }
}