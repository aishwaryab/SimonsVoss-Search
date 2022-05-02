namespace SimonsVoss_Search.Models
{
    public class Lock : BaseEntity
    {
        readonly int TypeWeight = 3;
        readonly int NameWeight = 10;
        readonly int DescriptionWeight = 6;
        readonly int SerialNumberWeight = 8;
        readonly int FloorWeight = 6;
        readonly int RoomNumberWeight = 6;

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
