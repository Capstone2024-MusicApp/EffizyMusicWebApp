using Microsoft.AspNetCore.Mvc;
using MusicWebApi.Models;
using MusicWebApi.Services;

namespace MusicWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModulesController : Controller
    {
        ModuleManager moduleManager;
        public ModulesController(ModuleManager _moduleManager)
        {
            moduleManager = _moduleManager;
        }

        [HttpGet]
        //[Route("GetModule")]
        public async Task<List<Module>> Get()
        {
            return await Task.FromResult(moduleManager.GetModules());
        }
    }
}
