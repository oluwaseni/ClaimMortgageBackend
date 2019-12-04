//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Net.Http.Headers;
//using System.Threading.Tasks;
//using ForUserRegistration.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace ForUserRegistration.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ImageController : ControllerBase
//    {
//        [HttpPost("upload")]
//        public async Task<IActionResult> Upload(List<IFormFile> files)
//        {
//            try
//            {
//                var result = new List<image>();
//                foreach (var file in files)
//                {
//                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", file.FileName);
//                    var stream = new FileStream(path, FileMode.Create);
//                    await file.CopyToAsync(stream);
//                    result.Add(new image() { ImageName = file.FileName, Length = file.Length });
//                }
//                return Ok(result);
//            }
//            catch
//            {
//                return BadRequest();
//            }
//        }


//        public IActionResult Uploads()
//        {
//            try
//            {
//                var files = Request.Form.Files;
//                var folderName = Path.Combine("StaticFiles", "Images");
//                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

//                if (files.Any(f => f.Length == 0))
//                {
//                    return BadRequest();
//                }

//                foreach (var file in files)
//                {
//                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
//                    var fullPath = Path.Combine(pathToSave, fileName);
//                    var dbPath = Path.Combine(folderName, fileName); //you can add this path to a list and then return all dbPaths to the client if require

//                    using (var stream = new FileStream(fullPath, FileMode.Create))
//                    {
//                        file.CopyTo(stream);
//                    }
//                }

//                return Ok("All the files are successfully uploaded.");
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, "Internal server error");
//            }
//        }

//    }
//}