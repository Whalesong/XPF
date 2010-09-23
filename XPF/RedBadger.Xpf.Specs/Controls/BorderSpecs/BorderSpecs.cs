//-------------------------------------------------------------------------------------------------
// <auto-generated> 
// Marked as auto-generated so StyleCop will ignore BDD style tests
// </auto-generated>
//-------------------------------------------------------------------------------------------------

#pragma warning disable 169
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

namespace RedBadger.Xpf.Specs.Controls.BorderSpecs
{
    using System.Linq;

    using Machine.Specifications;

    using Moq;

    using RedBadger.Xpf.Controls;
    using RedBadger.Xpf.Media;

    using It = Machine.Specifications.It;

    [Subject(typeof(Border))]
    public class when_initialized : a_Border
    {
        private It should_have_no_background = () => Subject.Background.ShouldBeNull();

        private It should_have_no_border_brush = () => Subject.BorderBrush.ShouldBeNull();

        private It should_have_no_padding = () => Subject.Padding.ShouldEqual(new Thickness());

        private It should_have_no_thickness = () => Subject.BorderThickness.ShouldEqual(new Thickness());
    }

    [Subject(typeof(Border))]
    public class when_used_in_its_default_state : a_Border_with_child
    {
        private Because of = () => RootElement.Object.Update();

        private It should_contain_the_correct_number_of_children =
            () => Subject.GetVisualChildren().Count().ShouldEqual(1);

        private It should_have_no_effect_on_its_child = () => Child.Object.VisualOffset.ShouldEqual(Vector.Zero);

        private It should_return_its_child_when_children_are_requested =
            () => Subject.GetVisualChildren().First().ShouldBeTheSameAs(Child.Object);

        private It should_set_itself_as_the_visual_parent_on_the_child =
            () => Child.Object.VisualParent.ShouldEqual(Subject);
    }

    [Subject(typeof(Border))]
    public class when_content_is_changed : a_Border_with_child
    {
        private Because of = () => Subject.Child = new Mock<IElement>().Object;

        private It should_unset_itself_as_the_parent_of_the_outgoing_child =
            () => Child.Object.VisualParent.ShouldBeNull();
    }

    [Subject(typeof(Border), "Padding/Thickness")]
    public class when_padding_is_specified : a_Border_with_child
    {
        private static readonly Thickness padding = new Thickness(10, 20, 30, 40);

        private Because of = () =>
            {
                Subject.Padding = padding;
                RootElement.Object.Update();
            };

        private It should_increase_the_desired_size =
            () =>
            Subject.DesiredSize.ShouldEqual(
                new Size(
                ChildSize.Width + padding.Left + padding.Right, ChildSize.Height + padding.Top + padding.Bottom));

        private It should_take_padding_into_account_when_drawing =
            () => Child.Object.VisualOffset.ShouldEqual(new Vector(padding.Left, padding.Top));
    }

    [Subject(typeof(Border), "Padding/Thickness")]
    public class when_padding_is_changed : a_Border_with_child
    {
        private Establish context = () => RootElement.Object.Update();

        private Because of = () => Subject.Padding = new Thickness(10, 20, 30, 40);

        private It should_invalidate_measure = () => Subject.IsMeasureValid.ShouldBeFalse();
    }

    [Subject(typeof(Border), "Padding/Thickness")]
    public class when_thickness_is_specified : a_Border_with_child
    {
        private static readonly Thickness thickness = new Thickness(1, 2, 3, 4);

        private Because of = () =>
            {
                Subject.BorderThickness = thickness;
                RootElement.Object.Update();
            };

        private It should_increase_the_desired_size =
            () =>
            Subject.DesiredSize.ShouldEqual(
                new Size(
                ChildSize.Width + thickness.Left + thickness.Right, ChildSize.Height + thickness.Top + thickness.Bottom));

        private It should_take_padding_into_account_when_drawing =
            () => Child.Object.VisualOffset.ShouldEqual(new Vector(thickness.Left, thickness.Top));
    }

    [Subject(typeof(Border), "Padding/Thickness")]
    public class when_thickness_is_changed : a_Border_with_child
    {
        private Establish context = () => RootElement.Object.Update();

        private Because of = () => Subject.BorderThickness = new Thickness(1, 2, 3, 4);

        private It should_invalidate_measure = () => Subject.IsMeasureValid.ShouldBeFalse();
    }

    [Subject(typeof(Border), "Padding/Thickness")]
    public class when_padding_and_thickness_are_specified : a_Border_with_child
    {
        private static readonly Thickness padding = new Thickness(10, 20, 30, 40);

        private static readonly Thickness thickness = new Thickness(1, 2, 3, 4);

        private Because of = () =>
            {
                Subject.Padding = padding;
                Subject.BorderThickness = thickness;
                RootElement.Object.Update();
            };

        private It should_increase_the_desired_size =
            () =>
            Subject.DesiredSize.ShouldEqual(
                new Size(
                ChildSize.Width + padding.Left + padding.Right + thickness.Left + thickness.Right, 
                ChildSize.Height + padding.Top + padding.Bottom + thickness.Top + thickness.Bottom));

