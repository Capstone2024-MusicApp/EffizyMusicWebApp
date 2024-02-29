using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using MusicWebApi.Data;
using MusicWebApi.Models;

namespace MusicWebApi.Services
{
    public class QuestionsManager
    {
        readonly EffizyMusicDataContext _dbContext;
        public QuestionsManager(EffizyMusicDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Get all Question
        /// </summary>
        /// <returns></returns>
        public List<Question> GetAllQuestions()
        {
            try
            {
                return _dbContext.Questions.ToList();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Get quiz Question
        /// </summary>
        /// <returns></returns>
        public List<Question> GetQuizQuestions(int quizId)
        {
            try
            {
                return _dbContext.Questions.Include(q => q.Quiz).Where(q => q.QuizId == quizId).ToList();
            }
            catch
            {
                throw;
            }
        }

        public Question GetQuestion(int id)
        {
            try
            {
                return _dbContext.Questions.Include(m => m.Quiz).Where(m => m.Id == id).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public QuestionChoiceViewModel GetQuestionWithChoices(int id)
        {
            try
            {
                QuestionChoiceViewModel model = new QuestionChoiceViewModel();
                var question = _dbContext.Questions.Include(m => m.Quiz).Where(m => m.Id == id).FirstOrDefault();

                if (question != null)
                {
                    model.QuestionText = question.QuestionText;
                    model.QuestionId = question.Id;
                    model.QuizId = question.QuizId;
                }

                List<QuestionChoice> questionChoices = _dbContext.QuestionChoices.Where(x => x.QuestionId == id).ToList();
                for (int count = 0; count < questionChoices.Count; count++)
                {
                    if(count == 0)
                    {
                        model.ChoiceText1 = questionChoices[count].ChoiceText;
                    }
                    if (count == 1)
                    {
                        model.ChoiceText2 = questionChoices[count].ChoiceText;
                    }
                    if (count == 2)
                    {
                        model.ChoiceText3 = questionChoices[count].ChoiceText;
                    }
                    if (count == 3)
                    {
                        model.ChoiceText4 = questionChoices[count].ChoiceText;
                    }
                }
                //delete answers
                List<Answer> answers = _dbContext.Answers.Where(x => x.QuestionId == id).ToList();
                if(answers.Count > 0)
                {
                   model.CorrectChoice = answers[0].AnswerText;
                }

                return model;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Get question choices.
        /// </summary>
        /// <param name="id">Question Id</param>
        /// <returns></returns>
        public List<QuestionChoice> GetQuestionChoices(int id)
        {
            try
            {
                return _dbContext.QuestionChoices.Where(m => m.QuestionId == id).ToList();
            }
            catch
            {
                throw;
            }
        }

        public void AddQuestion(Question entity)
        {
            try
            {
                _dbContext.Questions.Add(entity);
                _dbContext.SaveChanges();
                //return entity;
            }
            catch
            {
                throw;
            }
        }

        public void AddQuestionWithChoices(QuestionChoiceViewModel entity)
        {
            try
            {
                //add question
                Question question = new Question();
                question.QuestionText = entity.QuestionText;
                question.QuizId = entity.QuizId;
                _dbContext.Questions.Add(question);
                _dbContext.SaveChanges();

                int questionId = question.Id;
                //Add choice 1
                if (!string.IsNullOrEmpty(entity.ChoiceText1))
                {
                    QuestionChoice questionChoice = new QuestionChoice();
                    questionChoice.ChoiceText = entity.ChoiceText1;
                    questionChoice.QuestionId = questionId;
                    _dbContext.QuestionChoices.Add(questionChoice);
                    _dbContext.SaveChanges();
                }
                //Add choice 2
                if (!string.IsNullOrEmpty(entity.ChoiceText2))
                {
                    QuestionChoice questionChoice = new QuestionChoice();
                    questionChoice.ChoiceText = entity.ChoiceText2;
                    questionChoice.QuestionId = questionId;
                    _dbContext.QuestionChoices.Add(questionChoice);
                    _dbContext.SaveChanges();
                }
                //Add choice 3
                if (!string.IsNullOrEmpty(entity.ChoiceText3))
                {
                    QuestionChoice questionChoice = new QuestionChoice();
                    questionChoice.ChoiceText = entity.ChoiceText3;
                    questionChoice.QuestionId = questionId;
                    _dbContext.QuestionChoices.Add(questionChoice);
                    _dbContext.SaveChanges();
                }
                //Add choice 4
                if (!string.IsNullOrEmpty(entity.ChoiceText4))
                {
                    QuestionChoice questionChoice = new QuestionChoice();
                    questionChoice.ChoiceText = entity.ChoiceText4;
                    questionChoice.QuestionId = questionId;
                    _dbContext.QuestionChoices.Add(questionChoice);
                    _dbContext.SaveChanges();
                }

                if (!string.IsNullOrEmpty(entity.CorrectChoice))
                {
                    //Add answer.
                    Answer answer = new Answer();
                    answer.AnswerText = entity.CorrectChoice;
                    answer.QuestionId = questionId;
                    _dbContext.Answers.Add(answer);
                    _dbContext.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar question
        public void UpdateQuestion(QuestionChoiceViewModel entity)
        {
            try
            {
                DeleteQuestion(entity.QuestionId);
                AddQuestionWithChoices(entity);
                //_dbContext.Entry(entity).State = EntityState.Modified;
                //_dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public bool DeleteQuestion(int id)
        {
            try
            {
                Question? entity = _dbContext.Questions.Find(id);
                if (entity != null)
                {
                    //delete questionChoices
                    List<QuestionChoice> questionChoices = _dbContext.QuestionChoices.Where(x => x.QuestionId == id).ToList();
                    foreach(var choice in questionChoices)
                    {
                        _dbContext.QuestionChoices.Remove(choice);
                        _dbContext.SaveChanges();
                    }
                    //delete answers
                    List<Answer> answers = _dbContext.Answers.Where(x => x.QuestionId == id).ToList();
                    foreach (var answer in answers)
                    {
                        _dbContext.Answers.Remove(answer);
                        _dbContext.SaveChanges();
                    }
                    //Delete question
                    _dbContext.Questions.Remove(entity);
                    _dbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}