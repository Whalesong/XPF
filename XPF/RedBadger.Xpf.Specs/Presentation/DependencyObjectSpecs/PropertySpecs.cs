//-------------------------------------------------------------------------------------------------
// <auto-generated> 
// Marked as auto-generated so StyleCop will ignore BDD style tests
// </auto-generated>
//-------------------------------------------------------------------------------------------------

#pragma warning disable 169
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

namespace RedBadger.Xpf.Specs.Presentation.DependencyObjectSpecs
{
    using Machine.Specifications;

    using RedBadger.Xpf.Presentation;

    public abstract class a_DependencyObject
    {
        protected static DependencyObject Subject;

        private Establish context = () => Subject = new DependencyObject();
    }

    [Subject(typeof(DependencyObject))]
    public class when_clearing_a_property_value : a_DependencyObject
    {
        public static readonly Property<string, DependencyObject> TestPropertyProperty;

        private static readonly string defaultValue = string.Empty;

        private Establish context = () => Subject.SetValue(TestPropertyProperty, "A Value");

        private Because of = () => Subject.ClearValue(TestPropertyProperty);

        private It should_revert_to_default = () => Subject.GetValue(TestPropertyProperty).ShouldEqual(defaultValue);

        static when_clearing_a_property_value()
        {
            TestPropertyProperty = Property<string, DependencyObject>.Register("TestProperty", defaultValue);
        }
    }

    [Subject(typeof(DependencyObject))]
    public class when_changing_a_property_value : a_DependencyObject
    {
        public static readonly Property<string, DependencyObject> TestPropertyProperty;

        private const string ExpectedFinalValue = "Final Value";

        private static readonly string defaultValue = string.Empty;

        private Establish context = () => Subject.SetValue(TestPropertyProperty, "Initial Value");

        private Because of = () => Subject.SetValue(TestPropertyProperty, ExpectedFinalValue);

        private It should_return_the_correct_value =
            () => Subject.GetValue(TestPropertyProperty).ShouldEqual(ExpectedFinalValue);

        static when_changing_a_property_value()
        {
            TestPropertyProperty = Property<string, DependencyObject>.Register("TestProperty", defaultValue);
        }
    }
}