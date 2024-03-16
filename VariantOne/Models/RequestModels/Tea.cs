using VariantOne.Entities;

namespace VariantOne.Models.RequestModels
{
    public class Tea
    {
        public string? Name { get; set; }
        public TeaType TeaType { get; set; }
        public string? Country { get; set; }
    }
}
