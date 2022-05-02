namespace SimonsVoss_Search.Models
{
    public class Group : BaseEntity
    {
        readonly int NameWeight = 9;
        readonly int NameTransistionWeight = 8;
        readonly int DescriptionWeight = 5;
        readonly int DescriptionTransitionWeight = 0;

        public override string Id { get; set; }
        public override string Name { get; set; }
        public override string EntityType { get; } = "Group";
        public string Description { get; set; }
    }
}
