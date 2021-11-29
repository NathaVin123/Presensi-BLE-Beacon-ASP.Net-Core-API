﻿using Dapper;
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

                // string query = @"SELECT
				// 					kls.ID_KELAS,
		        //                     kls.NAMA_MK,
				// 					kls.KELAS,
				// 					d1.NPP AS NPP_DOSEN1,
				// 					d1.NAMA_DOSEN_LENGKAP AS NAMA_DOSEN1,
		        //                     h1.HARI AS HARI1,
		        //                     s1.SESI AS SESI1,	
				// 					kls.SKS,
				// 					r.RUANG,
                //                     pdsn.PERTEMUAN_KE,
				// 					pdsn.MATERI,
				// 					pdsn.KETERANGAN,
				// 					CONVERT(varchar,pdsn.JAM_MASUK, 8) AS JAM_MASUK,
				// 					CONVERT(varchar,pdsn.JAM_KELUAR, 8) AS JAM_KELUAR,
				// 					kls.KAPASITAS_KELAS,
                //                     CONVERT(varchar, pdsn.JAM_MASUK_SEHARUSNYA, 106) AS TGL_MASUK_SEHARUSNYA,
				// 					CONVERT(varchar, pdsn.JAM_KELUAR_SEHARUSNYA, 106) AS TGL_KELUAR_SEHARUSNYA,
				// 					CONVERT(varchar, pdsn.JAM_MASUK_SEHARUSNYA, 8) AS JAM_MASUK_SEHARUSNYA,
				// 					CONVERT(varchar, pdsn.JAM_KELUAR_SEHARUSNYA, 8) AS JAM_KELUAR_SEHARUSNYA,
                //                     pdsn.IS_BUKA_PRESENSI
                //               FROM  TBL_KELAS kls
	            //                 JOIN MST_RUANG r ON kls.RUANG1 = r.RUANG
				// 				JOIN TBL_KRS krs ON kls.ID_KELAS = krs.ID_KELAS
				// 				JOIN MST_MHS_AKTIF mhs ON krs.NPM = mhs.NPM
	            //                 FULL OUTER JOIN REF_HARI h1 ON kls.ID_HARI1 = h1.ID_HARI
	            //                 FULL OUTER JOIN REF_SESI s1 ON kls.ID_SESI_KULIAH1 = s1.ID_SESI
	            //                 FULL OUTER JOIN MST_DOSEN d1 ON kls.NPP_DOSEN1 = d1.NPP
	            //                 FULL OUTER JOIN SIATMAX_121212.dbo.REF_BEACON b ON r.ID_BEACON = b.ID_BEACON
                //                 FULL OUTER JOIN SIATMAX_121212.dbo.TBL_PRESENSI_DOSEN pdsn ON kls.ID_KELAS = pdsn.ID_Kelas
                //               WHERE mhs.NPM = @npm AND pdsn.PERTEMUAN_KE IS NOT NULL AND pdsn.IS_BUKA_PRESENSI = 3 AND CURRENT_TIMESTAMP > DATEADD(SECOND,0,pdsn.JAM_MASUK_SEHARUSNYA) 
                //               ORDER BY CONVERT(date,JAM_MASUK_SEHARUSNYA) ASC";

				string query = @"SELECT  
									kls.ID_KELAS,
									kls.NAMA_MK,
									kls.KELAS,
									d1.NPP AS NPP_DOSEN1,
									d1.NAMA_DOSEN_LENGKAP AS NAMA_DOSEN1,
									h1.HARI AS HARI1,
									s1.SESI AS SESI1,	
									kls.SKS,
									r.RUANG,
									pmhs.PERTEMUAN_KE,
									pmhs.STATUS,
									CONVERT(varchar,pmhs.TGL_IN, 8) AS JAM_MASUK,
									CONVERT(varchar,pmhs.TGL_OUT, 8) AS JAM_KELUAR,
									CONVERT(varchar,pmhs.TGL_IN, 106) AS TGL_MASUK_SEHARUSNYA,
									CONVERT(varchar,pmhs.TGL_OUT, 106) AS TGL_KELUAR_SEHARUSNYA
							FROM TBL_PRESENSI_MHS pmhs
								JOIN TBL_KELAS kls ON pmhs.ID_Kelas = kls.ID_Kelas
								JOIN MST_RUANG r ON kls.RUANG1 = r.RUANG
								FULL OUTER JOIN REF_HARI h1 ON kls.ID_HARI1 = h1.ID_HARI
								FULL OUTER JOIN REF_SESI s1 ON kls.ID_SESI_KULIAH1 = s1.ID_SESI
								FULL OUTER JOIN MST_DOSEN d1 ON kls.NPP_DOSEN1 = d1.NPP
							WHERE pmhs.NPM = @npm AND pmhs.PERTEMUAN_KE IS NOT NULL AND CURRENT_TIMESTAMP > DATEADD(SECOND,0,pmhs.TGL_IN)
							ORDER BY CONVERT(date,pmhs.TGL_IN) DESC";

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


        public dynamic GetRiwayatDsn(string npp)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.koneksi);
                // Query menampilkan riwayat dalam rentang 6 bulan
                // string query = @"SELECT
				// 					kls.ID_KELAS,
		        //                     kls.NAMA_MK,
				// 					kls.KELAS,
				// 					d1.NPP AS NPP_DOSEN1,
				// 					d1.NAMA_DOSEN_LENGKAP AS NAMA_DOSEN1,
		        //                     h1.HARI AS HARI1,
		        //                     s1.SESI AS SESI1,
				// 					kls.SKS,
				// 					pdsn.PERTEMUAN_KE,
				// 					r.RUANG,
				// 					kls.KAPASITAS_KELAS,
                //                     CONVERT(varchar, pdsn.JAM_MASUK_SEHARUSNYA, 106) AS TGL_MASUK_SEHARUSNYA,
				// 					CONVERT(varchar, pdsn.JAM_KELUAR_SEHARUSNYA, 106) AS TGL_KELUAR_SEHARUSNYA,
				// 					CONVERT(varchar, pdsn.JAM_MASUK_SEHARUSNYA, 8) AS JAM_MASUK_SEHARUSNYA,
				// 					CONVERT(varchar, pdsn.JAM_KELUAR_SEHARUSNYA, 8) AS JAM_KELUAR_SEHARUSNYA,
                //                     pdsn.IS_BUKA_PRESENSI
                //               FROM  TBL_KELAS kls
	            //                 JOIN MST_RUANG r ON kls.RUANG1 = r.RUANG
	            //                 FULL OUTER JOIN REF_HARI h1 ON kls.ID_HARI1 = h1.ID_HARI
	            //                 FULL OUTER JOIN REF_SESI s1 ON kls.ID_SESI_KULIAH1 = s1.ID_SESI
	            //                 FULL OUTER JOIN MST_DOSEN d1 ON kls.NPP_DOSEN1 = d1.NPP
				// 				FULL OUTER JOIN SIATMAX_121212.dbo.TBL_PRESENSI_DOSEN pdsn ON kls.ID_KELAS = pdsn.ID_Kelas
                //               WHERE d1.NPP = '03.96.582' AND pdsn.PERTEMUAN_KE IS NOT NULL AND CURRENT_TIMESTAMP < DATEADD(MONTH,6,pdsn.JAM_MASUK_SEHARUSNYA) AND CURRENT_TIMESTAMP > DATEADD(SECOND,0,pdsn.JAM_MASUK_SEHARUSNYA) 
                //               ORDER BY CONVERT(date,JAM_MASUK_SEHARUSNYA) ASC";


                    string query = @"SELECT
									kls.ID_KELAS,
		                            kls.NAMA_MK,
									kls.KELAS,
									d1.NPP AS NPP_DOSEN1,
									d1.NAMA_DOSEN_LENGKAP AS NAMA_DOSEN1,
		                            h1.HARI AS HARI1,
		                            s1.SESI AS SESI1,
									kls.SKS,
									pdsn.PERTEMUAN_KE,
									pdsn.MATERI,
									pdsn.KETERANGAN,
									CONVERT(varchar,pdsn.JAM_MASUK, 8) AS JAM_MASUK,
									CONVERT(varchar,pdsn.JAM_KELUAR, 8) AS JAM_KELUAR,
									r.RUANG,
									kls.KAPASITAS_KELAS,
                                    CONVERT(varchar, pdsn.JAM_MASUK_SEHARUSNYA, 106) AS TGL_MASUK_SEHARUSNYA,
									CONVERT(varchar, pdsn.JAM_KELUAR_SEHARUSNYA, 106) AS TGL_KELUAR_SEHARUSNYA,
									CONVERT(varchar, pdsn.JAM_MASUK_SEHARUSNYA, 8) AS JAM_MASUK_SEHARUSNYA,
									CONVERT(varchar, pdsn.JAM_KELUAR_SEHARUSNYA, 8) AS JAM_KELUAR_SEHARUSNYA,
                                    pdsn.IS_BUKA_PRESENSI
                              FROM  TBL_KELAS kls
	                            JOIN MST_RUANG r ON kls.RUANG1 = r.RUANG
	                            FULL OUTER JOIN REF_HARI h1 ON kls.ID_HARI1 = h1.ID_HARI
	                            FULL OUTER JOIN REF_SESI s1 ON kls.ID_SESI_KULIAH1 = s1.ID_SESI
	                            FULL OUTER JOIN MST_DOSEN d1 ON kls.NPP_DOSEN1 = d1.NPP
								FULL OUTER JOIN SIATMAX_121212.dbo.TBL_PRESENSI_DOSEN pdsn ON kls.ID_KELAS = pdsn.ID_Kelas
                              WHERE d1.NPP = @npp AND pdsn.PERTEMUAN_KE IS NOT NULL AND CURRENT_TIMESTAMP > DATEADD(SECOND,0,pdsn.JAM_MASUK_SEHARUSNYA) 
                              ORDER BY CONVERT(date,JAM_MASUK_SEHARUSNYA) DESC";

                var param = new { NPP = npp };
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