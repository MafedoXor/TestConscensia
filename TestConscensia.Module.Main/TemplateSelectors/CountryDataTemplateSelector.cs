using System.Windows;
using System.Windows.Controls;
using TestConscensia.Models.ViewModels;

namespace TestConscensia.Module.Main.TemplateSelectors
{
    public class CountryDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate UaTemplate { get; set; }
        public DataTemplate DeTemplate { get; set; }
        public DataTemplate UsTemplate { get; set; }
        public DataTemplate GeTemplate { get; set; }
        public DataTemplate DefaultTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is OfficeLocationViewModel location)
            {
                switch (location.CountryCode)
                {
                    case "UA":
                        return UaTemplate;
                    case "US":
                        return UsTemplate;
                    case "GE":
                        return GeTemplate;
                    case "DE":
                        return DeTemplate;
                    default:
                        return DefaultTemplate;
                }
            }

            return DefaultTemplate;
        }
    }
}