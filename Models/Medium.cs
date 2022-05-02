namespace SimonsVoss_Search.Models
{
    public class Medium : BaseEntity
    {
        public override string Id { get; set; }

        public override string Name { get; set; }
        public string GroupId { get; set; }
        public override string EntityType { get; } = "Medium";
        public string Type { get; set; }
        public string Owner { get; set; }
        public string Description { get; set; }
        public string SerialNumber { get; set; }
    }
}
