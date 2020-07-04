using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlogAPI.Models.DBModels;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogpostsController : ControllerBase
    {
        private readonly samplebookContext _context;

        public BlogpostsController(samplebookContext context)
        {
            _context = context;
        }

        // GET: api/Blogposts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Blogpost>>> GetBlogpost()
        {
            return await _context.Blogpost.ToListAsync();
        }

        // GET: api/Blogposts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Blogpost>> GetBlogpost(int id)
        {
            var blogpost = await _context.Blogpost.FindAsync(id);

            if (blogpost == null)
            {
                return NotFound();
            }

            return blogpost;
        }

        // PUT: api/Blogposts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlogpost(int id, Blogpost blogpost)
        {
            if (id != blogpost.Id)
            {
                return BadRequest();
            }

            _context.Entry(blogpost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogpostExists(id))
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

        // POST: api/Blogposts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Blogpost>> PostBlogpost(Blogpost blogpost)
        {
            _context.Blogpost.Add(blogpost);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBlogpost", new { id = blogpost.Id }, blogpost);
        }

        // DELETE: api/Blogposts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Blogpost>> DeleteBlogpost(int id)
        {
            var blogpost = await _context.Blogpost.FindAsync(id);
            if (blogpost == null)
            {
                return NotFound();
            }

            _context.Blogpost.Remove(blogpost);
            await _context.SaveChangesAsync();

            return blogpost;
        }

        private bool BlogpostExists(int id)
        {
            return _context.Blogpost.Any(e => e.Id == id);
        }
    }
}
