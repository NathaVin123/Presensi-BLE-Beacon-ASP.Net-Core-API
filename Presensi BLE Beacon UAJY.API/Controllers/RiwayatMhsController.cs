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
    public class RiwayatMhsController : ControllerBase
    {
        private RiwayatMhsBM bm;

        public RiwayatMhsController()
        {
            bm = new RiwayatMhsBM();
        }

        [AllowAnonymous]
        [HttpPost("RiwayatMhs")]
        public ActionResult RiwayatMhs([FromForm] UserLoginMhs ul)
        {
            try
            {
                var data = bm.RiwayatMhs(ul.NPM);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}