using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Presensi_BLE_Beacon_UAJY.API.DAO
{
    public class PresensiDAO
    {
        public dynamic GetListKelasDosen(string npp, string tglnow)
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
				// 					d2.NPP AS NPP_DOSEN2,
				// 					d2.NAMA_DOSEN_LENGKAP AS NAMA_DOSEN2,
				// 					d3.NPP AS NPP_DOSEN3,
				// 					d3.NAMA_DOSEN_LENGKAP AS NAMA_DOSEN3,
				// 					d4.NPP AS NPP_DOSEN4,
				// 					d4.NAMA_DOSEN_LENGKAP AS NAMA_DOSEN4,
		        //                     h1.HARI AS HARI1,
				// 					h2.HARI AS HARI2,
				// 					h3.HARI AS HARI3,
				// 					h4.HARI AS HARI4,
		        //                     s1.SESI AS SESI1,
				// 					s2.SESI AS SESI2,
				// 					s3.SESI AS SESI3,
				// 					s4.SESI AS SESI4,
				// 					kls.SKS,
				// 					pdsn.PERTEMUAN_KE,
				// 					r.RUANG,
		        //                     b.PROXIMITY_UUID,
		        //                     b.NAMA_DEVICE,
                //                     b.JARAK_MIN_DEC,
				// 					kls.KAPASITAS_KELAS,
                //                     pdsn.JAM_MASUK_SEHARUSNYA,
				// 					pdsn.JAM_KELUAR_SEHARUSNYA,
                //                     pdsn.IS_BUKA_PRESENSI
                //               FROM  TBL_KELAS kls
	            //                 JOIN MST_RUANG r ON kls.RUANG1 = r.RUANG
	            //                 FULL OUTER JOIN REF_HARI h1 ON kls.ID_HARI1 = h1.ID_HARI
				// 				FULL OUTER JOIN REF_HARI h2 ON kls.ID_HARI2 = h2.ID_HARI
				// 				FULL OUTER JOIN REF_HARI h3 ON kls.ID_HARI3 = h3.ID_HARI
				// 				FULL OUTER JOIN REF_HARI h4 ON kls.ID_HARI4 = h4.ID_HARI
	            //                 FULL OUTER JOIN REF_SESI s1 ON kls.ID_SESI_KULIAH1 = s1.ID_SESI
				// 				FULL OUTER JOIN REF_SESI s2 ON kls.ID_SESI_KULIAH2 = s2.ID_SESI
				// 				FULL OUTER JOIN REF_SESI s3 ON kls.ID_SESI_KULIAH3 = s3.ID_SESI
				// 				FULL OUTER JOIN REF_SESI s4 ON kls.ID_SESI_KULIAH4 = s4.ID_SESI
	            //                 FULL OUTER JOIN MST_DOSEN d1 ON kls.NPP_DOSEN1 = d1.NPP
				// 				FULL OUTER JOIN MST_DOSEN d2 ON kls.NPP_DOSEN2 = d2.NPP
				// 				FULL OUTER JOIN MST_DOSEN d3 ON kls.NPP_DOSEN3 = d3.NPP
				// 				FULL OUTER JOIN MST_DOSEN d4 ON kls.NPP_DOSEN4 = d4.NPP
	            //                 FULL OUTER JOIN SIATMAX_121212.dbo.REF_BEACON b ON r.ID_BEACON = b.ID_BEACON
				// 				FULL OUTER JOIN SIATMAX_121212.dbo.TBL_PRESENSI_DOSEN pdsn ON kls.ID_KELAS = pdsn.ID_Kelas
                //               WHERE d1.NPP = @npp AND b.ID_BEACON IS NOT NULL AND pdsn.PERTEMUAN_KE IS NOT NULL
                //               ORDER BY pdsn.IS_BUKA_PRESENSI DESC, pdsn.PERTEMUAN_KE ASC, kls.KELAS ASC";

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
									pdsn.PERTEMUAN_KE,
									r.RUANG,
		                            b.PROXIMITY_UUID,
		                            b.NAMA_DEVICE,
                                    b.JARAK_MIN_DEC,
									kls.KAPASITAS_KELAS,
									pdsn.JAM_MASUK_SEHARUSNYA,
									pdsn.JAM_KELUAR_SEHARUSNYA,
                                    pdsn.IS_BUKA_PRESENSI
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
								FULL OUTER JOIN SIATMAX_121212.dbo.TBL_PRESENSI_DOSEN pdsn ON kls.ID_KELAS = pdsn.ID_Kelas
                              WHERE d1.NPP = @npp AND b.ID_BEACON IS NOT NULL AND pdsn.PERTEMUAN_KE IS NOT NULL AND @tglnow > JAM_MASUK_SEHARUSNYA AND @tglnow < JAM_KELUAR_SEHARUSNYA
                              ORDER BY pdsn.IS_BUKA_PRESENSI DESC, pdsn.PERTEMUAN_KE ASC, kls.KELAS ASC";

                var param = new { NPP = npp,  TGLNOW = tglnow};
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

        public dynamic GetListKelasMahasiswa(string npm, string tglnow)
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
                                    pdsn.PERTEMUAN_KE,
		                            b.PROXIMITY_UUID,
		                            b.NAMA_DEVICE,
                                    b.JARAK_MIN_DEC,
									kls.KAPASITAS_KELAS,
                                    pdsn.JAM_MASUK_SEHARUSNYA,
									pdsn.JAM_KELUAR_SEHARUSNYA,
                                    pdsn.IS_BUKA_PRESENSI
                              FROM  TBL_KELAS kls
	                            JOIN MST_RUANG r ON kls.RUANG1 = r.RUANG
								JOIN TBL_KRS krs ON kls.ID_KELAS = krs.ID_KELAS
								JOIN MST_MHS_AKTIF mhs ON krs.NPM = mhs.NPM
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
                                FULL OUTER JOIN SIATMAX_121212.dbo.TBL_PRESENSI_DOSEN pdsn ON kls.ID_KELAS = pdsn.ID_Kelas
                              WHERE mhs.NPM = @npm AND b.ID_BEACON IS NOT NULL AND @tglnow > JAM_MASUK_SEHARUSNYA AND @tglnow < JAM_KELUAR_SEHARUSNYA
                              ORDER BY IS_BUKA_PRESENSI DESC";

                var param = new { NPM = npm, tglnow = tglnow };
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

        public dynamic DosenBukaPresensi(int idkelas, int bukapresensi, int pertemuan)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.koneksi);

                string query = @"UPDATE SIATMAX_121212.dbo.TBL_PRESENSI_DOSEN SET IS_BUKA_PRESENSI = @bukapresensi WHERE ID_KELAS = @idkelas AND PERTEMUAN_KE = @pertemuan";

                var param = new { IDKELAS = idkelas, BUKAPRESENSI = bukapresensi , PERTEMUAN = pertemuan };
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
                                WHERE kls.ID_KELAS = @idkelas
                                ORDER BY mhs.NPM ASC";

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

        public dynamic UpdateINPresensiDosen(string jammasuk, int idkelas, int pertemuan)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.koneksi);

                string query = @"UPDATE SIATMAX_121212.dbo.TBL_PRESENSI_DOSEN 
                                SET JAM_MASUK = @jammasuk
                                WHERE ID_Kelas = @idkelas AND PERTEMUAN_KE = @pertemuan";

                var param = new { JAMMASUK = jammasuk, IDKELAS = idkelas, PERTEMUAN = pertemuan };
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

        public dynamic UpdateOUTPresensiDosen(string jamkeluar, string keterangan, string materi, int idkelas, int pertemuan)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.koneksi);

                string query = @"UPDATE SIATMAX_121212.dbo.TBL_PRESENSI_DOSEN 
                                SET JAM_KELUAR = @jamkeluar, 
                                KETERANGAN = @keterangan, 
                                MATERI = @materi
                                WHERE ID_Kelas = @idkelas AND PERTEMUAN_KE = @pertemuan";

                var param = new { JAMKELUAR = jamkeluar, KETERANGAN = keterangan, MATERI = materi, IDKELAS = idkelas, PERTEMUAN = pertemuan };
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

        public dynamic InsertPresensiINMahasiswaToKSI(int idkelas, string npm ,int pertemuan, string tglin)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.koneksi);

                string query = @"INSERT INTO TBL_PRESENSI_MHS 
                                (ID_Kelas, 
                                NPM, 
                                PERTEMUAN_KE, 
                                TGL_IN)
								VALUES 
                                (@idkelas
                                ,@npm
                                ,@pertemuan
                                ,@tglin)";

                var param = new {IDKELAS = idkelas, NPM = npm, PERTEMUAN = pertemuan, tglin = tglin};
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

        public dynamic UpdatePresensiOUTMahasiswaToKSI(int idkelas, string npm ,int pertemuan, string tglout, string status)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.koneksi);

                string query = @"UPDATE TBL_PRESENSI_MHS 
                                SET TGL_OUT = @tglout, 
                                STATUS = @status
                                WHERE ID_Kelas = @idkelas AND NPM = @npm AND PERTEMUAN_KE = @pertemuan";

                var param = new {IDKELAS = idkelas, NPM = npm, PERTEMUAN = pertemuan, TGLOUT = tglout, STATUS = status};
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

        public dynamic InsertPresensiINMahasiswaToFBE(int idkelas, string npm ,int pertemuan, string tglin)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.koneksi);

                string query = @"INSERT INTO SIATMA_FBE.dbo.TBL_PRESENSI_MHS 
                                (ID_Kelas, 
                                NPM, 
                                PERTEMUAN_KE, 
                                TGL_IN)
								VALUES 
                                (@idkelas
                                ,@npm
                                ,@pertemuan
                                ,@tglin)";

                var param = new {IDKELAS = idkelas, NPM = npm, PERTEMUAN = pertemuan, tglin = tglin};
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

        public dynamic UpdatePresensiOUTMahasiswaToFBE(int idkelas, string npm ,int pertemuan, string tglout, string status)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.koneksi);

                string query = @"UPDATE SIATMA_FBE.dbo.TBL_PRESENSI_MHS 
                                SET TGL_OUT = @tglout, 
                                STATUS = @status
                                WHERE ID_Kelas = @idkelas AND NPM = @npm AND PERTEMUAN_KE = @pertemuan";

                var param = new {IDKELAS = idkelas, NPM = npm, PERTEMUAN = pertemuan, TGLOUT = tglout, STATUS = status};
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

        public dynamic InsertPresensiINMahasiswaToFH(int idkelas, string npm ,int pertemuan, string tglin)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.koneksi);

                string query = @"INSERT INTO SIATMA_FH.dbo.TBL_PRESENSI_MHS 
                                (ID_Kelas, 
                                NPM, 
                                PERTEMUAN_KE, 
                                TGL_IN)
								VALUES 
                                (@idkelas
                                ,@npm
                                ,@pertemuan
                                ,@tglin)";

                var param = new {IDKELAS = idkelas, NPM = npm, PERTEMUAN = pertemuan, tglin = tglin};
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

        public dynamic UpdatePresensiOUTMahasiswaToFH(int idkelas, string npm ,int pertemuan, string tglout, string status)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.koneksi);

                string query = @"UPDATE SIATMA_FH.dbo.TBL_PRESENSI_MHS 
                                SET TGL_OUT = @tglout, 
                                STATUS = @status
                                WHERE ID_Kelas = @idkelas AND NPM = @npm AND PERTEMUAN_KE = @pertemuan";

                var param = new {IDKELAS = idkelas, NPM = npm, PERTEMUAN = pertemuan, TGLOUT = tglout, STATUS = status};
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

        public dynamic InsertPresensiINMahasiswaToFISIP(int idkelas, string npm ,int pertemuan, string tglin)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.koneksi);

                string query = @"INSERT INTO SIATMA_FISIP.dbo.TBL_PRESENSI_MHS 
                                (ID_Kelas, 
                                NPM, 
                                PERTEMUAN_KE, 
                                TGL_IN)
								VALUES 
                                (@idkelas
                                ,@npm
                                ,@pertemuan
                                ,@tglin)";

                var param = new {IDKELAS = idkelas, NPM = npm, PERTEMUAN = pertemuan, tglin = tglin};
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

        public dynamic UpdatePresensiOUTMahasiswaToFISIP(int idkelas, string npm ,int pertemuan, string tglout, string status)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.koneksi);

                string query = @"UPDATE SIATMA_FISIP.dbo.TBL_PRESENSI_MHS 
                                SET TGL_OUT = @tglout, 
                                STATUS = @status
                                WHERE ID_Kelas = @idkelas AND NPM = @npm AND PERTEMUAN_KE = @pertemuan";

                var param = new {IDKELAS = idkelas, NPM = npm, PERTEMUAN = pertemuan, TGLOUT = tglout, STATUS = status};
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

        public dynamic InsertPresensiINMahasiswaToFT(int idkelas, string npm ,int pertemuan, string tglin)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.koneksi);

                string query = @"INSERT INTO SIATMA_FT.dbo.TBL_PRESENSI_MHS 
                                (ID_Kelas, 
                                NPM, 
                                PERTEMUAN_KE, 
                                TGL_IN)
								VALUES 
                                (@idkelas
                                ,@npm
                                ,@pertemuan
                                ,@tglin)";

                var param = new {IDKELAS = idkelas, NPM = npm, PERTEMUAN = pertemuan, tglin = tglin};
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

        public dynamic UpdatePresensiOUTMahasiswaToFT(int idkelas, string npm ,int pertemuan, string tglout, string status)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.koneksi);

                string query = @"UPDATE SIATMA_FT.dbo.TBL_PRESENSI_MHS 
                                SET TGL_OUT = @tglout, 
                                STATUS = @status
                                WHERE ID_Kelas = @idkelas AND NPM = @npm AND PERTEMUAN_KE = @pertemuan";

                var param = new {IDKELAS = idkelas, NPM = npm, PERTEMUAN = pertemuan, TGLOUT = tglout, STATUS = status};
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

        public dynamic InsertPresensiINMahasiswaToFTB(int idkelas, string npm ,int pertemuan, string tglin)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.koneksi);

                string query = @"INSERT INTO SIATMA_FTB.dbo.TBL_PRESENSI_MHS 
                                (ID_Kelas, 
                                NPM, 
                                PERTEMUAN_KE, 
                                TGL_IN)
								VALUES 
                                (@idkelas
                                ,@npm
                                ,@pertemuan
                                ,@tglin)";

                var param = new {IDKELAS = idkelas, NPM = npm, PERTEMUAN = pertemuan, tglin = tglin};
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

        public dynamic UpdatePresensiOUTMahasiswaToFTB(int idkelas, string npm ,int pertemuan, string tglout, string status)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.koneksi);

                string query = @"UPDATE SIATMA_FTB.dbo.TBL_PRESENSI_MHS 
                                SET TGL_OUT = @tglout, 
                                STATUS = @status
                                WHERE ID_Kelas = @idkelas AND NPM = @npm AND PERTEMUAN_KE = @pertemuan";

                var param = new {IDKELAS = idkelas, NPM = npm, PERTEMUAN = pertemuan, TGLOUT = tglout, STATUS = status};
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

        public dynamic InsertPresensiINMahasiswaToFTI(int idkelas, string npm ,int pertemuan, string tglin)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.koneksi);

                string query = @"INSERT INTO SIATMA_FTI.dbo.TBL_PRESENSI_MHS 
                                (ID_Kelas, 
                                NPM, 
                                PERTEMUAN_KE, 
                                TGL_IN)
								VALUES 
                                (@idkelas
                                ,@npm
                                ,@pertemuan
                                ,@tglin)";

                var param = new {IDKELAS = idkelas, NPM = npm, PERTEMUAN = pertemuan, tglin = tglin};
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

        public dynamic UpdatePresensiOUTMahasiswaToFTI(int idkelas, string npm ,int pertemuan, string tglout, string status)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.koneksi);

                string query = @"UPDATE SIATMA_FTI.dbo.TBL_PRESENSI_MHS 
                                SET TGL_OUT = @tglout, 
                                STATUS = @status
                                WHERE ID_Kelas = @idkelas AND NPM = @npm AND PERTEMUAN_KE = @pertemuan";

                var param = new {IDKELAS = idkelas, NPM = npm, PERTEMUAN = pertemuan, TGLOUT = tglout, STATUS = status};
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