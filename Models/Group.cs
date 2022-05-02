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

        public override int FindSearchTermWeight(string searchTerm, bool isTransition = false)
        {
            int nameWeightForCalculation = isTransition ? NameTransistionWeight : NameWeight;
            int descriptionWeightForCalculation = isTransition ? DescriptionTransitionWeight : DescriptionWeight;

            int nameWeight = GetWeightByTermForProperty(searchTerm, Name, nameWeightForCalculation);
            int descriptionWeight = GetWeightByTermForProperty(searchTerm, Description, descriptionWeightForCalculation);

            return nameWeight + descriptionWeight;
        }
    }
}
