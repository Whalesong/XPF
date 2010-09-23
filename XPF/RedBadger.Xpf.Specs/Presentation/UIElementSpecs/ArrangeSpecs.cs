//-------------------------------------------------------------------------------------------------
// <auto-generated> 
// Marked as auto-generated so StyleCop will ignore BDD style tests
// </auto-generated>
//-------------------------------------------------------------------------------------------------

#pragma warning disable 169
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

namespace RedBadger.Xpf.Specs.Presentation.UIElementSpecs
{
    using System;

    using Machine.Specifications;

    using Moq;
    using Moq.Protected;

    using It = Machine.Specifications.It;

    [Subject(typeof(UIElement), "Arrange")]
    public class when_the_width_of_the_supplied_available_space_is_not_a_number : a_Measured_UIElement
    {
        private static Exception exception;

        private Because of =
            () => exception = Catch.Exception(() => Subject.Object.Arrange(new Rect(new Size(double.NaN, 0))));

        private It should_throw_a_Exception = () => exception.ShouldBeOfType<InvalidOperationException>();
    }

    [Subject(typeof(UIElement), "Arrange")]
    public class when_the_height_of_the_supplied_available_space_is_not_a_number : a_Measured_UIElement
    {
        private static Exception exception;

        private Because of =
            () => exception = Catch.Exception(() => Subject.Object.Arrange(new Rect(new Size(0, double.NaN))));

        private It should_throw_a_Exception = () => exception.ShouldBeOfType<InvalidOperationException>();
    }

    [Subject(typeof(UIElement), "Arrange")]
    public class when_the_width_of_the_supplied_available_space_is_positive_infinity : a_Measured_UIElement
    {
        private static Exception exception;

        private Because of =
            () =>
            exception = Catch.Exception(() => Subject.Object.Arrange(new Rect(new Size(double.PositiveInfinity, 0))));

        private It should_throw_a_Exception = () => exception.ShouldBeOfType<InvalidOperationException>();
    }

    [Subject(typeof(UIElement), "Arrange")]
    public class when_the_height_of_the_supplied_available_space_is_positive_infinity : a_Measured_UIElement
    {
        private static Exception exception;

        private Because of =
            () =>
            exception = Catch.Exception(() => Subject.Object.Arrange(new Rect(new Size(0, double.PositiveInfinity))));

        private It should_throw_a_Exception = () => exception.ShouldBeOfType<InvalidOperationException>();
    }

    [Subject(typeof(UIElement), "Arrange")]
    public class when_arrange_is_valid : a_Measured_UIElement
    {
        private static readonly Rect finalRect = Rect.Empty;

        private Establish context = () => Subject.Object.Arrange(finalRect);

        private Because of = () => Subject.Object.Arrange(finalRect);

        private It should_not_arrange_again =
            () => Subject.Protected().Verify(ArrangeOverride, Times.Once(), ItExpr.IsAny<Size>());
    }

    [Subject(typeof(UIElement), "Arrange")]
    public class after_arrange : a_Measured_UIElement
    {
        private static readonly Size expectedRenderSize = new Size(10, 20);

        private Establish context =
            () => Subject.Protected().Setup<Size>(ArrangeOverride, ItExpr.IsAny<Size>()).Returns(expectedRenderSize);

        private Because of = () => Subject.Object.Arrange(Rect.Empty);

        private It should_be_considered_valid = () => Subject.Object.IsArrangeValid.ShouldBeTrue();

        private It should_have_set_a_render_size = () => Subject.Object.RenderSize.ShouldEqual(expectedRenderSize);

        private It should_have_set_an_actual_height =
            () => Subject.Object.ActualHeight.ShouldEqual(expectedRenderSize.Height);

        private It should_have_set_an_actual_width =
            () => Subject.Object.ActualWidth.ShouldEqual(expectedRenderSize.Width);
    }

