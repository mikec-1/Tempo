using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace Tempo.Utils
{
    public static class AttachedProperties
    {
        public static readonly DependencyProperty ThumbnailColorProperty =
            DependencyProperty.RegisterAttached(
                "ThumbnailColor",
                typeof(string),
                typeof(AttachedProperties),
                new PropertyMetadata(""));

        public static void SetThumbnailColor(DependencyObject element, string value) =>
            element.SetValue(ThumbnailColorProperty, value);

        public static string GetThumbnailColor(DependencyObject element) =>
            (string)element.GetValue(ThumbnailColorProperty);

    }
}
