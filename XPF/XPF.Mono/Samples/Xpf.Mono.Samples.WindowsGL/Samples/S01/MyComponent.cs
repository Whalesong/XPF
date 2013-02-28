﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using RedBadger.Xpf;
using RedBadger.Xpf.Adapters.Xna.Graphics;
using RedBadger.Xpf.Controls;
using RedBadger.Xpf.Media;

namespace Xpf.Mono.Samples.WindowsGL.Samples.S01
{
    using Color = RedBadger.Xpf.Media.Color;

    public class MyComponent : DrawableGameComponent
    {
        private RootElement rootElement;

        private SpriteBatchAdapter spriteBatchAdapter;

        public MyComponent(Game game)
            : base(game)
        {
        }

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
            this.spriteBatchAdapter = new SpriteBatchAdapter(new SpriteBatch(this.GraphicsDevice));
            var primitivesService = new PrimitivesService(this.GraphicsDevice);
            var renderer = new Renderer(this.spriteBatchAdapter, primitivesService);

            this.rootElement = new RootElement(this.GraphicsDevice.Viewport.ToRect(), renderer);

            var spriteFont = this.Game.Content.Load<SpriteFont>("MySpriteFont");
            var spriteFontAdapter = new SpriteFontAdapter(spriteFont);

            var grid = new Grid
            {
                Background = new SolidColorBrush(Colors.White),
                RowDefinitions =
                        {
                           new RowDefinition(), new RowDefinition { Height = new GridLength(320) }, new RowDefinition() 
                        },
                ColumnDefinitions =
                        {
                            new ColumnDefinition { Width = new GridLength(0.5,GridUnitType.Star) }, 
                            new ColumnDefinition { Width = new GridLength(0.5,GridUnitType.Star) }
                        }
            };
            grid.HorizontalAlignment = HorizontalAlignment.Stretch;
            this.rootElement.Content = grid;

            var topLeftBorder = new Border
            {
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(0, 0, 0, 2),
                Child = new TextBlock(spriteFontAdapter) { Text = "Score: 5483", Margin = new Thickness(10) }
            };
            Grid.SetRow(topLeftBorder, 0);
            Grid.SetColumn(topLeftBorder, 0);
            grid.Children.Add(topLeftBorder);

            var topRightBorder = new Border
            {
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(0, 0, 0, 2),
                Child =
                    new TextBlock(spriteFontAdapter)
                    {
                        Text = "High: 9999",
                        Margin = new Thickness(10),
                        HorizontalAlignment = HorizontalAlignment.Right
                    }
            };
            Grid.SetRow(topRightBorder, 0);
            Grid.SetColumn(topRightBorder, 1);
            grid.Children.Add(topRightBorder);

            var bottomLeftBorder = new Border
            {
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(0, 2, 0, 0),
                Background = new SolidColorBrush(new Color(106, 168, 79, 255)),
                Child =
                    new TextBlock(spriteFontAdapter)
                    {
                        Text = "Lives: 3",
                        Margin = new Thickness(10),
                        VerticalAlignment = VerticalAlignment.Bottom
                    }
            };
            Grid.SetRow(bottomLeftBorder, 2);
            Grid.SetColumn(bottomLeftBorder, 0);
            grid.Children.Add(bottomLeftBorder);

            var bottomRightBorder = new Border
            {
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(0, 2, 0, 0),
                Background = new SolidColorBrush(new Color(106, 168, 79, 255))
            };
            Grid.SetRow(bottomRightBorder, 2);
            Grid.SetColumn(bottomRightBorder, 1);
            grid.Children.Add(bottomRightBorder);
        }
    }
}
