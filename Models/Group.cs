namespace SimonsVoss_Search.Models
{
    public class Group : BaseEntity
    {
        public override string Id { get; set; }
        public override string Name { get; set; }
        public override string EntityType { get; } = "Group";
        public string Description { get; set; }
    }
}
