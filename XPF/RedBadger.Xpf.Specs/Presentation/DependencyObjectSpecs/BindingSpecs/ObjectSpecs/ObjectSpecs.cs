//-------------------------------------------------------------------------------------------------
// <auto-generated> 
// Marked as auto-generated so StyleCop will ignore BDD style tests
// </auto-generated>
//-------------------------------------------------------------------------------------------------

#pragma warning disable 169
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

namespace RedBadger.Xpf.Specs.Presentation.DependencyObjectSpecs.BindingSpecs.ObjectSpecs
{
    using System;

    using Machine.Specifications;

    using Moq;

    using RedBadger.Xpf.Graphics;
    using RedBadger.Xpf.Presentation;
    using RedBadger.Xpf.Presentation.Controls;
    using RedBadger.Xpf.Presentation.Data;
    using RedBadger.Xpf.Presentation.Media;

    using It = Machine.Specifications.It;

    public class TestBindingObject
    {
        public Brush Brush { get; set; }

        public SolidColorBrush SolidColorBrush { get; set; }
    }

    public class TestBindingDependencyObject : DependencyObject
    {
        public static readonly ReactiveProperty<SolidColorBrush, TestBindingObject> SolidColorBrushProperty =
            ReactiveProperty<SolidColorBrush, TestBindingObject>.Register("SolidColorBrush");

        public SolidColorBrush SolidColorBrush
        {
            get
            {
                return this.GetValue(SolidColorBrushProperty);
            }

            set
            {
                this.SetValue(SolidColorBrushProperty, value);
            }
        }
    }

    [Subject(typeof(DependencyObject))]
    public class when_binding_is_one_way_to_an_object
    {
        private const double ExpectedWidth = 10d;

        private static Border target;

        private Establish context = () => target = new Border();

        private Because of = () =>
            {
                IObservable<double> fromSource = BindingFactory.CreateOneWay(ExpectedWidth);
                target.Bind(UIElement.WidthProperty, fromSource);
            };

        private It should_bind_to_the_object = () => target.Width.ShouldEqual(ExpectedWidth);
    }

    [Subject(typeof(DependencyObject))]
    public class when_binding_is_one_way_to_the_data_context_which_is_an_object
    {
        private const double ExpectedWidth = 10d;

        private static Border target;

        private Establish context = () => target = new Border { DataContext = ExpectedWidth };

        private Because of = () =>
            {
                IObservable<double> fromSource = BindingFactory.CreateOneWay<double>();
                target.Bind(UIElement.WidthProperty, fromSource);
                target.Measure(Size.Empty);
            };

        private It should_bind_to_the_object = () => target.Width.ShouldEqual(ExpectedWidth);
    }

    [Subject(typeof(DependencyObject))]
    public class when_binding_is_one_way_to_a_property_on_an_object
    {
        private static TestBindingObject bindingObject;

        private static Border target;

        private Establish context = () =>
            {
                bindingObject = new TestBindingObject { Brush = new SolidColorBrush(Colors.Blue) };
                target = new Border();
            };

        private Because of = () =>
            {
                IObservable<Brush> fromSource = BindingFactory.CreateOneWay(bindingObject, o => o.Brush);
                target.Bind(Border.BorderBrushProperty, fromSource);
            };

        private It should_bind_to_the_object = () => target.BorderBrush.ShouldEqual(bindingObject.Brush);
    }

    [Subject(typeof(DependencyObject))]
    public class when_binding_is_one_way_to_a_property_on_the_data_context
    {
        private static TestBindingObject bindingObject;

        private static Border target;

        private Establish context = () =>
            {
                bindingObject = new TestBindingObject { Brush = new SolidColorBrush(Colors.Blue) };
                target = new Border { DataContext = bindingObject };
            };

        private Because of = () =>
            {
                IObservable<Brush> fromSource = BindingFactory.CreateOneWay<TestBindingObject, Brush>(o => o.Brush);
                target.Bind(Border.BorderBrushProperty, fromSource);
                target.Measure(Size.Empty);
            };

        private It should_bind_to_the_object = () => target.BorderBrush.ShouldEqual(bindingObject.Brush);
    }

