using Microsoft.AspNetCore.Identity;

namespace VariantTwo.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public byte[]? Salt { get; set; }
        public Role Role { get; set; }

        public List<Car>? Cars { get; set; }
    }
}
