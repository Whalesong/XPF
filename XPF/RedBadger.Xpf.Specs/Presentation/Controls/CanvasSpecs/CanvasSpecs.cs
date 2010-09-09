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
    using Machine.Specifications;

    using Moq;

    using RedBadger.Xpf.Presentation;
    using RedBadger.Xpf.Presentation.Controls;

    using It = Machine.Specifications.It;

    public abstract class a_Canvas
    {
        protected static readonly Size AvailableSize = new Size(100, 100);

        protected static Mock<UIElement> Child;

        protected static Canvas Subject;

        private Establish context = () =>
            {
                Subject = new Canvas();

                Child = new Mock<UIElement> { CallBase = true };
                Subject.Children.Add(Child.Object);
            };
    }

    [Subject(typeof(Canvas), "Measure")]
    public class when_measuring : a_Canvas
    {
        private static Size childExpectedSize = new Size(1000, 1500);

        private Establish context = () =>
            {
                Child.Object.Width = childExpectedSize.Width;
                Child.Object.Height = childExpectedSize.Height;
            };

        private Because of = () => Subject.Measure(AvailableSize);

        private It should_give_its_children_as_much_space_as_it_requires =
            () => Child.Object.DesiredSize.ShouldEqual(childExpectedSize);

        private It should_have_a_desired_size_of_zero = () => Subject.DesiredSize.ShouldEqual(new Size());
    }

    [Subject(typeof(Canvas), "Arrange")]
    public class when_a_child_is_positioned : a_Canvas
    {
        private const int left = 10;

        private const int top = 20;

        private Because of = () =>
            {
                Canvas.SetLeft(Child.Object, left);
                Canvas.SetTop(Child.Object, top);
                Subject.Measure(AvailableSize);
                Subject.Arrange(new Rect(new Point(), AvailableSize));
            };

        private It should_be_assigned_the_correct_offset =
            () => Child.Object.VisualOffset.ShouldEqual(new Vector(left, top));
    }

    [Subject(typeof(Canvas), "Arrange")]
    public class when_a_child_is_moved_left : a_Canvas
    {
        private Establish context = () =>
            {
                Subject.Measure(AvailableSize);
                Subject.Arrange(new Rect(new Point(), AvailableSize));
            };

        private Because of = () => Canvas.SetLeft(Child.Object, 10);

        private It should_invalidate_arrange = () => Subject.IsArrangeValid.ShouldBeFalse();
    }

    [Subject(typeof(Canvas), "Arrange")]
    public class when_a_child_is_moved_top : a_Canvas
    {
        private Establish context = () =>
            {
                Subject.Measure(AvailableSize);
                Subject.Arrange(new Rect(new Point(), AvailableSize));
            };

        private Because of = () => Canvas.SetTop(Child.Object, 10);

        private It should_invalidate_arrange = () => Subject.IsArrangeValid.ShouldBeFalse();
    }
}