    [Subject(typeof(DependencyObject))]
    public class when_a_binding_is_one_way_and_the_source_type_is_more_derived
    {
        private static readonly SolidColorBrush expectedBrush = new SolidColorBrush(Colors.Brown);

        private static Border target;

        private Establish context = () => target = new Border();

        private Because of = () =>
            {
                IObservable<Brush> fromSource = BindingFactory.CreateOneWay(expectedBrush);
                target.Bind(Border.BorderBrushProperty, fromSource);
            };

        private It should_have_the_correct_brush = () => target.BorderBrush.ShouldEqual(expectedBrush);
    }

    [Subject(typeof(DependencyObject))]
    public class when_a_binding_is_one_way_to_source
    {
        private static readonly Brush expectedBrush = new SolidColorBrush(Colors.Brown);

        private static TestBindingObject source;

        private static Border target;

        private Establish context = () =>
            {
                source = new TestBindingObject();
                target = new Border();

                IObserver<Brush> toSource = BindingFactory.CreateOneWayToSource(source, o => o.Brush);
                target.Bind(Border.BorderBrushProperty, toSource);
            };

        private Because of = () => target.BorderBrush = expectedBrush;

        private It should_have_the_correct_width = () => source.Brush.ShouldEqual(expectedBrush);
    }

    [Subject(typeof(DependencyObject))]
    public class when_a_binding_is_one_way_to_source_and_the_type_of_the_target_property_is_more_derived
    {
        private static readonly SolidColorBrush expectedBrush = new SolidColorBrush(Colors.Brown);

        private static TestBindingObject source;

        private static TestBindingDependencyObject target;

        private Establish context = () =>
            {
                source = new TestBindingObject();
                target = new TestBindingDependencyObject();

                IObserver<Brush> toSource = BindingFactory.CreateOneWayToSource(source, o => o.Brush);
                target.Bind(TestBindingDependencyObject.SolidColorBrushProperty, toSource);
            };

        private Because of = () => target.SolidColorBrush = expectedBrush;

        private It should_have_the_correct_brush = () => source.Brush.ShouldEqual(expectedBrush);
    }

    [Subject(typeof(DependencyObject))]
    public class when_a_binding_is_one_way_to_source_and_the_type_of_the_source_property_is_more_derived
    {
        private static readonly SolidColorBrush expectedBrush = new SolidColorBrush(Colors.Brown);

        private static TestBindingObject source;

        private static Border target;

        private Establish context = () =>
            {
                source = new TestBindingObject();
                target = new Border();

                IObserver<Brush> toSource = BindingFactory.CreateOneWayToSource<TestBindingObject, Brush>(
                    source, o => o.SolidColorBrush);
                target.Bind(Border.BorderBrushProperty, toSource);
            };

        private Because of = () => target.BorderBrush = expectedBrush;

        private It should_have_the_correct_brush = () => source.SolidColorBrush.ShouldEqual(expectedBrush);
    }

    [Subject(typeof(DependencyObject))]
    public class when_the_data_context_is_set_after_the_binding_has_been_created
    {
        private const string ExpectedValue = "Value";

        private static TextBlock target;

        private Establish context = () =>
            {
                target = new TextBlock(new Mock<ISpriteFont>().Object);
                IObservable<string> fromSource = BindingFactory.CreateOneWay<string>();
                target.Bind(TextBlock.TextProperty, fromSource);
                target.Measure(Size.Empty);
            };

        private Because of = () => target.DataContext = ExpectedValue;

        private It should_bind_to_the_data_context = () => target.Text.ShouldEqual(ExpectedValue);
    }

    [Subject(typeof(DependencyObject))]
    public class when_binding_to_the_data_context_and_the_data_context_is_changed
    {
        private const string NewDataContext = "New Data Context";

        private static TextBlock target;

        private Establish context = () =>
            {
                target = new TextBlock(new Mock<ISpriteFont>().Object) { DataContext = "Old Data Context" };
                IObservable<string> fromSource = BindingFactory.CreateOneWay<string>();
                target.Bind(TextBlock.TextProperty, fromSource);
                target.Measure(Size.Empty);
            };

        private Because of = () => target.DataContext = NewDataContext;

        private It should_use_the_new_data_context = () => target.Text.ShouldEqual(NewDataContext);
    }
}