using Microsoft.AspNetCore.Mvc;
using MusicWebApi.Models;
using MusicWebApi.Services;

namespace MusicWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuizController : Controller
    {
        QuizManager quizManager;
        public QuizController(QuizManager _quizManager)
        {
            quizManager = _quizManager;
        }

        [HttpGet]
        [Route("GetQuiz/{id}")]//Here id is module id and it fetches all quizes of the modules
        public async Task<List<Quiz>> Get(int id)
        {
            return await Task.FromResult(quizManager.GetQuizes(id));
        }

        [HttpGet]
        [Route("GetQuizById/{id}")]//Here id is quiz id and it fetches quiz entity.
        public async Task<Quiz> GetQuizById(int id)
        {
            return await Task.FromResult(quizManager.GetQuiz(id));
        }

        [HttpPost]
        public void Post(Quiz quiz)
        {
            quizManager.AddQuiz(quiz);
        }

        [HttpPut]
        public void Put(Quiz quiz)
        {
            quizManager.UpdateQuiz(quiz);
        }

        [HttpPost]
        [Route("UpdateQuiz")]
        public void UpdateQuiz(Quiz quiz)
        {
            quizManager.UpdateQuiz(quiz);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            quizManager.DeleteQuiz(id);
            return Ok();
        }
    }
}
