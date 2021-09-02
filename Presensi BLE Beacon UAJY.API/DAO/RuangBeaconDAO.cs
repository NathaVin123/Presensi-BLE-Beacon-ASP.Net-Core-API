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
                              FROM  TBL_KELAS kls
	                            JOIN MST_RUANG r ON kls.RUANG1 = r.RUANG
	                            JOIN REF_HARI h ON kls.ID_HARI1 = h.ID_HARI
	                            JOIN REF_SESI s ON kls.ID_SESI_KULIAH1 = s.ID_SESI
	                            JOIN MST_DOSEN d ON kls.NPP_DOSEN1 = d.NPP
	                            JOIN SIATMAX_121212.dbo.REF_BEACON b ON r.ID_BEACON = b.ID_BEACON
                              WHERE r.ID_BEACON IS NOT NULL";

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

        public dynamic TambahBeacon(string uuid, string nama_device, float jarak_min)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.koneksi);

                string query = @"INSERT INTO SIATMAX_121212.dbo.REF_BEACON 
                                    (PROXIMITY_UUID, NAMA_DEVICE, JARAK_MIN_DEC) 
                                    VALUES 
                                    (@uuid, @nama_device, @jarak_min)";

                var param = new { UUID = uuid,  NAMA_DEVICE = nama_device, JARAK_MIN = jarak_min};
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        public dynamic GetListBeacon()
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.koneksi);

                string query = @"SELECT PROXIMITY_UUID, NAMA_DEVICE, JARAK_MIN_DEC FROM SIATMAX_121212.dbo.REF_BEACON";

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

        public dynamic UpdateBeacon()
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.koneksi);

                string query = @"";

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

        public dynamic DeleteBcn(string uuid)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.koneksi);

                string query = @"DELETE FROM SIATMAX_121212.dbo.REF_BEACON WHERE PROXIMITY_UUID = @uuid";

                var param = new { UUID = uuid };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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