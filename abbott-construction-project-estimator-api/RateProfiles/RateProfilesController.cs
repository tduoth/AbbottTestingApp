using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectEstimator.Api.Data;
using ProjectEstimator.Api.Users;

namespace ProjectEstimator.Api.RateProfiles
{
    [ApiController]
    [Route("[controller]")]
    public class RateProfilesController : ControllerBase
    {
        private readonly AppDbContext _db;

        public RateProfilesController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<List<RateProfile>> GetAllAsync()
        {
            return await _db.RateProfiles.ToListAsync();
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetSingleAsync(Guid id)
        {
            var rateProfile = await _db.RateProfiles.FindAsync(id);

            return rateProfile != null ? (IActionResult) Ok(rateProfile) : NotFound();
        }

        [Authorize(Roles = Roles.Administrator)]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateSingleAsync(Guid id, RateProfile rateProfile)
        {
            if (id != rateProfile.Id)
                return BadRequest();

            _db.Entry(rateProfile).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _db.RateProfiles.AnyAsync(rp => rp.Id == rateProfile.Id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }
    }
}