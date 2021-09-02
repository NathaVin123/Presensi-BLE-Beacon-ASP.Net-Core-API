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
    public class RuangBeaconController : ControllerBase
    {
        private RuangBeaconBM bm;

        public RuangBeaconController()
        {
            bm = new RuangBeaconBM();
        }

        [AllowAnonymous]
        public ActionResult Get()
        {
            try
            {
                var data = bm.RuangBeacon();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("Tambah")]
        public ActionResult TambahBcn([FromForm] UserTambahBeacon utb)
        {
            try
            {
                var data = bm.TambahBeacon(utb.UUID, utb.NAMA_DEVICE, utb.JARAK_MIN);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("Tampil")]
        public ActionResult ListBcn()
        {
            try
            {
                var data = bm.ListBeacon();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpDelete("Hapus")]
        public ActionResult DeleteBcn([FromForm] UserDeleteBeacon uhb)
        {
            try
            {
                var data = bm.DeleteBeacon(uhb.UUID);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}