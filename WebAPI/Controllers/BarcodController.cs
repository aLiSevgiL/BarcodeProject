﻿using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BarcodController : ControllerBase
    {

        IBarcodService _barcodService;


        public BarcodController(IBarcodService barcodService)
        {
            _barcodService = barcodService;
        }

 

        [HttpPost("add")]
        public IActionResult Add(ProductBarcod productbarcod)
        {
            var result = _barcodService.AddShipmentDocumentBarcod(productbarcod);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }

        }



        [HttpGet("getall")]
        public IActionResult Get()
        {
            var result = _barcodService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }

        }





    }
}
