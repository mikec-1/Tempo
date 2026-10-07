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

        #region BubbleMouseWheel

        public static readonly DependencyProperty BubbleMouseWheelProperty =
            DependencyProperty.RegisterAttached(
                "BubbleMouseWheel",
                typeof(bool),
                typeof(AttachedProperties),
                new PropertyMetadata(false, OnBubbleMouseWheelChanged));

        public static bool GetBubbleMouseWheel(DependencyObject obj)
            => (bool)obj.GetValue(BubbleMouseWheelProperty);

        public static void SetBubbleMouseWheel(DependencyObject obj, bool value)
            => obj.SetValue(BubbleMouseWheelProperty, value);

        private static void OnBubbleMouseWheelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UIElement element)
            {
                if ((bool)e.NewValue)
                    element.PreviewMouseWheel += OnPreviewMouseWheel;
                else
                    element.PreviewMouseWheel -= OnPreviewMouseWheel;
            }
        }

        private static void OnPreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta != 0 && sender is FrameworkElement el && el.Parent is UIElement parent)
            {
                e.Handled = true;
                var args = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta);
                args.RoutedEvent = UIElement.MouseWheelEvent;
                parent.RaiseEvent(args);
            }
        }

        #endregion
    }
}
