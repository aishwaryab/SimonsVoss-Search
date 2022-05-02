namespace SimonsVoss_Search.Models
{
    public class Building : BaseEntity
    {
        readonly int ShortCutWeight = 7;
        readonly int ShortCutTransistionWeight = 5;
        readonly int NameWeight = 9;
        readonly int NameTransistionWeight = 8;
        readonly int DescriptionWeight = 5;
        readonly int DescriptionTransitionWeight = 0;

        public override string Id { get; set; }
        public override string Name { get; set; }
        public override string EntityType { get; } = "Building";
        public string ShortCut { get; set; }
        public string Description { get; set; }
    }
}
