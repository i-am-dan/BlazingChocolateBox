using BlazingChocolate.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BlazingChocolate.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : Controller
    {
        public static int _id;

        private AppDbContext _context;

        public ApplicationController (AppDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var apps = await _context.Applications.ToListAsync();
            return Ok(apps);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var apps = await _context.Applications.FirstOrDefaultAsync(a => a.Id == id);
            return Ok(apps);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Application app)
        {
            _id += 1;
            app.SubscriptionGuid = Guid.NewGuid();
            app.audCreatedOn = DateTime.Now;
            app.audCreatedBy = "RandomUser" + _id.ToString();
            app.audModifiedOn = DateTime.Now;
            app.audModifiedBy = "RandomUser" + _id.ToString();

            _context.Add(app);

            await _context.SaveChangesAsync();

            return Ok(app.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Application app)
        {
            _context.Entry(app).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var app = new Application { Id = id };
            _context.Remove(app);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
