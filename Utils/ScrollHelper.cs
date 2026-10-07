using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Tempo.Utils
{
    public static class ScrollHelper
    {
        public static readonly DependencyProperty BubbleMouseWheelProperty =
            DependencyProperty.RegisterAttached("BubbleMouseWheel", typeof(bool),
                typeof(ScrollHelper), new PropertyMetadata(false, OnChanged));

        public static bool GetBubbleMouseWheel(DependencyObject d) => (bool)d.GetValue(BubbleMouseWheelProperty);
        public static void SetBubbleMouseWheel(DependencyObject d, bool v) => d.SetValue(BubbleMouseWheelProperty, v);

        private static void OnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UIElement el)
            {
                if ((bool)e.NewValue) el.PreviewMouseWheel += OnWheel;
                else el.PreviewMouseWheel -= OnWheel;
            }
        }

        private static void OnWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Handled || sender is not FrameworkElement el || VisualTreeHelper.GetParent(el) is not UIElement parent) return;
            e.Handled = true;
            parent.RaiseEvent(new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
            {
                RoutedEvent = UIElement.MouseWheelEvent,
                Source = el
            });
        }
    }
}
