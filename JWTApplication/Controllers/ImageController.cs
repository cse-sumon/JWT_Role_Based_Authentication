using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JWTApplication.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace JWTApplication.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly AuthenticationContext _context;
        private readonly IHostingEnvironment _appEnvironment;
        public ImageController(AuthenticationContext context, IHostingEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        [HttpPost]
        [Route("upload")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostImage(Image employee)
        {
       
                var files = HttpContext.Request.Form.Files;
                foreach (var Image in files)
                {
                    if (Image != null && Image.Length > 0)
                    {
                        var file = Image;

                        var uploads = Path.Combine(_appEnvironment.WebRootPath, "uploads\\img");
                        if (file.Length > 0)
                        {
                            var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                            using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                                employee.ImageName = fileName;
                                employee.ImageCaption = employee.ImageCaption;
                        }

                        }
                    }
                }
                _context.Images.Add(employee);
                _context.SaveChanges();
                return Ok();
            
          

        }
        [HttpGet]
        [Route("test")]

        public IActionResult Test()
        {
            return Content("hello");
        }
    }
}