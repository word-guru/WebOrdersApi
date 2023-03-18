using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebOrdersApi.Service.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using WebOrdersApi.Service.Interface;

namespace WebOrdersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChequeController : ControllerBase
    {
       /* private readonly IOrderReceipt _cheque;

        public ChequeController(IOrderReceipt cheque)
        {
            _cheque = cheque;
        }

        [HttpGet]
        public async Task<IActionResult> GetCheque(int id)
        {
           var res = await _cheque.GetOrderCheque(id);
            return Ok(res);
        }*/

       /* [HttpGet]
        public async Task<IActionResult> GetInfo(int id)
        {
            var res = await _cheque.GetOrderInfo(id);
            return Ok(res);
        }*/
       
    }
}
