using Microsoft.AspNetCore.Identity;

namespace VariantOne.Entities
{
    public class User
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public Role Role { get; set; }
    }
}
