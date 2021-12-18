using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace RtaAssignment.API.Controllers.V1
{
    public class FallbackController : Controller
    {
        public IActionResult Index()
        {
            return PhysicalFile(
                Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "index.html"),
                "text/HTML");
        }
    }
}