using Core.Contracts.Products;

namespace Infrastructure.Products
{
    public class LightButton : IButton
    {
        public string CssClass => "btn btn-light border";
        public string Label => "Light Button";
    }
}
