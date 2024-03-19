namespace VariantOne.Entities
{
    public class Tea
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public TeaType TeaType { get; set; }
        public string? Country { get; set; }
    }
}
