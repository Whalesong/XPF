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
    using Machine.Specifications;

    using Moq;

    using RedBadger.Xpf.Controls;
    using RedBadger.Xpf.Data;

    using It = Machine.Specifications.It;

    public abstract class a_UIElement_Hierarchy
    {
        protected static Mock<UIElement> deepestChild;

        protected static ContentControl middleChild;

        protected static ContentControl parent;

        private Establish context = () =>
            {
                deepestChild = new Mock<UIElement> { CallBase = true };
                middleChild = new ContentControl { Content = deepestChild.Object };
                parent = new ContentControl { Content = middleChild };
            };
    }

    [Subject(typeof(UIElement), "Data Context")]
    public class when_data_context_is_changed_on_an_element_with_children : a_UIElement_Hierarchy
    {
        private Establish context = () => parent.Measure(Size.Empty);

        private Because of = () => parent.DataContext = new object();

        private It should_invalidate_measure_on_the_deepest_child =
            () => deepestChild.Object.IsMeasureValid.ShouldBeFalse();
    }

    [Subject(typeof(UIElement), "Data Context")]
    public class when_data_context_is_changed_on_an_element_with_children_that_have_their_own_data_context :
        a_UIElement_Hierarchy
    {
        private Establish context = () =>
            {
                middleChild.DataContext = new object();
                parent.Measure(Size.Empty);
            };

        private Because of = () => parent.DataContext = new object();

        private It should_not_invalidate_measure_on_children_that_have_access_to_an_exisiting_data_context =
            () => deepestChild.Object.IsMeasureValid.ShouldBeTrue();

        private It should_not_invalidate_measure_on_children_that_have_their_own_data_context =
            () => middleChild.IsMeasureValid.ShouldBeTrue();
    }

    [Subject(typeof(UIElement), "Data Context")]
    public class when_binding_to_an_unset_data_context : a_UIElement_Hierarchy
    {
        private const double ExpectedDataContext = 10d;

        private Establish context = () => parent.DataContext = ExpectedDataContext;

        private Because of = () =>
            {
                deepestChild.Object.Bind(UIElement.WidthProperty, BindingFactory.CreateOneWay<double>());
                parent.Measure(Size.Empty);
            };

        private It should_search_up_the_visual_tree_to_find_a_valid_data_context =
            () => deepestChild.Object.Width.ShouldEqual(ExpectedDataContext);
    }
}