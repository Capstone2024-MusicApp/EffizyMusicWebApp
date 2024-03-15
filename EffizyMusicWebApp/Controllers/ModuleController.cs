using EffizyMusicSystem.Models;
using EffizyMusicSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EffizyMusicWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly ModuleManager moduleManager;

        public ModuleController(ModuleManager _moduleManager)
        {
            moduleManager = _moduleManager;
        }

        [Route("GetModule")]
        [HttpGet]
        public async Task<List<Module>> Get()
        {
            return await Task.FromResult(moduleManager.GetModules());
        }
    }
}
