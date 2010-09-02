//-------------------------------------------------------------------------------------------------
// <auto-generated> 
// Marked as auto-generated so StyleCop will ignore BDD style tests
// </auto-generated>
//-------------------------------------------------------------------------------------------------

#pragma warning disable 169
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

namespace RedBadger.Xpf.Specs.Presentation.Controls.CanvasSpecs
{
    using System.Windows;

    using Machine.Specifications;

    using Moq;

    using RedBadger.Xpf.Presentation.Controls;

    using It = Machine.Specifications.It;
    using UIElement = RedBadger.Xpf.Presentation.UIElement;

    public abstract class a_Canvas
    {
        protected static readonly Size AvailableSize = new Size(100, 100);

        protected static Canvas Subject;

        private Establish context = () => Subject = new Canvas();
    }

    [Subject(typeof(Canvas), "Measure")]
    public class when_measuring : a_Canvas
    {
        private static Mock<UIElement> child;

        private static Size childExpectedSize = new Size(1000, 1500);

        private Establish context = () =>
            {
                child = new Mock<UIElement> { CallBase = true };
                child.Object.Width = childExpectedSize.Width;
                child.Object.Height = childExpectedSize.Height;

                Subject.Children.Add(child.Object);
            };

        private Because of = () => Subject.Measure(AvailableSize);

        private It should_give_its_children_as_much_space_as_it_requires =
            () => child.Object.DesiredSize.ShouldEqual(childExpectedSize);

        private It should_have_a_desired_size_of_zero = () => Subject.DesiredSize.ShouldEqual(new Size());
    }
}