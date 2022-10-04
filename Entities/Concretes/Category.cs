using Core.Entities;

namespace Entities.Concretes
{
    public class Category : IEntity
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public Category() { }

        public Category(int categoryId, string categoryName, string description)
        {
            CategoryID = categoryId;
            CategoryName = categoryName;
            Description = description;
        }
    }
}
