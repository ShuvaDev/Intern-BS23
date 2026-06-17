using Core.Contracts.Factories;
using Core.Contracts.Products;
using Infrastructure.Products;

namespace Infrastructure.Factories
{
    public class DarkThemeFactory : IThemeFactory
    {
        public string ThemeName => "Dark";
        public IButton CreateButton() => new DarkButton();
        public ICheckbox CreateCheckbox() => new DarkCheckbox();
    }
}
