using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Grocery.Models;

namespace Grocery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroceriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GroceriesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Groceries
        [HttpGet]
        public IEnumerable<Grocery.Models.Grocery> GetGrocery()
        {
            return _context.Grocery;
        }

        // GET: api/Groceries/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGrocery([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var grocery = await _context.Grocery.FindAsync(id);

            if (grocery == null)
            {
                return NotFound();
            }

            return Ok(grocery);
        }

        // PUT: api/Groceries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrocery([FromRoute] int id, [FromBody] Grocery.Models.Grocery grocery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != grocery.Id)
            {
                return BadRequest();
            }

            _context.Entry(grocery).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroceryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Groceries
        [HttpPost]
        public async Task<IActionResult> PostGrocery([FromBody] Grocery.Models.Grocery grocery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Grocery.Add(grocery);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGrocery", new { id = grocery.Id }, grocery);
        }

        // DELETE: api/Groceries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrocery([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var grocery = await _context.Grocery.FindAsync(id);
            if (grocery == null)
            {
                return NotFound();
            }

            _context.Grocery.Remove(grocery);
            await _context.SaveChangesAsync();

            return Ok(grocery);
        }

        private bool GroceryExists(int id)
        {
            return _context.Grocery.Any(e => e.Id == id);
        }



    [HttpPut("sell/{id}")]
    public ActionResult<Grocery.Models.Grocery> LoanBook([FromRoute]int id, [FromBody] Sold loan) {
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }
    var prd = _context.Grocery.Find(id);
    if (prd == null) {
        return BadRequest();
    }
    prd.IsSold = true;
    _context.SaveChanges();
    return Ok(prd);
}


[HttpDelete("sell/{id}")]
public ActionResult<Grocery.Models.Grocery> SellPrd([FromRoute]int id) {
    
    var prd = _context.Grocery.Find(id);
    if (prd == null) {
        return BadRequest();
    }
     _context.Grocery.Remove(prd);
    _context.SaveChanges();
    return Ok(prd);
}
    }
}