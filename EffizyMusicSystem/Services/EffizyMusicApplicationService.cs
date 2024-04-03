﻿using EffizyMusicSystem.DAL;
using EffizyMusicSystem.Models;
using EffizyMusicSystem.Models.DTO;
using Microsoft.AspNetCore.Identity;
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
        Task<List<Lesson>> GetLessons();
        List<Instructor> GetInstructors();
        Task<bool> AddModules(Module module);
        Task<bool> AddLesson(Lesson lessonData);
        Task<bool> UpdateLesson(Lesson lessonData);
        Task<bool> DeleteLesson(int id);
        Task<Lesson> GetLessonById(int id);
        Task<bool> AddRating(InstructorRating rating);
        Task<List<Course>> GetCourses();
        List<Course> GetCourseList();

        Task<List<Module>> GetModules();
        Task<Module> GetModuleByID(int id);

        Task<Course> GetCourseByID(int id);
        Task DeleteCourse(int id);

        public List<Feedback> GetFeedback();
        public List<FeedbackDTO> GetFeedbackDTOs();
        public void InsertFeedback(Feedback feedback);
        public void DeleteFeedback(Feedback feedback);
    }

    public class EffizyMusicApplicationService : IEffizyMusicApplicationService
    {
        private readonly EffizyMusicContext _context;

        public EffizyMusicApplicationService(EffizyMusicContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        //public List<Instructor> GetInstructors()
        //{
        //    return _context.Instructors.ToList();
        //}
        public List<Course> GetCourseList()
        {
            return _context.Courses.ToList();
        }
        public async Task<bool> AddRating(InstructorRating rating)
        {
            if (rating == null)
            {
                return false; //Can Add exception
            }
            _context.InstructorRatings.Add(rating);
            await _context.SaveChangesAsync();
            return true;
        }

        #region Lesson
        public async Task<bool> AddLesson(Lesson lessonData)
        {
            try
            {
                if (lessonData == null)
                {
                    return false;
                }
                else
                {
                    _context.Lessons.Add(lessonData);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public async Task<bool> UpdateLesson(Lesson lessonData)
        {
            try
            {
                _context.Entry(lessonData).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { return false; }
        }
        public async Task<bool> DeleteLesson(int id)
        {
            var existingID = _context.Lessons.Find(id);
            if (existingID != null)
            {
                _context.Remove(existingID);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }

        }
        public async Task<List<Lesson>> GetLessons()
        {
            return await _context.Lessons.ToListAsync();
        }

        public async Task<Lesson> GetLessonById(int id)
        {
            return await _context.Lessons.Where(x => x.LessonNumber == id).FirstOrDefaultAsync();
        }
        #endregion


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

        public async Task<User> GetUserByIdAsync(int userTypeID)
        {
            return await _context.Users
                .Include(x => x.UserType)
                .FirstOrDefaultAsync(x => x.UserTypeID == userTypeID);
        }

        //Add other methods here that directly connect to the database
        
        #region Course
        public async Task<List<Course>> GetCourses()
        {

            var courses = await _context.Courses.ToListAsync();
            return courses != null ? courses : new List<Course>();


        }
        public async Task DeleteCourse(int id)
        {
            var modulesToDelete = _context.Modules.Where(x=>x.Course.CourseID == id).ToList();
            if(modulesToDelete != null)
            {
                foreach (var data in modulesToDelete)
                {
                    DeleteModule(data.ModuleID);
                }
            }
            
            var existingID = _context.Courses.Find(id);
            if (existingID != null)
            {
                _context.Remove(existingID);
                await _context.SaveChangesAsync();
            }
        }

        #endregion
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
        public async Task<Module> GetModuleByID(int id)
        {
            try
            {
                return await _context.Modules.Where(x => x.ModuleID == id).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }

        public Module GetModule(int id)
        {
            try
            {
                return _context.Modules.Where(m => m.ModuleID == id).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public bool DeleteModule(int id)
        {
            try
            {
                //Get all quizes of the module.
                var quizes = _context.Quizes.Where(x => x.ModuleID == id).ToList();
                foreach (var quiz in quizes)
                {
                    //get all questions of the quiz
                    var questions = _context.Questions.Where(q => q.QuizId == quiz.Id).ToList();
                    //delete all quations.
                    foreach (var entity in questions)
                    {
                        //delete questionChoices
                        List<QuestionChoice> questionChoices = _context.QuestionChoices.Where(x => x.QuestionId == entity.Id).ToList();
                        foreach (var choice in questionChoices)
                        {
                            _context.QuestionChoices.Remove(choice);
                            _context.SaveChanges();
                        }
                        //delete answers
                        List<Answer> answers = _context.Answers.Where(x => x.QuestionId == entity.Id).ToList();
                        foreach (var answer in answers)
                        {
                            _context.Answers.Remove(answer);
                            _context.SaveChanges();
                        }
                        //Delete question
                        _context.Questions.Remove(entity);
                        _context.SaveChanges();
                    }

                    //Delete quiz
                    _context.Quizes.Remove(quiz);
                    _context.SaveChanges();
                }

                //Delete lessons
                //Get all lessons of the module.
                var lessons = _context.Lessons.Where(x => x.Module.ModuleID == id).ToList();
                foreach (var lsn in lessons)
                {
                    _context.Lessons.Remove(lsn);
                    _context.SaveChanges();

                }

                //remove module.
                var module = _context.Modules.Where(m => m.ModuleID == id).FirstOrDefault();
                if (module != null)
                {
                    _context.Modules.Remove(module);
                    _context.SaveChanges();
                }

                return true;
            }
            catch
            {
                throw;
            }
        }
        public async Task<Course> GetCourseByID(int id)
        {
            return await _context.Courses.Where(x => x.CourseID == id).FirstOrDefaultAsync();
        }
        public async Task<bool> AddModules(Module module)
        {
            try
            {
                if (module != null)
                {
                    _context.Modules.Add(module);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error adding module.", ex);
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
                foreach (var question in questions)
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

            studentCourse.Modules = _context.Modules.Include(l => l.Lessons).Include(q => q.Quizzes).Where(m => m.Course.CourseID == studentCourse.CourseID).ToList();
            return studentCourse;
            // return _context.StudentCourseDTOs.FromSql($"select e.EnrollmentID, c.CourseID, Title , CourseDescription, CourseMode, StudentID, ProgressStatus from courses c inner join enrollments e on c.CourseId = e.CourseID where EnrollmentID = {enrollmentID};").SingleOrDefault();

        }
        #endregion

        #region Feedbacks
        public List<FeedbackDTO> GetFeedbackDTOs()
        {
            return   _context.Database.SqlQuery<FeedbackDTO>($"EXECUTE sp_getFeedbackView").ToList();

        }

        public List<Feedback> GetFeedback()
        {
            return _context.Feedbacks.ToList();
        }


        public void InsertFeedback(Feedback feedback)
        {
            _context.Feedbacks.Add(feedback);
            _context.SaveChanges();
        }

        public void DeleteFeedback(Feedback feedback)
        {
            _context.Remove(feedback);
            _context.SaveChanges();
        }
        #endregion
        //Login
        public User ValidateUser(string email, string password)
        {
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                string hashPassword = PasswordHasher.HashPassword(password);
                return _context.Users.Where(u => u.Email == email && u.Password == u.Password).FirstOrDefault();
            }
            else
                return null;
        }
    }
    #endregion
}
