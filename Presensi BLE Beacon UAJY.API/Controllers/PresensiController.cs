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
                var data = bm.DosenBukaPresensi(ubpd.ID_KELAS, ubpd.IS_BUKA_PRESENSI);

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
        [HttpPost("PostInsertPresensiDosen")]
        public ActionResult InsertDsn([FromForm] UserInsertPresensiDosen uipd)
        {
            try
            {
                var data = bm.InsertPresensiDosen(uipd.ID_Kelas, uipd.NPP, uipd.SKS, uipd.MATERI);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}