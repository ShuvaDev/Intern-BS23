using Core.Contracts.Factories;
using Core.Contracts.Products;
using Infrastructure.Products;

namespace Infrastructure.Factories
{
    public class LightThemeFactory : IThemeFactory
    {
        public string ThemeName => "Light";
        public IButton CreateButton() => new LightButton();
        public ICheckbox CreateCheckbox() => new LightCheckbox();
    }
}
