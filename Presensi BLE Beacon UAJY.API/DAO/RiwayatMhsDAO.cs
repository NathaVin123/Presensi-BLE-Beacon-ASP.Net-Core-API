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
        public dynamic GetRiwayatMhs(string npm)
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
	                                sia.TGL_VERIFIKASI
                                FROM SIATMAX_121212.dbo.tbl_kelas kls
	                                JOIN SIATMA_UAJY.dbo.TBL_PRESENSI_MHS sia ON kls.ID_KELAS = sia.ID_Kelas
                                WHERE sia.NPM = @npm
                                ORDER BY TGL_IN ASC";

                var param = new { NPM = npm };
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