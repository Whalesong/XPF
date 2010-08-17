//-------------------------------------------------------------------------------------------------
// <auto-generated> 
// Marked as auto-generated so StyleCop will ignore BDD style tests
// </auto-generated>
//-------------------------------------------------------------------------------------------------

#pragma warning disable 169
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

namespace RedBadger.Xpf.Specs.Presentation.Controls.ButtonBaseSpecs
{
    using System.Collections.Generic;
    using System.Windows;

    using Machine.Specifications;

    using Moq;

    using RedBadger.Xpf.Graphics;
    using RedBadger.Xpf.Presentation.Controls;
    using RedBadger.Xpf.Presentation.Input;
    using RedBadger.Xpf.Presentation.Media;

    using It = Machine.Specifications.It;

    public abstract class a_ButtonBase_inside_a_RootElement_with_input_manager
    {
        protected static Mock<ButtonBase> ButtonBase;

        protected static Mock<IInputManager> InputManager;

        protected static Subject<MouseData> MouseData;

        protected static Mock<Renderer> Renderer;

        protected static RootElement RootElement;

        protected static Rect ViewPort = new Rect(0, 0, 100, 100);

        private Establish context = () =>
            {
                Renderer = new Mock<Renderer>(new Mock<ISpriteBatch>().Object, new Mock<IPrimitivesService>().Object)
                    {
                       CallBase = true 
                    };

                MouseData = new Subject<MouseData>();
                InputManager = new Mock<IInputManager>();
                InputManager.SetupGet(inputManager => inputManager.MouseData).Returns(MouseData);

                RootElement = new RootElement(ViewPort, Renderer.Object, InputManager.Object);

                ButtonBase = new Mock<ButtonBase> { CallBase = true };
                RootElement.Content = ButtonBase.Object;
            };
    }

    [Subject(typeof(ButtonBase), "Left mouse button down")]
    public class when_the_left_mouse_button_is_pressed_within_the_control_boundary :
        a_ButtonBase_inside_a_RootElement_with_input_manager
    {
        private Because of = () =>
            {
                RootElement.Update();
                MouseData.OnNext(new MouseData { Action = MouseAction.LeftButtonDown, Point = new Point(0, 0) });
            };

        private It should_set_that_the_button_is_pressed = () => ButtonBase.Object.IsPressed.ShouldBeTrue();
    }

    [Subject(typeof(ButtonBase), "Left mouse button down")]
    public class when_the_left_mouse_button_is_pressed_outside_the_control_boundary :
        a_ButtonBase_inside_a_RootElement_with_input_manager
    {
        private Because of = () =>
            {
                RootElement.Update();
                MouseData.OnNext(new MouseData { Action = MouseAction.LeftButtonDown, Point = new Point(101, 101) });
            };

        private It should_not_set_that_the_button_is_pressed = () => ButtonBase.Object.IsPressed.ShouldBeFalse();
    }

    [Subject(typeof(ButtonBase), "Disabled")]
    public class when_the_left_mouse_button_is_pressed_and_the_control_is_disabled :
        a_ButtonBase_inside_a_RootElement_with_input_manager
    {
        private Establish context = () => ButtonBase.Object.IsEnabled = false;

        private Because of = () =>
            {
                RootElement.Update();
                MouseData.OnNext(new MouseData { Action = MouseAction.LeftButtonDown, Point = new Point(0, 0) });
            };

        private It should_not_set_that_the_button_is_pressed = () => ButtonBase.Object.IsPressed.ShouldBeFalse();
    }

    [Subject(typeof(ButtonBase), "Click")]
    public class when_the_left_mouse_button_is_released_and_the_control_is_pressed :
        a_ButtonBase_inside_a_RootElement_with_input_manager
    {
        private static bool wasClicked;

        private Establish context = () =>
            {
                ButtonBase.Object.IsPressed = true;
                wasClicked = false;
                ButtonBase.Object.Click += (sender, args) => wasClicked = true;
            };

        private Because of = () =>
            {
                RootElement.Update();
                MouseData.OnNext(new MouseData { Action = MouseAction.LeftButtonUp, Point = new Point(0, 0) });
            };

        private It should_raise_the_click_event = () => wasClicked.ShouldBeTrue();

        private It should_set_that_the_button_is_released = () => ButtonBase.Object.IsPressed.ShouldBeFalse();
    }

