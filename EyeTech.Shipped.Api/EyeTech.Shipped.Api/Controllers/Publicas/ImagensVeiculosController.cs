using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EyeTech.Shipped.Api.Controllers.Publicas
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagensVeiculosController : ControllerBase
    {
        [HttpGet("{imagem}")]
        public IActionResult Get(string imagem)
        {
            var filePath = Path.Combine(
                Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "uploads" +
                Path.DirectorySeparatorChar + "veiculos", imagem);
            if (System.IO.File.Exists(filePath))
            {
                return PhysicalFile(filePath, "image/jpg");
            }
            return null;
        }
    }
}