﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Dal;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        readonly IDal db = new Edal();

        public UploadController(IHostingEnvironment env)
        {
            _hostingEnvironment = env;
        }


        [HttpPost("{id}"), DisableRequestSizeLimit]
        public IActionResult Upload(string id)
        {
            try
            {
                var file = Request.Form.Files[0];

                var temp_folder = Path.Combine("Resources", "People", id);              

               

                string webRootPath = _hostingEnvironment.WebRootPath;
                string contentRootPath = _hostingEnvironment.ContentRootPath;

                Debug.WriteLine(webRootPath);
                Debug.WriteLine(contentRootPath);


                var pathToCreate = Path.Combine(contentRootPath, temp_folder);

                if (!Directory.Exists(pathToCreate))
                {
                    Directory.CreateDirectory(pathToCreate);
                }

                //if (!Directory.Exists(folder))
                //{
                //    Directory.CreateDirectory(folder);
                //}

                //var pathEachPerson = Path.Combine(pathToCreate, id);

                //if (!Directory.Exists(pathEachPerson))
                //{
                //    Directory.CreateDirectory(pathEachPerson);
                //}

                //var folderName = Path.Combine("Resources", "Images");
                //var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                var pathToSave = pathToCreate;

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);

                    db.PersonLoadPhoto(id, fullPath);
                    // var dbPath = Path.Combine(folderName, fileName);
                    var dbPath = Path.Combine(temp_folder, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}