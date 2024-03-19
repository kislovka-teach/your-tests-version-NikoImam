namespace VariantOne.Abstractions
{
    public interface IHasherService
    {
        public byte[] GetSalt();
        public string GetHashPassword(string? password, byte[]? salt);
    }
}
