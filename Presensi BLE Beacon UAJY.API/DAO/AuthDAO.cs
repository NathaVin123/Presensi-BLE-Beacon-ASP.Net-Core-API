using Dapper;
using System;

using System.Data.SqlClient;

namespace Presensi_BLE_Beacon_UAJY.API.DAO
{
    public class AuthDAO
    {
        public dynamic GetLoginMhs(string npm)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.koneksi);
                string query = @"SELECT m.NPM, m.NAMA_MHS, m.PASSWORD, m.KD_STATUS_MHS
                                FROM MST_MHS_AKTIF m
                                WHERE m.NPM = @npm";

                var param = new { npm = npm };
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

        public dynamic GetLoginDsn(string npp)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.koneksi);
                string query = @"SELECT D.NPP, D.NAMA_DOSEN_LENGKAP, K.PASSWORD, D.KD_STATUS_DOSEN
                                    FROM dbo.mst_dosen D JOIN simka.MST_KARYAWAN K ON D.NPP = K.NPP
                                WHERE (D.NPP = @npp) AND KD_STATUS_DOSEN ='A'";

                var param = new { npp = npp };
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

        public dynamic GetProfileMhs(string npm)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.koneksi);

                string query = @"SELECT m.NPM, m.NAMA_MHS, m.PASSWORD, m.KD_STATUS_MHS
                                FROM MST_MHS_AKTIF m
                                WHERE m.NPM = @npm";

                var param = new { NPM = npm };
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

        public dynamic GetProfileDsn(string npp)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.koneksi);

                string query = @"SELECT D.NPP, D.NAMA_DOSEN_LENGKAP, K.PASSWORD, D.KD_STATUS_DOSEN
                                    FROM dbo.mst_dosen D JOIN simka.MST_KARYAWAN K ON D.NPP = K.NPP
                                WHERE (D.NPP = @npp) AND KD_STATUS_DOSEN ='A'";

                var param = new { NPP = npp };
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