namespace Norebase_Like_Feature_Challenge.Domain.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int LikeCount {  get; set; }
        public DateTime DateCreated { get; set; } 
    }
}