    [Subject(typeof(UIElement), "Arrange")]
    public class when_the_desired_size_is_greater_than_the_final_size : a_Measured_UIElement
    {
        private static readonly Size finalSize = new Size(50, 50);

        private Because of = () => Subject.Object.Arrange(new Rect(finalSize));

        private It should_layout_its_children_within_the_desired_size =
            () =>
            Subject.Protected().Verify(ArrangeOverride, Times.Once(), ItExpr.Is<Size>(size => size.Equals(desiredSize)));
    }

    [Subject(typeof(UIElement), "Arrange")]
    public class when_the_desired_size_is_greater_than_the_final_size_with_margins : a_Measured_UIElement
    {
        private static readonly Thickness margin = new Thickness(10, 20, 30, 40);

        private Establish context = () => Subject.Object.Margin = margin;

        private Because of = () => Subject.Object.Arrange(Rect.Empty);

        private It should_layout_its_children_within_the_desired_size_minus_the_margins = () =>
            {
                var expectedFinalSize = new Size(
                    Subject.Object.DesiredSize.Width - (margin.Left + margin.Right), 
                    Subject.Object.DesiredSize.Height - (margin.Top + margin.Bottom));

                Subject.Protected().Verify(
                    ArrangeOverride, Times.Once(), ItExpr.Is<Size>(size => size.Equals(expectedFinalSize)));
            };
    }

    [Subject(typeof(UIElement), "Arrange")]
    public class when_the_desired_size_is_less_than_the_final_size_and_alignment_is_stretch : a_Measured_UIElement
    {
        private static readonly Size finalSize = new Size(150, 150);

        private Because of = () => Subject.Object.Arrange(new Rect(finalSize));

        private It should_layout_its_children_within_the_final_size =
            () =>
            Subject.Protected().Verify(ArrangeOverride, Times.Once(), ItExpr.Is<Size>(size => size.Equals(finalSize)));
    }

    [Subject(typeof(UIElement), "Arrange")]
    public class when_the_desired_size_is_less_than_the_final_size_and_alignment_is_not_stretch : a_Measured_UIElement
    {
        private static readonly Size finalSize = new Size(150, 150);

        private Establish context = () =>
            {
                Subject.Object.HorizontalAlignment = HorizontalAlignment.Left;
                Subject.Object.VerticalAlignment = VerticalAlignment.Top;
            };

        private Because of = () => Subject.Object.Arrange(new Rect(finalSize));

        private It should_layout_its_children_within_the_desired_size =
            () =>
            Subject.Protected().Verify(ArrangeOverride, Times.Once(), ItExpr.Is<Size>(size => size.Equals(desiredSize)));
    }

    [Subject(typeof(UIElement), "Arrange - Offset Calculation")]
    public class when_ink_size_is_less_than_client_size_and_alignment_is_stretch : a_Measured_UIElement
    {
        private static readonly Size clientSize = new Size(100, 100);

        private static readonly Vector expectedVisualOffset = new Vector(25, 25);

        private static readonly Size inkSize = new Size(50, 50);

        private Establish context =
            () => Subject.Protected().Setup<Size>(ArrangeOverride, ItExpr.IsAny<Size>()).Returns(inkSize);

        private Because of = () => Subject.Object.Arrange(new Rect(clientSize));

        private It should_set_the_visual_offset = () => Subject.Object.VisualOffset.ShouldEqual(expectedVisualOffset);
    }

    [Subject(typeof(UIElement), "Arrange - Offset Calculation")]
    public class when_ink_size_is_less_than_client_size_and_alignment_is_left_and_top : a_Measured_UIElement
    {
        private static readonly Size clientSize = new Size(100, 100);

        private static readonly Vector expectedVisualOffset = new Vector(0, 0);

        private static readonly Size inkSize = new Size(50, 50);

        private Establish context = () =>
            {
                Subject.Object.HorizontalAlignment = HorizontalAlignment.Left;
                Subject.Object.VerticalAlignment = VerticalAlignment.Top;

                Subject.Protected().Setup<Size>(ArrangeOverride, ItExpr.IsAny<Size>()).Returns(inkSize);
            };

