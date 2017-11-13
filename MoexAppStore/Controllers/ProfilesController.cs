using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoexAppStore.Data;
using MoexAppStore.Models;

namespace MoexAppStore.Controllers
{
    [Route("api/[controller]")]
    public class ProfilesController : Controller
    {

        private readonly MoexAppDbContext _context;

        public ProfilesController(MoexAppDbContext ctx)
        {
            _context = ctx;
        }

        [HttpGet]
        public async Task<IEnumerable<Profile>> Get()
        {
            return await _context.Profiles.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Profile> GetById(Int64 id)
        {
            return await _context.Profiles.FirstOrDefaultAsync(p => p.ProfileId == id);
        }

        [HttpPost]
        public async void Post([FromBody]Profile profile)
        {
            await _context.AddAsync(profile);
            await _context.SaveChangesAsync();
        }
    }
}