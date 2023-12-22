using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly WebApplication1Context _context;

        public ImagesController(WebApplication1Context context)
        {
            _context = context;
        }

        // GET: api/Images
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Photo>>> GetImage()
        {
          if (_context.Photos == null)
          {
              return NotFound();
          }
            return await _context.Photos.ToListAsync();
        }

        // GET: api/Images/5
        [HttpGet("{size}/{id}")]
        public async Task<IActionResult> GetImage(string size, int id)
        {
         
            Photo photo = await _context.Photos.FindAsync(id);

            byte[] bytes = System.IO.File.ReadAllBytes("C://Images/" + size + "/" + photo.FileName);

            return File(bytes, photo.MimeType);
        }


        // POST: api/Images
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [DisableRequestSizeLimit]
        public async Task<ActionResult<Photo>> PostImage()
        {
            try
            {
                IFormCollection formCollection = await Request.ReadFormAsync();
                IFormFile file = formCollection.Files.First();

                Image image = Image.Load(file.OpenReadStream());
                Photo photo = new Photo();

                photo.MimeType = file.ContentType;
                photo.FileName = Guid.NewGuid().ToString();
                if (photo.MimeType == "image/jpeg")
                    photo.FileName += ".jpg";
                
                
                image.Save("C://Images/Large/" + photo.FileName);
                image.Mutate(i => {
                    i.Resize(new ResizeOptions()
                    {
                        Mode = ResizeMode.Min,
                        Size = new Size() { Height = 500}
                    });
                });
                image.Save("C://Images/Medium/" + photo.FileName);
                image.Mutate(i => {
                    i.Resize(new ResizeOptions()
                    {
                        Mode = ResizeMode.Min,
                        Size = new Size() { Height = 200 }
                    });
                });
                image.Save("C://Images/Small/" + photo.FileName);



                _context.Photos.Add(photo);
                _context.SaveChanges();

                

            }
            catch(Exception){}
            return Ok();
        }

        // DELETE: api/Images/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage(int id)
        {
            if (_context.Photos == null)
            {
                return NotFound();
            }
            var image = await _context.Photos.FindAsync(id);
            if (image == null)
            {
                return NotFound();
            }

            _context.Photos.Remove(image);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImageExists(int id)
        {
            return (_context.Photos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
