namespace MusicWebApi.Models
{
    public class Answer
    {
        public int Id { get; set; }

        public string AnswerText { get; set; } = string.Empty;

        public int QuestionId { get; set; }

        public virtual Question? Question { get; set; } = null!;
    }
}