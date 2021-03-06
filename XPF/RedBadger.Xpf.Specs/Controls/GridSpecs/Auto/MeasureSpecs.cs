#region License
/* The MIT License
 *
 * Copyright (c) 2011 Red Badger Consulting
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
*/
#endregion

//-------------------------------------------------------------------------------------------------
// <auto-generated> 
// Marked as auto-generated so StyleCop will ignore BDD style tests
// </auto-generated>
//-------------------------------------------------------------------------------------------------

#pragma warning disable 169
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

namespace RedBadger.Xpf.Specs.Controls.GridSpecs.Auto
{
    using Machine.Specifications;

    using Moq;

    using RedBadger.Xpf.Controls;

    using It = Machine.Specifications.It;

    [Subject(typeof(Grid), "Measure - Auto")]
    public class when_an_element_is_added : a_Auto_Grid
    {
        private static readonly Size availableSize = new Size(100, 100);

        private static Mock<UIElement> child;

        private Establish context = () =>
            {
                child = new Mock<UIElement> { CallBase = true };
                child.Object.Width = 50;
                child.Object.Height = 60;

                Subject.Children.Add(child.Object);
            };

        private Because of = () => Subject.Measure(availableSize);

        private It should_have_a_desired_size_equal_to_that_of_its_child =
            () => Subject.DesiredSize.ShouldEqual(child.Object.DesiredSize);
    }

    [Subject(typeof(Grid), "Measure - Auto")]
    public class when_two_elements_are_added : a_Auto_Grid
    {
        private static readonly Size availableSize = new Size(100, 100);

        private static Mock<UIElement> largeChild;

        private static Mock<UIElement> smallChild;

        private Establish context = () =>
            {
                largeChild = new Mock<UIElement> { CallBase = true };
                largeChild.Object.Width = 50;
                largeChild.Object.Height = 60;

                smallChild = new Mock<UIElement> { CallBase = true };
                smallChild.Object.Width = 20;
                smallChild.Object.Height = 30;

                Subject.Children.Add(largeChild.Object);
                Subject.Children.Add(smallChild.Object);
            };

        private Because of = () => Subject.Measure(availableSize);

        private It should_have_a_desired_size_that_equal_to_that_of_the_largest_element =
            () => Subject.DesiredSize.ShouldEqual(largeChild.Object.DesiredSize);
    }

    [Subject(typeof(Grid), "Measure - Auto")]
    public class when_there_are_two_columns : a_Auto_Grid
    {
        private static readonly Size availableSize = new Size(100, 100);

        private static Mock<UIElement> largeChild;

        private static Mock<UIElement> smallChild;

        private Establish context = () =>
            {
                Subject.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });

                largeChild = new Mock<UIElement> { CallBase = true };
                largeChild.Object.Width = 50;
                largeChild.Object.Height = 60;
                Grid.SetColumn(largeChild.Object, 0);

                smallChild = new Mock<UIElement> { CallBase = true };
                smallChild.Object.Width = 20;
                smallChild.Object.Height = 30;
                Grid.SetColumn(smallChild.Object, 1);

