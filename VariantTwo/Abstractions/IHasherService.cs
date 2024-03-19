namespace VariantTwo.Abstractions
{
    public interface IHasherService
    {
        public byte[] GetSalt();
        public string GetHashPassword(string? password, byte[]? salt);
    }
}
