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
    }
}