CREATE OR ALTER PROCEDURE sp_getFeedbackView
AS
	DECLARE @ProcedureName VARCHAR(30) = 'sp_getFeedback';

	BEGIN
		select top 100 f.feedbackid, 
			   f.comments, 
			   f.feedbackdate, 
			   f.UserID,
			   (case when usertypeid = 1 then '' when usertypeid =  2 then i.lastname else s.lastname end) lastname,
			   (case when usertypeid = 1 then 'admin' when usertypeid =  2 then i.firstname else s.firstname end) firstname
		from feedbacks f 
		inner join users u on f.userid = u.userid
		left join students s on u.userid = s.userid
		left join instructors i on u.userid = i.userid
		order by f.feedbackdate desc;


		IF @@ERROR <> 0 
		BEGIN
			RAISERROR('sp_getFeedback - Error getting feedback information.',16,1)
		END
	END
GO
