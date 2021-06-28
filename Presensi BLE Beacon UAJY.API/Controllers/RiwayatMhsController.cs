﻿using Presensi_BLE_Beacon_UAJY.API.BM;
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
        [HttpPost("PostGetAll")]
        public ActionResult RiwayatMhs([FromForm] UserRiwayatMhs urm)
        {
            try
            {
                var data = bm.RiwayatMhs(urm.NPM, urm.SEMESTER);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}