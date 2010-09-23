﻿//-------------------------------------------------------------------------------------------------
// <auto-generated> 
// Marked as auto-generated so StyleCop will ignore BDD style tests
// </auto-generated>
//-------------------------------------------------------------------------------------------------

#pragma warning disable 169
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

namespace RedBadger.Xpf.Specs.Presentation.Controls.GridSpecs
{
    using Machine.Specifications;

    using Moq;

    using RedBadger.Xpf.Controls;

    public abstract class a_Grid
    {
        protected const string ArrangeOverride = "ArrangeOverride";

        protected const string MeasureOverride = "MeasureOverride";

        protected static readonly Size AvailableSize = new Size(200, 200);

        protected static Grid Subject;

        private Establish context = () => Subject = new Grid();

        protected static Mock<UIElement> CreateChild(int row, int column)
        {
            var child = new Mock<UIElement> { CallBase = true };
            child.Object.VerticalAlignment = VerticalAlignment.Top;
            child.Object.HorizontalAlignment = HorizontalAlignment.Left;
            Grid.SetRow(child.Object, row);
            Grid.SetColumn(child.Object, column);
            Subject.Children.Add(child.Object);
            return child;
        }
    }
}