using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]

    public class VoyagesController : ControllerBase
    {
        private readonly WebApplication1Context _context;

        public VoyagesController(WebApplication1Context context)
        {
            _context = context;
        }

        // GET: api/Voyages

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<VoyageDTO>>> GetVoyages()
        {


            //if (_context.Voyages == null)
            //{
            //    return NotFound();
            //}
            //  return await _context.Voyages.ToListAsync();

            List<VoyageDTO> voyageDTOs = new List<VoyageDTO>();


            if (_context.Voyages == null)
            {
                return NotFound();
            }
            foreach (var voyage in _context.Voyages)
            {
                VoyageDTO voyageDTO = new VoyageDTO();
                List<string> noms = new List<string>();

                voyageDTO.Id = voyage.Id;
                voyageDTO.Name = voyage.Name;
                voyageDTO.Public = voyage.Public;
                foreach (var user in voyage.VoyageUsers)
                {
                    noms.Add(user.UserName);
                    voyageDTO.UserNames = noms;

                }
                voyageDTOs.Add(voyageDTO);
            }
            return voyageDTOs;
        }

        // GET: api/Voyages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Voyage>> GetVoyage(int id)
        {
            if (_context.Voyages == null)
            {
                return NotFound();
            }
            var voyage = await _context.Voyages.FindAsync(id);

            if (voyage == null)
            {
                return NotFound();
            }

            return voyage;
        }

        // PUT: api/Voyages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutVoyage(ShareDTO shared)
        {
            Voyage voyage = _context.Voyages.Single(v => v.Id == shared.VoyageId);

            try
            {
                VoyageUser user = _context.Users.Single(u => u.UserName == shared.UserName);
                
                voyage.VoyageUsers.Add(user);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoyageExists(voyage.Id))
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

        // POST: api/Voyages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Voyage>> PostVoyage(Voyage voyage)
        {
            if (_context.Voyages == null)
            {
                return Problem("Entity set 'WebApplication1Context.Voyages'  is null.");
            }
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            VoyageUser user = _context.Users.Single(u => u.Id == userId);
            _context.Voyages.Add(voyage);
            voyage.VoyageUsers.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVoyage", new { id = voyage.Id }, voyage);
        }

        // DELETE: api/Voyages/5
        [HttpDelete]
        public async Task<IActionResult> DeleteVoyage(int id)
        {
            if (_context.Voyages == null)
            {
                return Problem("Il ny a pas de voyage");
            }
            var voyage = await _context.Voyages.FindAsync(id);
            if (voyage == null)
            {
                return  Problem("Le voyage is null.");
            }

            _context.Voyages.Remove(voyage);
            await _context.SaveChangesAsync();

            return NoContent();
        }                                                                                                                                                                                                                                                                                                                                                                                    

        private bool VoyageExists(int id)
        {
            return (_context.Voyages?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