        private It should_take_padding_into_account_when_drawing =
            () =>
            Child.Object.VisualOffset.ShouldEqual(
                new Vector(padding.Left + thickness.Left, padding.Top + thickness.Top));
    }

    [Subject(typeof(Border), "Rendering")]
    public class when_a_border_thickness_and_brush_have_been_specified : a_Border_with_child
    {
        private static readonly Rect expectedBottomBorderRectangle = new Rect(1, 37, 15, 4);

        private static readonly Rect expectedLeftBorderRectangle = new Rect(0, 0, 1, 41);

        private static readonly Rect expectedRightBorderRectangle = new Rect(16, 2, 3, 39);

        private static readonly Rect expectedTopBorderRectangle = new Rect(1, 0, 18, 2);

        private static readonly Thickness thickness = new Thickness(1, 2, 3, 4);

        private static SolidColorBrush expectedBrush;

        private Establish context = () =>
            {
                Subject.HorizontalAlignment = HorizontalAlignment.Left;
                Subject.VerticalAlignment = VerticalAlignment.Top;
            };

        private Because of = () =>
            {
                expectedBrush = new SolidColorBrush(Colors.Red);
                Subject.BorderBrush = expectedBrush;
                Subject.BorderThickness = thickness;
                RootElement.Object.Update();
            };

        private It should_draw_the_bottom_border =
            () =>
            DrawingContext.Verify(
                drawingContext => drawingContext.DrawRectangle(expectedBottomBorderRectangle, expectedBrush));

        private It should_draw_the_left_border =
            () =>
            DrawingContext.Verify(
                drawingContext => drawingContext.DrawRectangle(expectedLeftBorderRectangle, expectedBrush));

        private It should_draw_the_right_border =
            () =>
            DrawingContext.Verify(
                drawingContext => drawingContext.DrawRectangle(expectedRightBorderRectangle, expectedBrush));

        private It should_draw_the_top_border =
            () =>
            DrawingContext.Verify(
                drawingContext => drawingContext.DrawRectangle(expectedTopBorderRectangle, expectedBrush));
    }

    [Subject(typeof(Border), "Rendering")]
    public class when_no_border_brush_has_been_specified : a_Border_with_child
    {
        private Because of = () =>
            {
                Subject.BorderThickness = new Thickness(1, 2, 3, 4);
                RootElement.Object.Update();
            };

        private It should_not_render_a_border =
            () =>
            DrawingContext.Verify(
                drawingContext => drawingContext.DrawRectangle(Moq.It.IsAny<Rect>(), Moq.It.IsAny<Brush>()), 
                Times.Never());
    }

    [Subject(typeof(Border), "Rendering")]
    public class when_no_thickness_has_been_specified : a_Border_with_child
    {
        private Because of = () =>
            {
                Subject.BorderBrush = new SolidColorBrush(Colors.Black);
                RootElement.Object.Update();
            };

        private It should_not_render_a_border =
            () =>
            DrawingContext.Verify(
                drawingContext => drawingContext.DrawRectangle(Moq.It.IsAny<Rect>(), Moq.It.IsAny<Brush>()), 
                Times.Never());
    }

    [Subject(typeof(Border), "Background")]
    public class when_background_is_not_specified : a_Border_with_child
    {
        private Because of = () => RootElement.Object.Update();

        private It should_not_render_a_background =
            () =>
            DrawingContext.Verify(
                drawingContext => drawingContext.DrawRectangle(Moq.It.IsAny<Rect>(), Moq.It.IsAny<Brush>()), 
                Times.Never());
    }

    [Subject(typeof(Border), "Background")]
    public class when_background_is_specified : a_Border_with_child
    {
        private static SolidColorBrush expectedBackground;

        private static Thickness margin;

        private Establish context = () =>
            {
                expectedBackground = new SolidColorBrush(Colors.Blue);

                margin = new Thickness(1, 2, 3, 4);
                Subject.Margin = margin;
            };

        private Because of = () =>
            {
                Subject.Background = expectedBackground;
                RootElement.Object.Update();
            };

        private It should_render_the_background_in_the_right_place = () =>
            {
                var area = new Rect(0, 0, Subject.ActualWidth, Subject.ActualHeight);

                DrawingContext.Verify(
                    drawingContext =>
                    drawingContext.DrawRectangle(Moq.It.Is<Rect>(rect => rect.Equals(area)), Moq.It.IsAny<Brush>()));
            };

        private It should_render_with_the_specified_background_color =
            () =>
            DrawingContext.Verify(
                drawingContext => drawingContext.DrawRectangle(Moq.It.IsAny<Rect>(), expectedBackground));
    }

    [Subject(typeof(Border), "BorderBrush")]
    public class when_the_border_brush_is_changed : a_Border_with_child
    {
        private Establish context = () => RootElement.Object.Update();

        private Because of = () => Subject.BorderBrush = new SolidColorBrush(Colors.Blue);

        private It should_invalidate_arrange = () => Subject.IsArrangeValid.ShouldBeFalse();
    }
}