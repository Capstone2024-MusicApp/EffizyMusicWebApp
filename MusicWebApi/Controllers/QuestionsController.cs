using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicWebApi.Models;
using MusicWebApi.Services;

namespace MusicWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        QuestionsManager manager;
        public QuestionsController(QuestionsManager _manager)
        {
            manager = _manager;
        }

        [HttpGet]
        [Route("GetQuizQuestions/{id}")]//Here id is quizId
        public async Task<List<Question>> GetQuizQuestions(int id)
        {
            return await Task.FromResult(manager.GetQuizQuestions(id));
        }

        [HttpGet]
        [Route("GetAllQuestions")]
        public async Task<List<Question>> GetAllQuestions()
        {
            return await Task.FromResult(manager.GetAllQuestions());
        }

        [HttpGet]
        [Route("GetQuestion/{id}")]
        public async Task<Question> GetQuestion(int id)
        {
            return await Task.FromResult(manager.GetQuestion(id));
        }

        [HttpGet]
        [Route("GetQuestionChoices/{id}")]
        public async Task<List<QuestionChoice>> GetQuestionChoices(int id)
        {
            return await Task.FromResult(manager.GetQuestionChoices(id));
        }

        [HttpGet]
        [Route("GetQuestionWithChoices/{id}")]
        public async Task<QuestionChoiceViewModel> GetQuestionWithChoices(int id)
        {
            return await Task.FromResult(manager.GetQuestionWithChoices(id));
        }

        [HttpPost]
        public void Post(Question entity)
        {
           manager.AddQuestion(entity);
        }

        [HttpPost]
        [Route("PostQuestion")]
        public void PostQuestion(QuestionChoiceViewModel entity)
        {
            manager.AddQuestionWithChoices(entity);
        }

        [HttpPut]
        public void Put(QuestionChoiceViewModel entity)
        {
            manager.UpdateQuestion(entity);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            manager.DeleteQuestion(id);
            return Ok();
        }
    }
}