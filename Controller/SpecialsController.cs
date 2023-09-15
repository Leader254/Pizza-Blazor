using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazingPizza.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazingPizza.Controller
{
    [ApiController]
    [Route("specials")]
    public class SpecialsController : ControllerBase
    {
        private readonly PizzaStoreContext _context;
        public SpecialsController(PizzaStoreContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<PizzaSpecial>>> GetSpecials()
        {
            return (await _context.Specials.ToListAsync()).OrderByDescending(s => s.BasePrice).ToList();
        }
    }
}