namespace SimonsVoss_Search.Models
{
    public class Lock : BaseEntity
    {
        public override string Id { get; set; }
        public override string Name { get; set; }
        public override string EntityType { get; } = "Lock";
        public string BuildingId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string SerialNumber { get; set; }
        public string Floor { get; set; }
        public string RoomNumber { get; set; }
    }
}
