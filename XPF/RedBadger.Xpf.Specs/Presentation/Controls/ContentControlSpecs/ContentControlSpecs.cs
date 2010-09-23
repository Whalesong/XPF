//-------------------------------------------------------------------------------------------------
// <auto-generated> 
// Marked as auto-generated so StyleCop will ignore BDD style tests
// </auto-generated>
//-------------------------------------------------------------------------------------------------

#pragma warning disable 169
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

namespace RedBadger.Xpf.Specs.Presentation.Controls.ContentControlSpecs
{
    using System.Linq;

    using Machine.Specifications;

    using Moq;

    using RedBadger.Xpf.Controls;

    using It = Machine.Specifications.It;

    public abstract class a_ContentControl
    {
        protected static ContentControl ContentControl;

        private Establish context = () => ContentControl = new ContentControl();
    }

    [Subject(typeof(ContentControl))]
    public class when_empty : a_ContentControl
    {
        private It should_not_return_any_children = () => ContentControl.GetVisualChildren().Count().ShouldEqual(0);
    }

    [Subject(typeof(ContentControl))]
    public class when_content_is_added : a_ContentControl
    {
        private static Mock<IElement> childContent;

        private Establish context = () =>
            {
                ContentControl.Measure(Size.Empty);
                childContent = new Mock<IElement>();
            };

        private Because of = () => ContentControl.Content = childContent.Object;

        private It should_invalidate_measure = () => ContentControl.IsMeasureValid.ShouldBeFalse();

        private It should_mark_itself_as_the_visual_parent =
            () => childContent.VerifySet(element => element.VisualParent = ContentControl);

        private It should_return_that_child_when_its_children_are_requested =
            () => ContentControl.GetVisualChildren().First().ShouldBeTheSameAs(childContent.Object);

        private It should_return_the_correct_number_of_children_when_its_children_are_requested =
            () => ContentControl.GetVisualChildren().Count().ShouldEqual(1);
    }

    [Subject(typeof(ContentControl))]
    public class when_content_is_changed : a_ContentControl
    {
        private static Mock<UIElement> oldChild;

        private Establish context = () =>
            {
                oldChild = new Mock<UIElement> { CallBase = true };
                ContentControl.Content = oldChild.Object;
            };

        private Because of = () => ContentControl.Content = new Mock<IElement>().Object;

        private It should_unset_itself_as_the_parent_of_the_outgoing_child =
            () => oldChild.Object.VisualParent.ShouldBeNull();
    }
}