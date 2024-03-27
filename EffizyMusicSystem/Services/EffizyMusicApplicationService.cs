using EffizyMusicSystem.DAL;
using EffizyMusicSystem.Models;
using EffizyMusicSystem.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Services
{
    public interface IEffizyMusicApplicationService
    {
        List<Lesson> GetLessons();
        List<Instructor> GetInstructors();

        Task<bool> AddRating(InstructorRating rating);
    }

    public class EffizyMusicApplicationService : IEffizyMusicApplicationService
    {
        private readonly EffizyMusicContext _context;

        public EffizyMusicApplicationService(EffizyMusicContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public  List<Lesson> GetLessons()
        {
            return _context.Lessons.ToList();
        }
        //public List<Instructor> GetInstructors()
        //{
        //    return _context.Instructors.ToList();
        //}
        public async Task<bool> AddRating(InstructorRating rating)
        {
            if(rating == null)
            {
                return false; //Can Add exception
            }
            _context.InstructorRatings.Add(rating);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Course>> GetCourses()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<List<UserType>> GetUserTypes()
        {
            return await _context.UserTypes.ToListAsync();
        }

        //public async Task<User> GetUserByIdAsync(int userTypeID)
        //{
        //    return await _context.Users
        //        .Include(x => x.UType)
        //        .FirstOrDefaultAsync(x => x.UserTypeID == userTypeID);
        //}

        //Add other methods here that directly connect to the database
        public List<Feedback> GetFeedback()
        {
            return _context.Feedbacks.ToList();
        }

        public async Task<bool> InsertFeedbackAsync(Feedback feedback)
        {
            await _context.Feedbacks.AddAsync(feedback);
            await _context.SaveChangesAsync();
            return true;
        }
        public void InsertFeedback(Feedback feedback)
        {
             _context.Feedbacks.AddAsync(feedback);
             _context.SaveChangesAsync();
        }



        //Add your methods here that directly connects to the dtabase

        public void AddCourse(Course entity)
        {
            try
            {
                _context.Courses.Add(entity);
            }
            catch
            {
                throw;
            }
        }
        #region Modules
        /// <summary>
        /// Get all modules
        /// </summary>
        /// <returns></returns>
        public async Task<List<Module>> GetModules()
        {
            try
            {
                return await _context.Modules.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region Quizes
        /// <summary>
        /// Get all quizes
        /// </summary>
        /// <returns></returns>
        public List<Quiz> GetQuizes()
        {
            try
            {
                return _context.Quizes.ToList();
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
                var quizes = _context.Quizes.Include(m => m.Module).Where(m => m.ModuleID == moduleId).ToList();
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
                _context.Quizes.Add(quiz);
                _context.SaveChanges();
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
                _context.Entry(quiz).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public List<Instrument> GetInstruments()
        {
            try
            {
                return _context.Instruments.ToList();
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
                Quiz? quiz = _context.Quizes.Find(id);
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


        public List<Instructor> GetInstructors()
        {
            try
            {
                return _context.Instructors.ToList();
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
                //get quiz questions
                var questions = _context.Questions.Where(q => q.QuizId == id).ToList();
                foreach(var question  in questions)
                {
                    DeleteQuestion(question.Id);
                }

                //delete quiz
                Quiz? quiz = _context.Quizes.Find(id);
                if (quiz != null)
                {
                    _context.Quizes.Remove(quiz);
                    _context.SaveChanges();
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
        #endregion

        #region Quiz Questions

        /// <summary>
        /// Get all Question
        /// </summary>
        /// <returns></returns>
        public List<Question> GetAllQuestions()
        {
            try
            {
                return _context.Questions.ToList();
            }
            catch
            {
                throw;
            }
        }

        public List<Payment> GetPayments()
        {
            try
            {
                return _context.Payments.ToList();
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
                return _context.Questions.Include(q => q.Quiz).Where(q => q.QuizId == quizId).ToList();
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
                return _context.Questions.Include(m => m.Quiz).Where(m => m.Id == id).FirstOrDefault();
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
                var question = _context.Questions.Include(m => m.Quiz).Where(m => m.Id == id).FirstOrDefault();

                if (question != null)
                {
                    model.QuestionText = question.QuestionText;
                    model.QuestionId = question.Id;
                    model.QuizId = question.QuizId;
                }

                List<QuestionChoice> questionChoices = _context.QuestionChoices.Where(x => x.QuestionId == id).ToList();
                for (int count = 0; count < questionChoices.Count; count++)
                {
                    if (count == 0)
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
                List<Answer> answers = _context.Answers.Where(x => x.QuestionId == id).ToList();
                if (answers.Count > 0)
                {
                    model.CorrectChoice = answers[0].AnswerText;
                    //model.Choices = answers[0].AnswerText;
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
                return _context.QuestionChoices.Where(m => m.QuestionId == id).ToList();
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
                _context.Questions.Add(entity);
                _context.SaveChanges();
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
                _context.Questions.Add(question);
                _context.SaveChanges();

                int questionId = question.Id;
                //Add choice 1
                if (!string.IsNullOrEmpty(entity.ChoiceText1))
                {
                    QuestionChoice questionChoice = new QuestionChoice();
                    questionChoice.ChoiceText = entity.ChoiceText1;
                    questionChoice.QuestionId = questionId;
                    _context.QuestionChoices.Add(questionChoice);
                    _context.SaveChanges();
                }
                //Add choice 2
                if (!string.IsNullOrEmpty(entity.ChoiceText2))
                {
                    QuestionChoice questionChoice = new QuestionChoice();
                    questionChoice.ChoiceText = entity.ChoiceText2;
                    questionChoice.QuestionId = questionId;
                    _context.QuestionChoices.Add(questionChoice);
                    _context.SaveChanges();
                }
                //Add choice 3
                if (!string.IsNullOrEmpty(entity.ChoiceText3))
                {
                    QuestionChoice questionChoice = new QuestionChoice();
                    questionChoice.ChoiceText = entity.ChoiceText3;
                    questionChoice.QuestionId = questionId;
                    _context.QuestionChoices.Add(questionChoice);
                    _context.SaveChanges();
                }
                //Add choice 4
                if (!string.IsNullOrEmpty(entity.ChoiceText4))
                {
                    QuestionChoice questionChoice = new QuestionChoice();
                    questionChoice.ChoiceText = entity.ChoiceText4;
                    questionChoice.QuestionId = questionId;
                    _context.QuestionChoices.Add(questionChoice);
                    _context.SaveChanges();
                }

                if (!string.IsNullOrEmpty(entity.Choices.ToString()))
                {
                    //Add answer.
                    Answer answer = new Answer();
                    //answer.AnswerText = entity.CorrectChoice;
                    answer.AnswerText = entity.Choices.ToString();
                    answer.QuestionId = questionId;
                    _context.Answers.Add(answer);
                    _context.SaveChanges();
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
                Question? entity = _context.Questions.Find(id);
                if (entity != null)
                {
                    //delete questionChoices
                    List<QuestionChoice> questionChoices = _context.QuestionChoices.Where(x => x.QuestionId == id).ToList();
                    foreach (var choice in questionChoices)
                    {
                        _context.QuestionChoices.Remove(choice);
                        _context.SaveChanges();
                    }
                    //delete answers
                    List<Answer> answers = _context.Answers.Where(x => x.QuestionId == id).ToList();
                    foreach (var answer in answers)
                    {
                        _context.Answers.Remove(answer);
                        _context.SaveChanges();
                    }
                    //Delete question
                    _context.Questions.Remove(entity);
                    _context.SaveChanges();
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

        #endregion

        #region Student Courses
        public async Task<List<StudentCourseDTO>> GetEnrolledCourses(int studentID)
        {
            return await _context.Database.SqlQuery<StudentCourseDTO>($"select e.EnrollmentID, c.CourseID, Title , CourseDescription, CourseCode, StudentID, ProgressStatus from courses c inner join enrollments e on c.CourseId = e.CourseID where StudentID = {studentID};").ToListAsync();
        }

        public StudentCourseDTO? GetStudentCourse(int enrollmentID)
        {
            StudentCourseDTO studentCourse;

            //var enrollment = var question = _context.Questions.Include(m => m.Quiz).Where(m => m.Id == id).FirstOrDefault();
            studentCourse = _context.Database.SqlQuery<StudentCourseDTO>($"select e.EnrollmentID, c.CourseID, Title , CourseDescription, CourseCode, StudentID, ProgressStatus from courses c inner join enrollments e on c.CourseId = e.CourseID where EnrollmentID = {enrollmentID}").SingleOrDefault();

            studentCourse.Modules = _context.Modules.Include(l=>l.Lessons).Include(q=>q.Quizzes).Where(m => m.Course.CourseID == studentCourse.CourseID).ToList();
            return studentCourse;
            // return _context.StudentCourseDTOs.FromSql($"select e.EnrollmentID, c.CourseID, Title , CourseDescription, CourseMode, StudentID, ProgressStatus from courses c inner join enrollments e on c.CourseId = e.CourseID where EnrollmentID = {enrollmentID};").SingleOrDefault();

        }
        #endregion

        #region feedbacks
        public List<FeedbackDTO> GetFeedbackDTOs()
        {
            return  _context.Database.SqlQuery<FeedbackDTO>($"EXECUTE sp_getFeedbackView").ToList();

        }
        #endregion
}
}
