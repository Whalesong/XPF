using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using RedBadger.Xpf;
using RedBadger.Xpf.Adapters.Xna.Graphics;
using RedBadger.Xpf.Adapters.Xna.Input;
using RedBadger.Xpf.Controls;
using RedBadger.Xpf.Data;
using RedBadger.Xpf.Media;

using Color = RedBadger.Xpf.Media.Color;

namespace Xpf.Mono.Samples.Android.Samples.R01
{
    public class MyComponent : DrawableGameComponent
    {
        private RootElement rootElement;
        private SpriteBatchAdapter spriteBatchAdapter;

        public MyComponent(Game game)
            : base(game)
        { }

        public override void Draw(GameTime gameTime)
        {
            this.rootElement.Draw();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            this.rootElement.Update();
            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            spriteBatchAdapter = new SpriteBatchAdapter(new SpriteBatch(this.GraphicsDevice));
            var primativesService = new PrimitivesService(this.GraphicsDevice);
            var renderer = new Renderer(this.spriteBatchAdapter, primativesService);
            rootElement = new RootElement(this.GraphicsDevice.Viewport.ToRect(), renderer, new InputManager());

            var spriteFont = this.Game.Content.Load<SpriteFont>("MySpriteFont");
            var spriteFontAdapter = new SpriteFontAdapter(spriteFont);
            var colors = new List<SolidColorBrush>
                {
                    new SolidColorBrush(Colors.Red),
                    new SolidColorBrush(Colors.Blue),
                    new SolidColorBrush(Colors.Yellow)
                };

            var itemsControl = new ItemsControl
            {
                ItemsPanel = new StackPanel { Orientation = Orientation.Vertical },
                ItemsSource = colors,
                ItemTemplate = dataContext =>
                {
                    var border = new Border
                    {
                        Width = 50,
                        Height = 50,
                        Margin = new Thickness(10),
                        Background = new SolidColorBrush(Colors.Gray)
                    };
                    border.Bind(Border.BackgroundProperty, BindingFactory.CreateOneWay<Brush>());
                    return border;
                }
            };

            var scrollViewer = new ScrollViewer
            {
                Width = 100,
                Height = 100,
                IsEnabled = true
            };
            scrollViewer.Content = new ScrollContentPresenter
            {
                Content = itemsControl
            };
            this.rootElement.Content = scrollViewer;
            base.LoadContent();
        }
    }
}