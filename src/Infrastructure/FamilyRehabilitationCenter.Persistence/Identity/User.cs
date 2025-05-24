using FamilyRehabilitationCenter.Persistence.Entities;
using Microsoft.AspNetCore.Identity;

namespace FamilyRehabilitationCenter.Persistence.Identity
{
    public class User : IdentityUser<int>
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
