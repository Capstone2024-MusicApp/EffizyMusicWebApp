CREATE OR ALTER PROCEDURE sp_getFeedbackView
AS
	DECLARE @ProcedureName VARCHAR(30) = 'sp_getFeedback';

	BEGIN
		select f.feedbackid, 
			   f.comments, 
			   f.feedbackdate, 
			   f.UserID,
			   (case when usertypeid =  2 then i.lastname else s.lastname end) lastname,
			   (case when usertypeid =  2 then i.firstname else s.firstname end) firstname
		from feedbacks f 
		inner join users u on f.userid = u.userid
		left join students s on u.userid = s.studentid
		left join instructors i on u.userid = i.instructorid;


		IF @@ERROR <> 0 
		BEGIN
			RAISERROR('sp_getFeedback - Error getting feedback information.',16,1)
		END
	END
GO