                Subject.Children.Add(largeChild.Object);
                Subject.Children.Add(smallChild.Object);
            };

        private Because of = () => Subject.Measure(availableSize);

        private It should_have_a_desired_height_equal_to_that_of_the_highest_child =
            () => Subject.DesiredSize.Height.ShouldEqual(largeChild.Object.DesiredSize.Height);

        private It should_have_a_desired_width_equal_to_the_sum_of_its_children =
            () =>
            Subject.DesiredSize.Width.ShouldEqual(
                largeChild.Object.DesiredSize.Width + smallChild.Object.DesiredSize.Width);
    }

    [Subject(typeof(Grid), "Measure - Auto")]
    public class when_there_are_two_rows : a_Auto_Grid
    {
        private static readonly Size availableSize = new Size(100, 100);

        private static Mock<UIElement> largeChild;

        private static Mock<UIElement> smallChild;

        private Establish context = () =>
            {
                Subject.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });

                largeChild = new Mock<UIElement> { CallBase = true };
                largeChild.Object.Width = 50;
                largeChild.Object.Height = 60;
                Grid.SetRow(largeChild.Object, 0);

                smallChild = new Mock<UIElement> { CallBase = true };
                smallChild.Object.Width = 20;
                smallChild.Object.Height = 30;
                Grid.SetRow(smallChild.Object, 1);

                Subject.Children.Add(largeChild.Object);
                Subject.Children.Add(smallChild.Object);
            };

        private Because of = () => Subject.Measure(availableSize);

        private It should_have_a_desired_height_equal_to_the_sum_of_its_children =
            () =>
            Subject.DesiredSize.Height.ShouldEqual(
                largeChild.Object.DesiredSize.Height + smallChild.Object.DesiredSize.Height);

        private It should_have_a_desired_width_equal_to_that_of_the_widest_child =
            () => Subject.DesiredSize.Width.ShouldEqual(largeChild.Object.DesiredSize.Width);
    }

    [Subject(typeof(Grid), "Measure - Auto")]
    public class when_there_are_two_rows_and_two_columns : an_Auto_Grid_with_two_rows_and_two_columns
    {
        private Because of = () => Subject.Measure(AvailableSize);

        private It should_have_a_desired_height_equal_to_the_sum_of_the_tallest_children_in_each_row =
            () =>
            Subject.DesiredSize.Height.ShouldEqual(
                TopRightChild.Object.DesiredSize.Height + BottomRightChild.Object.DesiredSize.Height);

        private It should_have_a_desired_width_equal_to_the_sum_of_the_widest_children_in_each_column =
            () =>
            Subject.DesiredSize.Width.ShouldEqual(
                TopLeftChild.Object.DesiredSize.Width + TopRightChild.Object.DesiredSize.Width);
    }

    [Subject(typeof(Grid), "Measure - Auto")]
    public class when_a_child_element_gets_bigger : a_Auto_Grid
    {
        private static Mock<UIElement> child;

        private Establish context = () =>
            {
                child = new Mock<UIElement> { CallBase = true };
                child.Object.Width = 10;
                child.Object.Height = 20;
                Subject.Children.Add(child.Object);

                Subject.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
                Subject.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });

                Subject.Measure(AvailableSize);
            };

        private Because of = () =>
            {
                child.Object.Width = 30;
                child.Object.Height = 40;

                Subject.Measure(AvailableSize);
            };

        private It should_adjust_its_desired_size_accordingly = () => Subject.DesiredSize.ShouldEqual(new Size(30, 40));
    }

    [Subject(typeof(Grid), "Measure - Auto")]
    public class when_a_child_element_gets_smaller : a_Auto_Grid
    {
        private static Mock<UIElement> child;

        private Establish context = () =>
            {
                child = new Mock<UIElement> { CallBase = true };
                child.Object.Width = 30;
                child.Object.Height = 40;
                Subject.Children.Add(child.Object);

                Subject.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
                Subject.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });

                Subject.Measure(AvailableSize);
            };

        private Because of = () =>
            {
                child.Object.Width = 10;
                child.Object.Height = 20;

                Subject.Measure(AvailableSize);
            };

        private It should_adjust_its_desired_size_accordingly = () => Subject.DesiredSize.ShouldEqual(new Size(10, 20));
    }

    [Subject(typeof(Grid), "Measure Auto - Min and Max")]
    public class when_there_is_a_column_with_min_width_and_the_child_is_smaller : a_Auto_Grid
    {
        private const double ColumnMinWidth = 10;

        private static Mock<UIElement> child;

        private Establish context = () =>
            {
                ColumnOneDefinition.MinWidth = ColumnMinWidth;

                child = new Mock<UIElement> { CallBase = true };
                child.Object.Width = 5;
                child.Object.Height = 60;

                Subject.Children.Add(child.Object);
            };

        private Because of = () => Subject.Measure(AvailableSize);

        private It should_have_a_desired_height_equal_to_that_of_the_child =
            () => Subject.DesiredSize.Height.ShouldEqual(child.Object.DesiredSize.Height);

        private It should_have_a_desired_width_equal_to_the_min_width =
            () => Subject.DesiredSize.Width.ShouldEqual(ColumnMinWidth);
    }

    [Subject(typeof(Grid), "Measure Auto - Min and Max")]
    public class when_there_is_a_column_with_max_width_and_the_child_is_larger : a_Auto_Grid
    {
        private const double ColumnMaxWidth = 50;

        private static Mock<UIElement> child;

        private Establish context = () =>
            {
                ColumnOneDefinition.MaxWidth = ColumnMaxWidth;

                child = new Mock<UIElement> { CallBase = true };
                child.Object.Width = 500;
                child.Object.Height = 60;

                Subject.Children.Add(child.Object);
            };

        private Because of = () => Subject.Measure(AvailableSize);

        private It should_have_a_desired_height_equal_to_that_of_the_child =
            () => Subject.DesiredSize.Height.ShouldEqual(child.Object.DesiredSize.Height);

        private It should_have_a_desired_width_equal_to_the_max_width =
            () => Subject.DesiredSize.Width.ShouldEqual(ColumnMaxWidth);
    }

    [Subject(typeof(Grid), "Measure Auto - Min and Max")]
    public class when_there_is_a_row_with_min_height_and_the_child_is_smaller : a_Auto_Grid
    {
        private const double RowMinHeight = 10;

        private static Mock<UIElement> child;

        private Establish context = () =>
            {
                RowOneDefinition.MinHeight = RowMinHeight;

                child = new Mock<UIElement> { CallBase = true };
                child.Object.Width = 60;
                child.Object.Height = 5;

                Subject.Children.Add(child.Object);
            };

        private Because of = () => Subject.Measure(AvailableSize);

        private It should_have_a_desired_height_equal_to_the_min_height =
            () => Subject.DesiredSize.Height.ShouldEqual(RowMinHeight);

        private It should_have_a_desired_width_equal_to_that_of_the_child =
            () => Subject.DesiredSize.Width.ShouldEqual(child.Object.DesiredSize.Width);
    }

    [Subject(typeof(Grid), "Measure Auto - Min and Max")]
    public class when_there_is_a_row_with_max_height_and_the_child_is_larger : a_Auto_Grid
    {
        private const double RowMaxHeight = 50;

        private static Mock<UIElement> child;

        private Establish context = () =>
            {
                RowOneDefinition.MaxHeight = RowMaxHeight;

                child = new Mock<UIElement> { CallBase = true };
                child.Object.Width = 60;
                child.Object.Height = 500;

                Subject.Children.Add(child.Object);
            };

        private Because of = () => Subject.Measure(AvailableSize);

        private It should_have_a_desired_height_equal_to_the_max_height =
            () => Subject.DesiredSize.Height.ShouldEqual(RowMaxHeight);

        private It should_have_a_desired_width_equal_to_that_of_the_child =
            () => Subject.DesiredSize.Width.ShouldEqual(child.Object.DesiredSize.Width);
    }
}
