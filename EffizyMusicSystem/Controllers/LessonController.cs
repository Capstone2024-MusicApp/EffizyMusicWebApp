using EffizyMusicSystem.Models;
using EffizyMusicSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Controllers
{
    public class LessonController
    {
        private IEffizyMusicApplicationService _effizyApplicationService;

        private LessonController(IEffizyMusicApplicationService effizyMusicApplicationService)
        {
            _effizyApplicationService = effizyMusicApplicationService;
        }
        public List<Lesson> GetLessons()
        {
            return _effizyApplicationService.GetLessons();
        }
    }
}