        private Because of = () => Subject.Object.Arrange(new Rect(clientSize));

        private It should_set_the_visual_offset = () => Subject.Object.VisualOffset.ShouldEqual(expectedVisualOffset);
    }

    [Subject(typeof(UIElement), "Arrange - Offset Calculation")]
    public class when_ink_size_is_less_than_client_size_and_alignment_is_center : a_Measured_UIElement
    {
        private static readonly Size clientSize = new Size(100, 100);

        private static readonly Vector expectedVisualOffset = new Vector(25, 25);

        private static readonly Size inkSize = new Size(50, 50);

        private Establish context = () =>
            {
                Subject.Object.HorizontalAlignment = HorizontalAlignment.Center;
                Subject.Object.VerticalAlignment = VerticalAlignment.Center;

                Subject.Protected().Setup<Size>(ArrangeOverride, ItExpr.IsAny<Size>()).Returns(inkSize);
            };

        private Because of = () => Subject.Object.Arrange(new Rect(clientSize));

        private It should_set_the_visual_offset = () => Subject.Object.VisualOffset.ShouldEqual(expectedVisualOffset);
    }

    [Subject(typeof(UIElement), "Arrange - Offset Calculation")]
    public class when_ink_size_is_less_than_client_size_and_alignment_is_right_and_bottom : a_Measured_UIElement
    {
        private static readonly Size clientSize = new Size(100, 100);

        private static readonly Vector expectedVisualOffset = new Vector(50, 50);

        private static readonly Size inkSize = new Size(50, 50);

        private Establish context = () =>
            {
                Subject.Object.HorizontalAlignment = HorizontalAlignment.Right;
                Subject.Object.VerticalAlignment = VerticalAlignment.Bottom;

                Subject.Protected().Setup<Size>(ArrangeOverride, ItExpr.IsAny<Size>()).Returns(inkSize);
            };

        private Because of = () => Subject.Object.Arrange(new Rect(clientSize));

        private It should_set_the_visual_offset = () => Subject.Object.VisualOffset.ShouldEqual(expectedVisualOffset);
    }

    [Subject(typeof(UIElement), "Arrange - Offset Calculation")]
    public class when_ink_size_is_greater_than_client_size_and_alignment_is_stretch : a_Measured_UIElement
    {
        private static readonly Size clientSize = new Size(50, 50);

        private static readonly Vector expectedVisualOffset = new Vector(0, 0);

        private static readonly Size inkSize = new Size(100, 100);

        private Establish context =
            () => Subject.Protected().Setup<Size>(ArrangeOverride, ItExpr.IsAny<Size>()).Returns(inkSize);

        private Because of = () => Subject.Object.Arrange(new Rect(clientSize));

        private It should_set_the_visual_offset = () => Subject.Object.VisualOffset.ShouldEqual(expectedVisualOffset);
    }

    [Subject(typeof(UIElement), "Arrange - Offset Calculation")]
    public class when_ink_size_is_greater_than_client_size_and_alignment_is_left_and_top : a_Measured_UIElement
    {
        private static readonly Size clientSize = new Size(50, 50);

        private static readonly Vector expectedVisualOffset = new Vector(0, 0);

        private static readonly Size inkSize = new Size(100, 100);

        private Establish context = () =>
            {
                Subject.Object.HorizontalAlignment = HorizontalAlignment.Left;
                Subject.Object.VerticalAlignment = VerticalAlignment.Top;

                Subject.Protected().Setup<Size>(ArrangeOverride, ItExpr.IsAny<Size>()).Returns(inkSize);
            };

        private Because of = () => Subject.Object.Arrange(new Rect(clientSize));

        private It should_set_the_visual_offset = () => Subject.Object.VisualOffset.ShouldEqual(expectedVisualOffset);
    }

