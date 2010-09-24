//-------------------------------------------------------------------------------------------------
// <auto-generated> 
// Marked as auto-generated so StyleCop will ignore BDD style tests
// </auto-generated>
//-------------------------------------------------------------------------------------------------

#pragma warning disable 169
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

namespace RedBadger.Xpf.Specs.Graphics.DrawingContextSpecs
{
    using Machine.Specifications;

    using Moq;

    using RedBadger.Xpf.Adapters.Xna.Graphics;
    using RedBadger.Xpf.Graphics;
    using RedBadger.Xpf.Media;
    using RedBadger.Xpf.Media.Imaging;

    using It = Machine.Specifications.It;

    [Subject(typeof(DrawingContext), "Text")]
    public class when_drawing_text : a_DrawingContext
    {
        private const string ExpectedString = "String Value";

        private static readonly Color expectedColor = Colors.Black;

        private static readonly Point expectedDrawPosition;

        private Because of = () =>
            {
                DrawingContext.DrawText(
                    SpriteFont.Object, ExpectedString, expectedDrawPosition, new SolidColorBrush(expectedColor));
                Renderer.Draw();
            };

        private It should_render_text =
            () =>
            SpriteBatch.Verify(
                batch => batch.DrawString(SpriteFont.Object, ExpectedString, expectedDrawPosition, expectedColor));
    }

    [Subject(typeof(DrawingContext), "Rectangle")]
    public class when_drawing_a_rectangle : a_DrawingContext
    {
        private static readonly SolidColorBrush expectedBrush = new SolidColorBrush(Colors.Blue);

        private static readonly Rect expectedRect = new Rect(10, 20, 30, 40);

        private Because of = () =>
            {
                DrawingContext.DrawRectangle(expectedRect, expectedBrush);
                Renderer.Draw();
            };

        private It should_render_a_rectangle =
            () => SpriteBatch.Verify(batch => batch.Draw(Moq.It.IsAny<ITexture>(), expectedRect, expectedBrush.Color));
    }

    [Subject(typeof(DrawingContext), "Image")]
    public class when_drawing_an_image : a_DrawingContext
    {
        private static readonly SolidColorBrush expectedColor = new SolidColorBrush(Colors.White);

        private static readonly Rect expectedRect = new Rect(10, 20, 30, 40);

        private static Mock<ITexture> expectedTexture;

        private Because of = () =>
            {
                expectedTexture = new Mock<ITexture>();
                DrawingContext.DrawImage(new Mock<TextureImage>(expectedTexture.Object).Object, expectedRect);
                Renderer.Draw();
            };

        private It should_render_an_image =
            () => SpriteBatch.Verify(batch => batch.Draw(expectedTexture.Object, expectedRect, expectedColor.Color));
    }

    [Subject(typeof(DrawingContext), "Rectangle")]
    public class when_resolving_offsets_for_a_rectangle : a_DrawingContext
    {
        private static readonly Vector absoluteOffset = new Vector(20, 30);

        private static readonly Rect rect = new Rect(10, 20, 30, 40);

        private Establish conetxt =
            () => UiElement.Setup(element => element.CalculateAbsoluteOffset()).Returns(absoluteOffset);

        private Because of = () =>
            {
                DrawingContext.DrawRectangle(rect, new SolidColorBrush(Colors.Blue));
                Renderer.PreDraw(UiElement.Object);
                Renderer.Draw();
            };

        private It should_render_with_the_correct_offset =
            () =>
            SpriteBatch.Verify(
                batch =>
                batch.Draw(
                    Moq.It.IsAny<ITexture>(), 
                    new Rect(absoluteOffset.X + rect.X, absoluteOffset.Y + rect.Y, rect.Width, rect.Height), 
                    Moq.It.IsAny<Color>()));
    }

    [Subject(typeof(DrawingContext), "Text")]
    public class when_resolving_offsets_for_text : a_DrawingContext
    {
        private static readonly Vector absoluteOffset = new Vector(20, 30);

        private static readonly Point textPosition = new Point(10, 20);

        private Establish context =
            () => UiElement.Setup(element => element.CalculateAbsoluteOffset()).Returns(absoluteOffset);

        private Because of = () =>
            {
                DrawingContext.DrawText(SpriteFont.Object, string.Empty, textPosition, new SolidColorBrush(Colors.Blue));
                Renderer.PreDraw(UiElement.Object);
                Renderer.Draw();
            };

        private It should_render_with_the_correct_offset =
            () =>
            SpriteBatch.Verify(
                batch =>
                batch.DrawString(
                    Moq.It.IsAny<ISpriteFont>(), 
                    Moq.It.IsAny<string>(), 
                    textPosition + absoluteOffset, 
                    Moq.It.IsAny<Color>()));
    }

    [Subject(typeof(DrawingContext), "Image")]
    public class when_resolving_offsets_for_an_image : a_DrawingContext
    {
        private static readonly Vector absoluteOffset = new Vector(20, 30);

        private static readonly Rect rect = new Rect(10, 20, 30, 40);

        private Establish context =
            () => UiElement.Setup(element => element.CalculateAbsoluteOffset()).Returns(absoluteOffset);

        private Because of = () =>
            {
                DrawingContext.DrawImage(new Mock<TextureImage>(new Mock<ITexture>().Object).Object, rect);
                Renderer.PreDraw(UiElement.Object);
                Renderer.Draw();
            };

        private It should_render_with_the_correct_offset =
            () =>
            SpriteBatch.Verify(
                batch =>
                batch.Draw(
                    Moq.It.IsAny<ITexture>(), 
                    new Rect(absoluteOffset.X + rect.X, absoluteOffset.Y + rect.Y, rect.Width, rect.Height), 
                    Moq.It.IsAny<Color>()));
    }

    [Subject(typeof(DrawingContext), "PreDraw")]
    public class when_resolving_offsets_at_the_origin : a_DrawingContext
    {
        private static readonly Vector absoluteOffset1 = new Vector(20, 30);

        private static readonly Vector absoluteOffset2 = Vector.Zero;

        private static readonly Rect rect = new Rect(0, 0, 30, 40);

        private static bool isFirst;

        private Establish context = () =>
            {
                isFirst = true;

                UiElement.Setup(element => element.CalculateAbsoluteOffset()).Returns(
                    () =>
                        {
                            Vector absoluteOffset = isFirst ? absoluteOffset1 : absoluteOffset2;
                            isFirst = false;
                            return absoluteOffset;
                        });
            };

        private Because of = () =>
            {
                DrawingContext.DrawRectangle(rect, new SolidColorBrush(Colors.Blue));
                Renderer.PreDraw(UiElement.Object);

                // Call GetDrawingContext again on *another* element - this forces PreDraw to reoccur,
                // but does not clear the DrawingContext of the element we want to re-evaluate on the 2nd PreDraw.
                Renderer.GetDrawingContext(new Mock<IElement>().Object);
                Renderer.PreDraw(UiElement.Object);

                Renderer.Draw();
            };

        private It should_render_at_the_origin =
            () =>
            SpriteBatch.Verify(
                batch =>
                batch.Draw(
                    Moq.It.IsAny<ITexture>(), 
                    new Rect(absoluteOffset2.X + rect.X, absoluteOffset2.Y + rect.Y, rect.Width, rect.Height), 
                    Moq.It.IsAny<Color>()));
    }
}