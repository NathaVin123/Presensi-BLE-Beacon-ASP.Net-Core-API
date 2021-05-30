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
    public class JadwalMhsController : ControllerBase
    {
        private JadwalMhsBM bm;

        public JadwalMhsController()
        {
            bm = new JadwalMhsBM();
        }

        [AllowAnonymous]
        [HttpPost("JadwalMhs")]
        public ActionResult JadwalMhs([FromForm] UserLoginMhs ul)
        {
            try
            {
                var data = bm.JadwalMhs(ul.NPM);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}