using Presensi_BLE_Beacon_UAJY.API.BM;
using Presensi_BLE_Beacon_UAJY.API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Presensi_BLE_Beacon_UAJY.API.Controllers
{
    [Serializable]
    [Route("api/[controller]")]
    [ApiController]
    public class PresensiController : ControllerBase
    {
        private PresensiBM bm;

        public PresensiController()
        {
            bm = new PresensiBM();
        }

        [AllowAnonymous]
        [HttpPost("PostGetListKelas")]
        public ActionResult ListKelasDsn([FromForm] UserListKelasDsn ulkd)
        {
            try
            {
                var data = bm.ListKelasDsn(ulkd.NPP);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("PostGetAllListKelas")]
        public ActionResult ListAllKelasDsn([FromForm] UserListKelasDsn ulkd)
        {
            try
            {
                var data = bm.ListAllKelasDsn(ulkd.NPP);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("PostGetListKelasMhs")]
        public ActionResult ListKelasMhs([FromForm] UserListKelasMhs ulkm)
        {
            try
            {
                var data = bm.ListKelasMhs(ulkm.NPM);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("PostGetAllListKelasMhs")]
        public ActionResult ListAllKelasMhs([FromForm] UserListKelasMhs ulkm)
        {
            try
            {
                var data = bm.ListAllKelasMhs(ulkm.NPM);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPut("BukaPresensiDosen")]
        public ActionResult BukaKelasDsn([FromForm] UserBukaPresensiDosen ubpd)
        {
            try
            {
                var data = bm.DosenBukaPresensi(ubpd.ID_KELAS, ubpd.IS_BUKA_PRESENSI, ubpd.PERTEMUAN_KE);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("PostGetListPesertaKelas")]
        public ActionResult ListKelasMhs([FromForm] UserListPesertaKelas ulpk)
        {
            try
            {
                var data = bm.ListPesertaKelasDsn(ulpk.ID_KELAS);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPut("PutINPresensiDosen")]
        public ActionResult UpdateINPresensiDsn([FromForm] UserUpdateINPresensiDosen uuipd)
        {
            try
            {
                var data = bm.UpdateINPresensiDosen(uuipd.JAM_MASUK, uuipd.ID_KELAS, uuipd.PERTEMUAN_KE);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPut("PutOUTPresensiDosen")]
        public ActionResult UpdateOUTPresensiDsn([FromForm] UserUpdateOUTPresensiDosen uuopd)
        {
            try
            {
                var data = bm.UpdateOUTPresensiDosen(uuopd.JAM_KELUAR, uuopd.KETERANGAN, uuopd.MATERI, uuopd.ID_KELAS, uuopd.PERTEMUAN_KE);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("PostInMhsToKSI")]
        public ActionResult InsertINPresensiMhsToKSI([FromForm] UserInsertPresensiINToKSI presensiin)
        {
            try
            {
                var data = bm.InsertPresensiINMhsToKSI(presensiin.ID_KELAS, presensiin.NPM, presensiin.PERTEMUAN, presensiin.TGLIN);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPut("PutOutMhsToKSI")]
        public ActionResult UpdateOUTPresensiMhsToKSI([FromForm] UserUpdatePresensiOUTToKSI presensiout)
        {
            try
            {
                var data = bm.UpdatePresensiOUTMhsToKSI(presensiout.ID_KELAS, presensiout.NPM, presensiout.PERTEMUAN, presensiout.TGLOUT, presensiout.STATUS);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("PostInMhsToFBE")]
        public ActionResult InsertINPresensiMhsToFBE([FromForm] UserInsertPresensiINToKSI presensiin)
        {
            try
            {
                var data = bm.InsertPresensiINMhsToFBE(presensiin.ID_KELAS, presensiin.NPM, presensiin.PERTEMUAN, presensiin.TGLIN);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPut("PutOutMhsToFBE")]
        public ActionResult UpdateOUTPresensiMhsToFBE([FromForm] UserUpdatePresensiOUTToKSI presensiout)
        {
            try
            {
                var data = bm.UpdatePresensiOUTMhsToFBE(presensiout.ID_KELAS, presensiout.NPM, presensiout.PERTEMUAN, presensiout.TGLOUT, presensiout.STATUS);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("PostInMhsToFH")]
        public ActionResult InsertINPresensiMhsToFH([FromForm] UserInsertPresensiINToKSI presensiin)
        {
            try
            {
                var data = bm.InsertPresensiINMhsToFH(presensiin.ID_KELAS, presensiin.NPM, presensiin.PERTEMUAN, presensiin.TGLIN);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPut("PutOutMhsToFH")]
        public ActionResult UpdateOUTPresensiMhsToFH([FromForm] UserUpdatePresensiOUTToKSI presensiout)
        {
            try
            {
                var data = bm.UpdatePresensiOUTMhsToFH(presensiout.ID_KELAS, presensiout.NPM, presensiout.PERTEMUAN, presensiout.TGLOUT, presensiout.STATUS);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("PostInMhsToFISIP")]
        public ActionResult InsertINPresensiMhsToFISIP([FromForm] UserInsertPresensiINToKSI presensiin)
        {
            try
            {
                var data = bm.InsertPresensiINMhsToFISIP(presensiin.ID_KELAS, presensiin.NPM, presensiin.PERTEMUAN, presensiin.TGLIN);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPut("PutOutMhsToFISIP")]
        public ActionResult UpdateOUTPresensiMhsToFISIP([FromForm] UserUpdatePresensiOUTToKSI presensiout)
        {
            try
            {
                var data = bm.UpdatePresensiOUTMhsToFISIP(presensiout.ID_KELAS, presensiout.NPM, presensiout.PERTEMUAN, presensiout.TGLOUT, presensiout.STATUS);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("PostInMhsToFT")]
        public ActionResult InsertINPresensiMhsToFT([FromForm] UserInsertPresensiINToKSI presensiin)
        {
            try
            {
                var data = bm.InsertPresensiINMhsToFT(presensiin.ID_KELAS, presensiin.NPM, presensiin.PERTEMUAN, presensiin.TGLIN);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPut("PutOutMhsToFT")]
        public ActionResult UpdateOUTPresensiMhsToFT([FromForm] UserUpdatePresensiOUTToKSI presensiout)
        {
            try
            {
                var data = bm.UpdatePresensiOUTMhsToFT(presensiout.ID_KELAS, presensiout.NPM, presensiout.PERTEMUAN, presensiout.TGLOUT, presensiout.STATUS);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("PostInMhsToFTB")]
        public ActionResult InsertINPresensiMhsToFTB([FromForm] UserInsertPresensiINToKSI presensiin)
        {
            try
            {
                var data = bm.InsertPresensiINMhsToFTB(presensiin.ID_KELAS, presensiin.NPM, presensiin.PERTEMUAN, presensiin.TGLIN);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPut("PutOutMhsToFTB")]
        public ActionResult UpdateOUTPresensiMhsToFTB([FromForm] UserUpdatePresensiOUTToKSI presensiout)
        {
            try
            {
                var data = bm.UpdatePresensiOUTMhsToFTB(presensiout.ID_KELAS, presensiout.NPM, presensiout.PERTEMUAN, presensiout.TGLOUT, presensiout.STATUS);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("PostInMhsToFTI")]
        public ActionResult InsertINPresensiMhsToFTI([FromForm] UserInsertPresensiINToKSI presensiin)
        {
            try
            {
                var data = bm.InsertPresensiINMhsToFTI(presensiin.ID_KELAS, presensiin.NPM, presensiin.PERTEMUAN, presensiin.TGLIN);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPut("PutOutMhsToFTI")]
        public ActionResult UpdateOUTPresensiMhsToFTI([FromForm] UserUpdatePresensiOUTToKSI presensiout)
        {
            try
            {
                var data = bm.UpdatePresensiOUTMhsToFTI(presensiout.ID_KELAS, presensiout.NPM, presensiout.PERTEMUAN, presensiout.TGLOUT, presensiout.STATUS);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}