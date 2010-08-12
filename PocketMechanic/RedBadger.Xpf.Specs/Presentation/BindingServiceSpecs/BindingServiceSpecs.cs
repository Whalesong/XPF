//-------------------------------------------------------------------------------------------------
// <auto-generated> 
// Marked as auto-generated so StyleCop will ignore BDD style tests
// </auto-generated>
//-------------------------------------------------------------------------------------------------

#pragma warning disable 169
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

namespace RedBadger.Xpf.Specs.Presentation.BindingServiceSpecs
{
    using System.ComponentModel;
    using System.Windows.Data;

    using Machine.Specifications;

    using Moq;

    using RedBadger.Xpf.Graphics;
    using RedBadger.Xpf.Presentation;
    using RedBadger.Xpf.Presentation.Controls;

    using It = Machine.Specifications.It;

    public class BindingObject : INotifyPropertyChanged
    {
        private float myWidth;

        public event PropertyChangedEventHandler PropertyChanged;

        public float MyWidth
        {
            get
            {
                return this.myWidth;
            }

            set
            {
                this.myWidth = value;
                this.InvokePropertyChanged(new PropertyChangedEventArgs("MyWidth"));
            }
        }

        public void InvokePropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }

    [Subject(typeof(TextBlock), "Binding")]
    public class when_the_width_of_a_textblock_is_set_through_a_binding
    {
        private const float ExpectedWidth = 100f;

        private static readonly BindingObject bindingObject = new BindingObject();

        private static TextBlock textBlock;

        private Establish context = () =>
            {
                textBlock = new TextBlock(new Mock<ISpriteFont>().Object);
                textBlock.BindingFor(UIElement.WidthProperty).Is(new Binding("MyWidth") { Source = bindingObject });
            };

        private Because of = () => bindingObject.MyWidth = ExpectedWidth;

        private It should_have_the_correct_width = () => textBlock.Width.ShouldEqual(ExpectedWidth);
    }

    [Subject(typeof(TextBlock), "Binding")]
    public class when_the_width_of_a_textblock_is_set_and_the_binding_is_two_way
    {
        private const float ExpectedWidth = 100f;

        private static readonly BindingObject bindingObject = new BindingObject();

        private static TextBlock textBlock;

        private Establish context = () =>
            {
                textBlock = new TextBlock(new Mock<ISpriteFont>().Object);
                textBlock.BindingFor(UIElement.WidthProperty).Is(new Binding("MyWidth") { Source = bindingObject, Mode = BindingMode.TwoWay});
            };

        private Because of = () => textBlock.Width = ExpectedWidth;

        private It should_update_the_bound_property = () => bindingObject.MyWidth.ShouldEqual(ExpectedWidth);
    }
}