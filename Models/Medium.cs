namespace SimonsVoss_Search.Models
{
    public class Medium : BaseEntity
    {
        readonly int TypeWeight = 3;
        readonly int OwnerWeight = 10;
        readonly int DescriptionWeight = 6;
        readonly int SerialNumberWeight = 8;

        public override string Id { get; set; }

        public override string Name { get; set; }
        public string GroupId { get; set; }
        public override string EntityType { get; } = "Medium";
        public string Type { get; set; }
        public string Owner { get; set; }
        public string Description { get; set; }
        public string SerialNumber { get; set; }

        public override int FindSearchTermWeight(string searchTerm, bool isTransition = false)
        {

            int typeWeight = GetWeightByTermForProperty(searchTerm, Type, TypeWeight);
            int descriptionWeight = GetWeightByTermForProperty(searchTerm, Description, DescriptionWeight);
            int serialNumberWeight = GetWeightByTermForProperty(searchTerm, SerialNumber, SerialNumberWeight);
            int ownerWeight = GetWeightByTermForProperty(searchTerm, Owner, OwnerWeight);

            return typeWeight + ownerWeight + descriptionWeight + serialNumberWeight;
        }
    }
}
