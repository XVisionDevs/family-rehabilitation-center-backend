using FamilyRehabilitationCenter.Doman.Entities.Base;

namespace FamilyRehabilitationCenter.Persistence.Entities
{
    public class Person : EntityBase
    {
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}
