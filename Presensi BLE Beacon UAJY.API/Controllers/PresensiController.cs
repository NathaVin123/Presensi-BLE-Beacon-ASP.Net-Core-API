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
                var data = bm.ListKelasDsn(ulkd.NPP, ulkd.SEMESTER);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}