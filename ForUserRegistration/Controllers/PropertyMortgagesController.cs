using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ForUserRegistration.Models;
using System.IO;
using System.Net.Http.Headers;

namespace ForUserRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyMortgagesController : ControllerBase
    {

        /// <summary>
        /// Uploading of documents starts here
        /// </summary>
        /// <returns></returns>


        public IActionResult Upload()
        {
            try
            {
                var files = Request.Form.Files;
                var folderName = Path.Combine("StaticFiles", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (files.Any(f => f.Length == 0))
                {
                    return BadRequest();
                }

                foreach (var file in files)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName); //you can add this path to a list and then return all dbPaths to the client if require

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

                return Ok("All the files are successfully uploaded.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


        /// <summary>
        /// The uploading of documents stops here.
        /// </summary>
        private readonly AuthenticationContext _context;

        public PropertyMortgagesController(AuthenticationContext context)
        {
            _context = context;
        }

        // GET: api/PropertyMortgages
        [HttpGet]
        public IEnumerable<PropertyMortgage> GetPropertyMortgage()
        {
            return _context.PropertyMortgage;
        }

        // GET: api/PropertyMortgages/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPropertyMortgage([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var propertyMortgage = await _context.PropertyMortgage.FindAsync(id);

            if (propertyMortgage == null)
            {
                return NotFound();
            }

            return Ok(propertyMortgage);
        }

        // PUT: api/PropertyMortgages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPropertyMortgage([FromRoute] int id, [FromBody] PropertyMortgage propertyMortgage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != propertyMortgage.PropertyId)
            {
                return BadRequest();
            }

            _context.Entry(propertyMortgage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyMortgageExists(id))
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

        // POST: api/PropertyMortgages
        [HttpPost]
        public async Task<IActionResult> PostPropertyMortgage([FromBody] PropertyMortgage propertyMortgage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PropertyMortgage.Add(propertyMortgage);
            await _context.SaveChangesAsync();

           
                propertyMortgage.FilePath = "../images/error.png";
            


            return CreatedAtAction("GetPropertyMortgage", new { id = propertyMortgage.PropertyId }, propertyMortgage);
        }

        // DELETE: api/PropertyMortgages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePropertyMortgage([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var propertyMortgage = await _context.PropertyMortgage.FindAsync(id);
            if (propertyMortgage == null)
            {
                return NotFound();
            }

            _context.PropertyMortgage.Remove(propertyMortgage);
            await _context.SaveChangesAsync();

            return Ok(propertyMortgage);
        }

        private bool PropertyMortgageExists(int id)
        {
            return _context.PropertyMortgage.Any(e => e.PropertyId == id);
        }
    }
}