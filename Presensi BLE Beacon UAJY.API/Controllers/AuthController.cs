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
    public class AuthController : ControllerBase
    {
        private AuthBM bm;

        public AuthController()
        {
            bm = new AuthBM();
        }

        [AllowAnonymous]
        [HttpPost("LoginMhs")]
        public ActionResult LoginMhs([FromForm] UserLoginMhs ul)
        {
            try
            {
                var data = bm.LoginMhs(ul.NPM, ul.PASSWORD);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("LoginDsn")]
        public ActionResult LoginDsn([FromForm] UserLoginDsn ul)
        {
            try
            {
                var data = bm.LoginDsn(ul.NPP, ul.PASSWORD);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}