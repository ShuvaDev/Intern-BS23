using Core.Contracts.Products;

namespace Core.Contracts.Factories
{
    public interface IThemeFactory
    {
        IButton CreateButton();
        ICheckbox CreateCheckbox();
        string ThemeName { get; }
    }
}
