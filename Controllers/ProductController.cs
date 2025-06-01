using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using khaithocode_deploy_webapi.Models;
using Microsoft.AspNetCore.Mvc;
//using khaithocode_deploy_webapi.Models;

namespace khaithocode_deploy_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        StoreContext _context;
        public ProductController(StoreContext context)
        {
            _context = context;
        }
        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            return Ok(_context.Products.ToList());
        }
        [HttpGet("getbyid/{id}")]
        public async Task<ActionResult> GetAll([FromRoute] int id)
        {
            return Ok(_context.Products.SingleOrDefault(n=>n.Id == id));
        }

       
       
    }
}