using Core.Entities;

namespace Entities.Concretes
{
    public class Employee : IEntity
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
    }
}
