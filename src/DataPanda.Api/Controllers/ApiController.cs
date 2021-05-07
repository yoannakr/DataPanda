using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DataPanda.Api.Controllers
{
    [EnableCors("MyPolicy")]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ApiController : ControllerBase
    {
    }
}
