using Core.Contracts.Products;

namespace Infrastructure.Products
{
    public class DarkCheckbox : ICheckbox
    {
        public string CssClass => "form-check dark-check";
        public string Label => "Dark Checkbox";
    }
}
