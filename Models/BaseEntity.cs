namespace SimonsVoss_Search.Models
{
    public abstract class BaseEntity
    {
        public abstract string Id { get; set; }
        public abstract string Name { get; set; }
        public abstract string EntityType { get; }

        public abstract int FindSearchTermWeight(string searchTerm, bool isTransistion = false);


        public static int GetWeightByTermForProperty(string searchTerm, string property, int propertyWeight)
        {
            if (string.IsNullOrEmpty(property) || property.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) == -1)
            {
                return 0;
            }
            int resultWeight = property.Length == searchTerm.Length ? 10 : 1;
            return resultWeight * propertyWeight;
        }
    }
}
