using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Presensi_BLE_Beacon_UAJY.API.DAO
{
    public class PresensiDAO
    {
        public dynamic GetListKelasDosen(string npp, string semester)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.koneksi);

                string query = @"SELECT
									kls.ID_KELAS,
		                            kls.NAMA_MK,
									kls.KELAS,
									d1.NPP AS NPP_DOSEN1,
									d1.NAMA_DOSEN_LENGKAP AS NAMA_DOSEN1,
									d2.NPP AS NPP_DOSEN2,
									d2.NAMA_DOSEN_LENGKAP AS NAMA_DOSEN2,
									d3.NPP AS NPP_DOSEN3,
									d3.NAMA_DOSEN_LENGKAP AS NAMA_DOSEN3,
									d4.NPP AS NPP_DOSEN4,
									d4.NAMA_DOSEN_LENGKAP AS NAMA_DOSEN4,
		                            h1.HARI AS HARI1,
									h2.HARI AS HARI2,
									h3.HARI AS HARI3,
									h4.HARI AS HARI4,
		                            s1.SESI AS SESI1,
									s2.SESI AS SESI2,
									s3.SESI AS SESI3,
									s4.SESI AS SESI4,
									kls.SKS,
									r.RUANG,
		                            b.PROXIMITY_UUID,
		                            b.NAMA_DEVICE,
                                    b.JARAK_MIN_DEC,
									kls.KAPASITAS_KELAS,
                                    kls.IS_BUKA_PRESENSI
                              FROM  TBL_KELAS kls
	                            JOIN MST_RUANG r ON kls.RUANG1 = r.RUANG
	                            FULL OUTER JOIN REF_HARI h1 ON kls.ID_HARI1 = h1.ID_HARI
								FULL OUTER JOIN REF_HARI h2 ON kls.ID_HARI2 = h2.ID_HARI
								FULL OUTER JOIN REF_HARI h3 ON kls.ID_HARI3 = h3.ID_HARI
								FULL OUTER JOIN REF_HARI h4 ON kls.ID_HARI4 = h4.ID_HARI
	                            FULL OUTER JOIN REF_SESI s1 ON kls.ID_SESI_KULIAH1 = s1.ID_SESI
								FULL OUTER JOIN REF_SESI s2 ON kls.ID_SESI_KULIAH2 = s2.ID_SESI
								FULL OUTER JOIN REF_SESI s3 ON kls.ID_SESI_KULIAH3 = s3.ID_SESI
								FULL OUTER JOIN REF_SESI s4 ON kls.ID_SESI_KULIAH4 = s4.ID_SESI
	                            FULL OUTER JOIN MST_DOSEN d1 ON kls.NPP_DOSEN1 = d1.NPP
								FULL OUTER JOIN MST_DOSEN d2 ON kls.NPP_DOSEN2 = d2.NPP
								FULL OUTER JOIN MST_DOSEN d3 ON kls.NPP_DOSEN3 = d3.NPP
								FULL OUTER JOIN MST_DOSEN d4 ON kls.NPP_DOSEN4 = d4.NPP
	                            FULL OUTER JOIN SIATMAX_121212.dbo.REF_BEACON b ON r.ID_BEACON = b.ID_BEACON
                              WHERE d1.NPP = @npp AND kls.NO_SEMESTER = @semester AND b.ID_BEACON IS NOT NULL";

                var param = new { NPP = npp, SEMESTER = semester };
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

        public dynamic GetListKelasMahasiswa()
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

        public dynamic DosenBukaPresensi(int idkelas, int bukapresensi)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.koneksi);

                string query = @"UPDATE TBL_KELAS SET IS_BUKA_PRESENSI = @bukapresensi WHERE ID_KELAS = @idkelas";

                var param = new { IDKELAS = idkelas, BUKAPRESENSI = bukapresensi };
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
        public dynamic GetListPesertaKelas(int idkelas)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.koneksi);

                string query = @"SELECT	mhs.NPM, mhs.NAMA_MHS FROM MST_MHS_AKTIF mhs 
                                JOIN TBL_KRS krs ON mhs.NPM = krs.NPM 
                                JOIN TBL_KELAS kls ON kls.ID_KELAS = krs.ID_KELAS 
                                WHERE kls.ID_KELAS = @idkelas";

                var param = new { IDKELAS = idkelas };
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