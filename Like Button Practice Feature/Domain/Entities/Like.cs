namespace Norebase_Like_Feature_Challenge.Domain.Entities
{
    public class Like
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ArticleId { get; set; }
        public DateTime LikedAt { get; set; }
    }
}
