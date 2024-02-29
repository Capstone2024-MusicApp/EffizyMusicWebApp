using MusicWebApi.Data;
using MusicWebApi.Models;

namespace MusicWebApi.Services
{
    public class ModuleManager
    {
        readonly EffizyMusicDataContext _dbContext;
        public ModuleManager(EffizyMusicDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Get all modules
        /// </summary>
        /// <returns></returns>
        public List<Module> GetModules()
        {
            try
            {
                return _dbContext.Modules.ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}
