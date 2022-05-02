namespace SimonsVoss_Search.Models
{
    public class Building : BaseEntity
    {
        public override string Id { get; set; }
        public override string Name { get; set; }
        public override string EntityType { get; } = "Building";
        public string ShortCut { get; set; }
        public string Description { get; set; }
    }
}
