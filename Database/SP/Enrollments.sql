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
