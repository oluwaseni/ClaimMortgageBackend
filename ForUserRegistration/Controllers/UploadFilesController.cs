using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ForUserRegistration.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ForUserRegistration.Controllers
{
    [Produces("application/json")]
    [Route("api/files")]
    public class UploadController : Controller
    {

        [HttpPost("Upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {

            try
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot/files", file.FileName);
                var stream = new FileStream(path, FileMode.Create);
                file.CopyToAsync(stream);
                return Ok(new { length = file.Length, name = file.FileName });
            }
            catch
            {
                return BadRequest();
            }

        }


        [HttpPost("Uploads")]
        public async Task<IActionResult> Uploads(List<IFormFile> files)
        {

            try
            {
                var result = new List<FileUploadResults>();
                foreach(var file in files)
                { 
                var path = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot/files", file.FileName);
                var stream = new FileStream(path, FileMode.Create);
                file.CopyToAsync(stream);

                    result.Add(new FileUploadResults() {

                        Name = file.FileName,
                        Length = file.Length});

                }

                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }

        }





















        //private IHostingEnvironment _hostingEnvironment;

        //public UploadController(IHostingEnvironment hostingEnvironment)
        //{
        //    _hostingEnvironment = hostingEnvironment;
        //}

        //[HttpPost, DisableRequestSizeLimit]
        //public ActionResult UploadFile()
        //{
        //    try
        //    {
        //        var file = Request.Form.Files[0];
        //        string folderName = "Upload";
        //        string webRootPath = _hostingEnvironment.WebRootPath;
        //        string newPath = Path.Combine(webRootPath, folderName);
        //        if (!Directory.Exists(newPath))
        //        {
        //            Directory.CreateDirectory(newPath);
        //        }
        //        if (file.Length > 0)
        //        {
        //            string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        //            string fullPath = Path.Combine(newPath, fileName);
        //            using (var stream = new FileStream(fullPath, FileMode.Create))
        //            {
        //                file.CopyTo(stream);
        //            }
        //        }
        //        return Json("Upload Successful.");
        //    }
        //    catch (System.Exception ex)
        //    {
        //        return Json("Upload Failed: " + ex.Message);
        //    }
        //}

    }
}