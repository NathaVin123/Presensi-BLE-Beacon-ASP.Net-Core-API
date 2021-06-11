using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

using Presensi_BLE_Beacon_UAJY.API.Model;

namespace Presensi_BLE_Beacon_UAJY.API.DAO
{
    public class JadwalMhsDAO
    {
        public dynamic GetJadwalMhs(string npm, string semester)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.koneksi);

                string query = @"SELECT
		                                m.NPM,
		                                kls.KODE_MK,
		                                kls.NAMA_MK,
		                                kls.KELAS,
		                                kls.SKS,
		                                ds.NAMA_DOSEN_LENGKAP,
		                                hr.HARI,
		                                si.SESI,
		                                mk.SEMESTER,
		                                kls.RUANG1
                                FROM dbo.MST_MHS_AKTIF m
	                                JOIN dbo.tbl_krs krs ON m.NPM = krs.npm
	                                JOIN dbo.tbl_kelas kls ON krs.ID_KELAS = kls.ID_KELAS
	                                JOIN dbo.tbl_matakuliah mk ON kls.ID_MK = mk.ID_MK
	                                JOIN dbo.REF_HARI hr ON kls.ID_HARI1 = hr.ID_HARI
	                                JOIN dbo.REF_SESI si ON kls.ID_SESI_KULIAH1 = si.ID_SESI
	                                JOIN dbo.mst_dosen ds ON kls.NPP_DOSEN1 = ds.NPP
								WHERE (m.NPM = @npm) AND (mk.SEMESTER = @semester)
                                ORDER BY hr.hari DESC";

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