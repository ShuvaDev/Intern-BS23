using Core.Contracts.Products;

namespace Infrastructure.Products
{
    public class DarkButton : IButton
    {
        public string CssClass => "btn btn-dark";
        public string Label => "Dark Button";
    }
}
