using Core.Contracts.Products;

namespace Infrastructure.Products
{
    public class LightCheckbox : ICheckbox
    {
        public string CssClass => "form-check light-check";
        public string Label => "Light Checkbox";
    }
}
