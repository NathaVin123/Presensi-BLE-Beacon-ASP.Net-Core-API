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
    }
}