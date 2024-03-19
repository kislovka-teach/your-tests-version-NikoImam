using Microsoft.AspNetCore.Identity;

namespace VariantOne.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public byte[]? Salt { get; set; }
        public Role Role { get; set; }
    }
}
