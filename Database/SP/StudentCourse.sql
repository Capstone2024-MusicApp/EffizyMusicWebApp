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
			  ,ProgressStatus 
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