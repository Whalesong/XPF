﻿namespace RedBadger.Xpf.Presentation
{
    using System.Collections.Generic;
    using System.Windows;

    using RedBadger.Xpf.Presentation.Input;
    using RedBadger.Xpf.Presentation.Media;

    public interface IElement : IDependencyObject
    {
        Size DesiredSize { get; }

        double Height { get; set; }

        /// <summary>
        ///     Gets a value indicating whether the computed size and position of child elements in this element's layout are valid.
        /// </summary>
        /// <value>
        ///     <c>true</c> if the size and position of layout are valid; otherwise, <c>false</c>.
        /// </value>
        bool IsArrangeValid { get; }

        bool IsMeasureValid { get; }

        Thickness Margin { get; set; }

        IElement VisualParent { get; set; }

        double Width { get; set; }

        /// <summary>
        ///     Positions child elements and determines a size for a UIElement.
        ///     Parent elements call this method from their ArrangeOverride implementation to form a recursive layout update.
        ///     This method constitutes the second pass of a layout update.
        /// </summary>
        /// <param name = "finalRect">The final size that the parent computes for the child element, provided as a Rect instance.</param>
        void Arrange(Rect finalRect);

        Vector CalculateAbsoluteOffset();

        IEnumerable<IElement> GetChildren();

        bool HitTest(Point point);

        void InvalidateArrange();

        void InvalidateMeasure();

        void Measure(Size availableSize);

        void OnNextMouseData(MouseData mouseData);

        bool TryGetRenderer(out IRenderer renderer);
    }
}