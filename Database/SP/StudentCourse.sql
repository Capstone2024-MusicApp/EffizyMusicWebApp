CREATE OR ALTER PROCEDURE sp_getEnrolledCourses
	@in_userId INT
AS
	DECLARE @ProcedureName VARCHAR(30) = 'sp_getEnrolledCourses';

	BEGIN
		select e.EnrollmentID
			  ,c.CourseID, Title
			  ,CourseDescription
			  ,CourseCode
			  ,e.StudentID
			  ,e.UserID
			  ,ProgressStatus 
			  ,e.EnrollmentDate
			  ,e.EnrollmentEndDate
			  ,(select count(*) from LessonsProgress lp
				where lp.EnrollmentId = e.EnrollmentID
				and ProgressStatus = 'COMPLETE') +
				(select count(*) from QuizesProgress qp
				where qp.EnrollmentId = e.EnrollmentID
				and qp.Grade >= 80) CompletedLessons
			  ,((select count(*) from Modules m
			    inner join Lessons l on m.ModuleID = l.ModuleID
				and m.CourseID = c.CourseID) +
				(select count(*) from Modules m
				inner join Quizes q on m.ModuleID = q.ModuleID
				and m.CourseID = c.CourseID)) TotalLessons
		from enrollments  e
		inner join courses c on e.CourseID = c.CourseID
		inner join students s on e.StudentID = s.StudentID
		where s.UserID = @in_userId;


		IF @@ERROR <> 0 
		BEGIN
			RAISERROR('sp_getEnrolledCourses - Error getting enrolled courses.',16,1)
		END
	END
GO

CREATE OR ALTER PROCEDURE sp_getStudentCourse
	@in_enrollmentID INT
AS
	DECLARE @ProcedureName VARCHAR(30) = 'sp_getStudentCourse';

	BEGIN
		select e.EnrollmentID
			  ,c.CourseID
			  , Title 
			  , CourseDescription
			  , CourseCode
			  , StudentID
			  ,UserID
			  , ProgressStatus 
			  ,e.EnrollmentDate
			  ,e.EnrollmentEndDate
			  ,(select count(*) from LessonsProgress lp
				where lp.EnrollmentId = e.EnrollmentID
				and ProgressStatus = 'COMPLETE') +
				(select count(*) from QuizesProgress qp
				where qp.EnrollmentId = e.EnrollmentID
				and qp.Grade >= 80)  CompletedLessons
			  ,(select count(*) from Modules m
				inner join Lessons l on m.ModuleID = l.ModuleID
				and m.CourseID = c.CourseID) +
				(select count(*) from Modules m
				inner join Quizes q on m.ModuleID = q.ModuleID
				and m.CourseID = c.CourseID
				and current_timestamp >= e.EnrollmentDate and current_timestamp <= e.EnrollmentEndDate) TotalLessons
		from courses c 
		inner join enrollments e on c.CourseId = e.CourseID 
		where EnrollmentID = @in_enrollmentID;


		IF @@ERROR <> 0 
		BEGIN
			RAISERROR('sp_getStudentCourse - Error getting student course.',16,1)
		END
	END
GO

CREATE OR ALTER PROCEDURE sp_getQuestionnaire
	@in_quizId INT
AS
	DECLARE @ProcedureName VARCHAR(30) = 'sp_getQuestionnaire';

	BEGIN
		select qz.id QuizId
			  ,qs.id QuestionID
			  ,qs.QuestionText
		from quizes qz
		inner join questions qs on qz.id = qs.QuizId
		where qz.Id = @in_quizId;


		IF @@ERROR <> 0 
		BEGIN
			RAISERROR('sp_getQuestionnaire - Error getting questionnaire.',16,1)
		END
	END
GO

CREATE OR ALTER PROCEDURE sp_getMissingLessonProgress
	@in_enrollmentID INT
AS
	DECLARE @ProcedureName VARCHAR(30) = 'sp_getMissingLessonProgress';

	BEGIN
		select 0 LessonProgressID
			  ,@in_enrollmentID EnrollmentID
			  ,l.LessonNumber LessonID
			  ,'NOT STARTED' ProgressStatus
		from Lessons l
		inner join Modules m on l.ModuleID = m.ModuleID
		inner join Courses c on m.CourseID = c.CourseID
		inner join Enrollments e on e.CourseID = c.CourseID
		where not exists(select 'x' from LessonsProgress lp where lp.EnrollmentID = @in_enrollmentID and lp.LessonID = l.LessonNumber)
		and e.EnrollmentID = @in_enrollmentID
		order by m.ModuleOrder, l.LessonOrder;


		IF @@ERROR <> 0 
		BEGIN
			RAISERROR('sp_getMissingLessonProgress - Error getting missing lesson progress.',16,1)
		END
	END
GO

CREATE OR ALTER PROCEDURE sp_getCourseDetials
	@in_courseID INT,
	@in_userID INT
AS
	DECLARE @ProcedureName VARCHAR(30) = 'sp_getCourseDetials';

	BEGIN
		select c.CourseId
			  ,c.Title
			  ,c.CourseDescription
			  ,c.SkillLevel
			  ,c.EstimatedTime
			  ,im.InstrumentType Instrument
			  ,id.FirstName + ' ' + id.LastName Instructor
			  ,coalesce(ROUND((select sum(rating) from InstructorRatings ir
			    where ir.InstructorID = id.InstructorID) / 
			  (select count(*) from InstructorRatings ir
			    where ir.InstructorID = id.InstructorID), 0), 0) InstructorRating
			 ,(select count(*) from Courses c2
			   inner join Enrollments e on e.CourseID = c2.CourseID
			   where c2.CourseCode = c.CourseCode
			   and c2.CourseID <> c.CourseID
			   and e.UserID = @in_userID
			   ) enrolledSameCourseCode
		from courses c
		inner join instruments im on c.InstrumentID = im.InstrumentID
		inner join instructors id on c.InstructorID = id.instructorId
		where courseID = @in_courseID;



		IF @@ERROR <> 0 
		BEGIN
			RAISERROR('sp_getCourseDetials - Error getting missing course details.',16,1)
		END
	END
GO

EXECUTE sp_getCourseDetials 3, 0