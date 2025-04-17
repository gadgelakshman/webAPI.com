using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using webAPI.com.Models;

namespace webAPI.com.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DairyFarmController : ControllerBase
    {
        private readonly DairyFarmDbContext d;

        public DairyFarmController(DairyFarmDbContext d)
        {
            this.d = d;
        }

        [HttpGet]

        public async Task<ActionResult<List<Cow>>> GetDairyFarm()
        {
            var data= await d.Cows.ToListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<List<Cow>>> GetDairyFarmByID(int id)
        {
            var data = await d.Cows.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpPost]
        public async Task<ActionResult<Cow>> CreateData(Cow co)
        {
                await d.Cows.AddAsync(co);
            await d.SaveChangesAsync();
            return Ok(co);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateData(int id,Cow co)
        {
            if (id != co.CowId)
            {
                return BadRequest("Cow ID mismatch.");
            }
            d.Entry(co).State = EntityState.Modified;
            await d.SaveChangesAsync();
            return Ok(co);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCow(int id)
        {
            var cow = await d.Cows
                .Include(c => c.Feeds)
                .Include(c => c.HealthRecords)
                .Include(c => c.MilkProductions)
                .FirstOrDefaultAsync(c => c.CowId == id);

            if (cow == null)
            {
                return NotFound(new { message = "Cow not found" });
            }

           
            d.Feeds.RemoveRange(cow.Feeds);
            d.HealthRecords.RemoveRange(cow.HealthRecords);
            d.MilkProductions.RemoveRange(cow.MilkProductions);

           
            d.Cows.Remove(cow);

            await d.SaveChangesAsync();

            return Ok(new { message = "Cow and related records deleted successfully" });
        }



    }
}
