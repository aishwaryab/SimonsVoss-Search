namespace SimonsVoss_Search.Models
{
    public abstract class BaseEntity
    {
        public abstract string Id { get; set; }
        public abstract string Name { get; set; }
        public abstract string EntityType { get; }
    }
}