    [Subject(typeof(ButtonBase), "Disabled")]
    public class when_the_left_mouse_button_is_released_and_the_control_is_pressed_but_disabled :
        a_ButtonBase_inside_a_RootElement_with_input_manager
    {
        private static bool wasClicked;

        private Establish context = () =>
            {
                ButtonBase.Object.IsEnabled = false;
                ButtonBase.Object.IsPressed = true;
                wasClicked = false;
                ButtonBase.Object.Click += (sender, args) => wasClicked = true;
            };

        private Because of = () =>
            {
                RootElement.Update();
                MouseData.OnNext(new MouseData { Action = MouseAction.LeftButtonUp, Point = new Point(0, 0) });
            };

        private It should_not_raise_the_click_event = () => wasClicked.ShouldBeFalse();

        private It should_not_set_that_the_button_is_released = () => ButtonBase.Object.IsPressed.ShouldBeTrue();
    }

    [Subject(typeof(ButtonBase), "Click")]
    public class when_the_left_button_is_pressed_and_then_released_inside_the_control_boundary :
        a_ButtonBase_inside_a_RootElement_with_input_manager
    {
        private static bool wasClicked;

        private Establish context = () =>
            {
                wasClicked = false;
                ButtonBase.Object.Click += (sender, args) => wasClicked = true;
            };

        private Because of = () =>
            {
                RootElement.Update();
                MouseData.OnNext(new MouseData { Action = MouseAction.LeftButtonDown, Point = new Point(0, 0) });
                MouseData.OnNext(new MouseData { Action = MouseAction.LeftButtonUp, Point = new Point(0, 0) });
            };

        private It should_raise_the_click_event = () => wasClicked.ShouldBeTrue();
    }

    [Subject(typeof(ButtonBase), "Click")]
    public class when_the_left_button_is_pressed_and_then_released_outside_the_control_boundary :
        a_ButtonBase_inside_a_RootElement_with_input_manager
    {
        private static bool wasClicked;

        private Establish context = () =>
            {
                wasClicked = false;
                ButtonBase.Object.Click += (sender, args) => wasClicked = true;
            };

        private Because of = () =>
            {
                RootElement.Update();
                MouseData.OnNext(new MouseData { Action = MouseAction.LeftButtonDown, Point = new Point(0, 0) });
                MouseData.OnNext(new MouseData { Action = MouseAction.LeftButtonUp, Point = new Point(101, 101) });
            };

        private It should_not_raise_the_click_event = () => wasClicked.ShouldBeFalse();
    }

    [Subject(typeof(ButtonBase), "Mouse Capture")]
    public class
        when_the_left_button_is_pressed_inside_the_boundary_and_then_moved_outside_the_boundary_and_back_in_again_and_then_released_over_the_control :
            a_ButtonBase_inside_a_RootElement_with_input_manager
    {
        private static bool state1;

        private static bool state2;

        private static bool state3;

        private static bool state4;

        private static bool state5;

        private static bool state6;

        private Establish context = () =>
            {
                state5 = false;
                ButtonBase.Object.Click += (sender, args) => state5 = true;
            };

        private Because of = () =>
            {
                RootElement.Update();
                state1 = ButtonBase.Object.IsPressed;
                MouseData.OnNext(new MouseData { Action = MouseAction.LeftButtonDown, Point = new Point(0, 0) });
                state2 = ButtonBase.Object.IsPressed;
                MouseData.OnNext(new MouseData { Action = MouseAction.Move, Point = new Point(101, 101) });
                state3 = ButtonBase.Object.IsPressed;
                MouseData.OnNext(new MouseData { Action = MouseAction.Move, Point = new Point(99, 99) });
                state4 = ButtonBase.Object.IsPressed;
                MouseData.OnNext(new MouseData { Action = MouseAction.LeftButtonUp, Point = new Point(10, 10) });
                state6 = ButtonBase.Object.IsPressed;
            };

        private It should_1_not_be_pressed_initially = () => state1.ShouldBeFalse();

        private It should_2_be_pressed_while_the_mouse_is_initially_inside = () => state2.ShouldBeTrue();

        private It should_3_not_be_pressed_when_the_mouse_moves_out = () => state3.ShouldBeFalse();

        private It should_4_be_pressed_when_the_mouse_moves_back_in = () => state4.ShouldBeTrue();

        private It should_5_raise_the_click = () => state5.ShouldBeTrue();

        private It should_6_not_be_pressed_after_the_click_is_raised = () => state6.ShouldBeFalse();
    }
}