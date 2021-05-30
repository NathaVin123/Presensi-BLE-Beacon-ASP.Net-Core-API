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
                string query = @"SELECT TOP (1)
                                    m.NPM,
                                    m.NAMA_MHS,
                                    m.PASSWORD,
                                    m.KD_STATUS_MHS
                                FROM MST_MHS_AKTIF m
                                WHERE m.NPM = @npm AND m.KD_STATUS_MHS ='A'";

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

        public dynamic GetProfileMhs(string npm)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.koneksi);

                string query = @"SELECT TOP (1)
	                                m.NPM,
	                                m.NAMA_MHS,
	                                m.PASSWORD,
	                                m.KD_STATUS_MHS,
	                                m.TMP_LAHIR,
	                                m.TGL_LAHIR,
	                                m.ALAMAT,
	                                f.FAKULTAS,
	                                p.PRODI,
	                                d.NAMA_DOSEN_LENGKAP AS 'DSN_PEMBIMBING_AKADEMIK'
                                FROM dbo.MST_MHS_AKTIF m
	                                JOIN dbo.REF_PRODI p ON m.ID_PRODI = p.ID_PRODI
	                                JOIN dbo.REF_FAKULTAS f ON p.ID_FAKULTAS = f.ID_FAKULTAS
	                                JOIN dbo.MST_DOSEN d ON m.NPP_PEMBIMBING_AKADEMIK = d.NPP
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

        public dynamic GetLoginDsn(string npp)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.koneksi);
                string query = @"SELECT TOP (1)
                                    d.NPP,
                                    d.NAMA_DOSEN_LENGKAP,
                                    k.PASSWORD,
                                    d.KD_STATUS_DOSEN
                                FROM dbo.MST_DOSEN d
                                    JOIN simka.MST_KARYAWAN k ON d.NPP = k.NPP
                                WHERE (d.NPP = @npp) AND d.KD_STATUS_DOSEN ='A'";

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

        public dynamic GetProfileDsn(string npp)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.koneksi);

                string query = @"SELECT TOP (1)
	                                d.NPP,
	                                d.NAMA_DOSEN_LENGKAP,
	                                d.TEMPAT_LAHIR,
	                                d.TGL_LAHIR,
	                                k.PASSWORD,
	                                d.KD_STATUS_DOSEN,
	                                p.PRODI,
	                                f.FAKULTAS
                                FROM dbo.MST_DOSEN d
	                                JOIN simka.MST_KARYAWAN k ON D.NPP = K.NPP
	                                JOIN dbo.REF_PRODI p ON d.ID_PRODI = p.ID_PRODI
	                                JOIN dbo.REF_FAKULTAS f ON p.ID_FAKULTAS = f.ID_FAKULTAS
                                WHERE (D.NPP = @npp)";

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