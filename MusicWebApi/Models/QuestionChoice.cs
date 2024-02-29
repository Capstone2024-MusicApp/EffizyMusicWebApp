namespace MusicWebApi.Models
{
    public class QuestionChoice
    {
        public int Id { get; set; }

        public string ChoiceText { get; set; } = string.Empty;

        public int QuestionId { get; set; }

        public virtual Question? Question { get; set; } = null!;
    }
}
