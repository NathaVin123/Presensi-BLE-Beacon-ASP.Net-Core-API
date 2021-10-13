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
                var data = bm.TambahBeacon(utb.UUID, utb.NAMA_DEVICE, utb.JARAK_MIN, utb.MAJOR, utb.MINOR);

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
        [HttpPut("Ubah")]
        public ActionResult UpdateBcn([FromForm] UserUpdateBeacon uub)
        {
            try
            {
                var data = bm.UpdateBeacon(uub.UUID, uub.NAMA_DEVICE, uub.JARAK_MIN, uub.MAJOR, uub.MINOR);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPut("SoftHapus")]
        public ActionResult DeleteBcn([FromForm] UserDeleteBeacon udb)
        {
            try
            {
                var data = bm.DeleteBeacon(udb.UUID, udb.STATUS);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("NamaDevice")]
        public ActionResult ListRngnDevice([FromForm] UserListRuanganNamaDevice ulrnd)
        {
            try
            {
                var data = bm.ListRuanganNamaDevice(ulrnd.RUANG);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("TampilRuangan")]
        public ActionResult ListRngn()
        {
            try
            {
                var data = bm.ListRuangan();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("TampilDetailRuangan")]
        public ActionResult ListDetailRngn()
        {
            try
            {
                var data = bm.ListDetailRuangan();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPut("UbahRuangBeacon")]
        public ActionResult UpdateRuangBcn([FromForm] UserUpdateRuangBeacon uurb)
        {
            try
            {
                var data = bm.UpdateRuangBeacon(uurb.RUANG, uurb.NAMA_DEVICE);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}