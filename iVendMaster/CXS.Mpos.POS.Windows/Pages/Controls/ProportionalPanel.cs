using System;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CXS.Mpos.POS.Windows.Pages
{
    class ProportionalPanel : Panel
    {
        public Orientation Orientation { get; set; }

        public int Offset { get; set; }

        protected override Size MeasureOverride(Size availableSize)
        {
            var requiredSize = new Size();

            if (Children.Count == 0)
                return requiredSize;

            switch (Orientation)
            {
                case Orientation.Horizontal:
                    foreach (UIElement child in Children)
                    {
                        child.Measure(availableSize);
                        requiredSize = new Size(requiredSize.Width + child.DesiredSize.Width, Math.Max(requiredSize.Height, child.DesiredSize.Height));
                    }
                    requiredSize = new Size(requiredSize.Width + Offset * (Children.Count - 1), requiredSize.Height);
                    break;

                case Orientation.Vertical:
                    foreach (UIElement child in Children)
                    {
                        child.Measure(availableSize);
                        requiredSize = new Size(Math.Max(requiredSize.Width, child.DesiredSize.Width), requiredSize.Height + child.DesiredSize.Height);
                    }
                    requiredSize = new Size(requiredSize.Width, requiredSize.Height + Offset * (Children.Count - 1));
                    break;
            }
            return requiredSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            if (Children.Count == 0)
                return finalSize;

            switch (Orientation)
            {
                case Orientation.Horizontal:
                    {
                        double width = (finalSize.Width - (Children.Count - 1) * Offset) / Children.Count;
                        double x = 0.0;
                        foreach (UIElement child in Children)
                        {
                            child.Arrange(
                                new Rect(
                                    new Point(x, 0.0),
                                    new Point(x + width, finalSize.Height)));
                            x += width + Offset;
                        }
                    }
                    break;

                case Orientation.Vertical:
                    {
                        double height = (finalSize.Height - (Children.Count - 1) * Offset) / Children.Count;
                        double y = 0.0;
                        foreach (UIElement child in Children)
                        {
                            child.Arrange(
                                new Rect(
                                    new Point(0.0, y),
                                    new Point(finalSize.Width, y + height)));
                            y += height + Offset;
                        }
                    }
                    break;
            }
            return finalSize;
        }
    }
}
