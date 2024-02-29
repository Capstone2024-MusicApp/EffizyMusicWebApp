using Microsoft.EntityFrameworkCore;
using MusicWebApi.Data;
using MusicWebApi.Models;

namespace MusicWebApi.Services
{
    public class QuizManager
    {
        readonly EffizyMusicDataContext _dbContext;
        public QuizManager(EffizyMusicDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Get all quizes
        /// </summary>
        /// <returns></returns>
        public List<Quiz> GetQuizes()
        {
            try
            {
                return _dbContext.Quizes.ToList();
            }
            catch
            {
                throw;
            }
        }

        public List<Quiz> GetQuizes(int moduleId)
        {
            try
            {
                var quizes = _dbContext.Quizes.Include(m => m.Module).Where(m => m.ModuleId == moduleId).ToList();
                return quizes;
            }
            catch
            {
                throw;
            }
        }

        public void AddQuiz(Quiz quiz)
        {
            try
            {
                _dbContext.Quizes.Add(quiz);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        //To Update the records of a particluar Quiz
        public void UpdateQuiz(Quiz quiz)
        {
            try
            {
                _dbContext.Entry(quiz).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public Quiz? GetQuiz(int id)
        {
            try
            {
                Quiz? quiz = _dbContext.Quizes.Find(id);
                if (quiz != null)
                {
                    return quiz;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                throw;
            }
        }

        public bool DeleteQuiz(int id)
        {
            try
            {
                Quiz? quiz = _dbContext.Quizes.Find(id);
                if (quiz != null)
                {
                    _dbContext.Quizes.Remove(quiz);
                    _dbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                    //throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