    [Subject(typeof(UIElement), "Arrange - Offset Calculation")]
    public class when_ink_size_is_greater_than_client_size_and_alignment_is_center : a_Measured_UIElement
    {
        private static readonly Size clientSize = new Size(50, 50);

        private static readonly Vector expectedVisualOffset = new Vector(-25, -25);

        private static readonly Size inkSize = new Size(100, 100);

        private Establish context = () =>
            {
                Subject.Object.HorizontalAlignment = HorizontalAlignment.Center;
                Subject.Object.VerticalAlignment = VerticalAlignment.Center;

                Subject.Protected().Setup<Size>(ArrangeOverride, ItExpr.IsAny<Size>()).Returns(inkSize);
            };

        private Because of = () => Subject.Object.Arrange(new Rect(clientSize));

        private It should_set_the_visual_offset = () => Subject.Object.VisualOffset.ShouldEqual(expectedVisualOffset);
    }

    [Subject(typeof(UIElement), "Arrange - Offset Calculation")]
    public class when_ink_size_is_greater_than_client_size_and_alignment_is_right_and_bottom : a_Measured_UIElement
    {
        private static readonly Size clientSize = new Size(50, 50);

        private static readonly Vector expectedVisualOffset = new Vector(-50, -50);

        private static readonly Size inkSize = new Size(100, 100);

        private Establish context = () =>
            {
                Subject.Object.HorizontalAlignment = HorizontalAlignment.Right;
                Subject.Object.VerticalAlignment = VerticalAlignment.Bottom;

                Subject.Protected().Setup<Size>(ArrangeOverride, ItExpr.IsAny<Size>()).Returns(inkSize);
            };

        private Because of = () => Subject.Object.Arrange(new Rect(clientSize));

        private It should_set_the_visual_offset = () => Subject.Object.VisualOffset.ShouldEqual(expectedVisualOffset);
    }

    [Subject(typeof(UIElement), "Arrange - Offset Calculation")]
    public class when_ink_size_is_less_than_client_size_and_alignment_is_left_and_top_with_margins :
        a_Measured_UIElement
    {
        private static readonly Size clientSize = new Size(100, 100);

        private static readonly Vector expectedVisualOffset = new Vector(10, 20);

        private static readonly Size inkSize = new Size(50, 50);

        private Establish context = () =>
            {
                Subject.Object.HorizontalAlignment = HorizontalAlignment.Left;
                Subject.Object.VerticalAlignment = VerticalAlignment.Top;
                Subject.Object.Margin = new Thickness(10, 20, 30, 40);

                Subject.Protected().Setup<Size>(ArrangeOverride, ItExpr.IsAny<Size>()).Returns(inkSize);
            };

        private Because of = () => Subject.Object.Arrange(new Rect(clientSize));

        private It should_set_the_visual_offset = () => Subject.Object.VisualOffset.ShouldEqual(expectedVisualOffset);
    }

    [Subject(typeof(UIElement), "Arrange - Offset Calculation")]
    public class when_ink_size_is_less_than_client_size_and_alignment_is_left_and_top_with_non_zero_position :
        a_Measured_UIElement
    {
        private static readonly Size clientSize = new Size(100, 100);

        private static readonly Vector expectedVisualOffset = new Vector(200, 300);

        private static readonly Size inkSize = new Size(50, 50);

        private Establish context = () =>
            {
                Subject.Object.HorizontalAlignment = HorizontalAlignment.Left;
                Subject.Object.VerticalAlignment = VerticalAlignment.Top;

                Subject.Protected().Setup<Size>(ArrangeOverride, ItExpr.IsAny<Size>()).Returns(inkSize);
            };

        private Because of = () => Subject.Object.Arrange(new Rect(200, 300, clientSize.Width, clientSize.Height));

        private It should_set_the_visual_offset = () => Subject.Object.VisualOffset.ShouldEqual(expectedVisualOffset);
    }
}