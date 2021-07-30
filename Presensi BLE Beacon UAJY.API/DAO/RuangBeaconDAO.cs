using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Presensi_BLE_Beacon_UAJY.API.DAO
{
    public class RuangBeaconDAO
    {
        public dynamic GetScanningKelasBeacon()
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.koneksi);

                string query = @"SELECT
		                            kls.NAMA_MK,
		                            d.NAMA_DOSEN_LENGKAP,
		                            h.HARI,
		                            s.SESI,
		                            r.RUANG,
		                            b.PROXIMITY_UUID,
		                            b.NAMA_DEVICE
                              FROM [SIATMAX_121212].[dbo].[tbl_kelas] kls
	                            JOIN mst_ruang_2 r ON kls.RUANG1 = r.RUANG
	                            JOIN REF_HARI h ON kls.ID_HARI1 = h.ID_HARI
	                            JOIN REF_SESI s ON kls.ID_SESI_KULIAH1 = s.ID_SESI
	                            JOIN mst_dosen d ON kls.NPP_DOSEN1 = d.NPP
	                            JOIN REF_BEACON b ON r.ID_BEACON = b.ID_BEACON
                              WHERE r.ID_BEACON IS NOT NULL";

                //var param = new { NPM = npm };
                var data = conn.Query<dynamic>(query).ToList();

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