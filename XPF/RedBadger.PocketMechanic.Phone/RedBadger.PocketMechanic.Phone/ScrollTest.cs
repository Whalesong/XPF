namespace RedBadger.PocketMechanic.Phone
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Media;

    using Microsoft.Phone.Reactive;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using RedBadger.Xpf.Graphics;
    using RedBadger.Xpf.Input;
    using RedBadger.Xpf.Presentation.Controls;
    using RedBadger.Xpf.Presentation.Media;

    using Color = System.Windows.Media.Color;
    using SolidColorBrush = RedBadger.Xpf.Presentation.Media.SolidColorBrush;

    public class ScrollTest : DrawableGameComponent
    {
        private readonly Random random = new Random();

        private RootElement rootElement;

        private SpriteBatchAdapter spriteBatchAdapter;

        private SpriteFont spriteFont;

        public ScrollTest(Game game)
            : base(game)
        {
        }

        public override void Draw(GameTime gameTime)
        {
            this.spriteBatchAdapter.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            this.rootElement.Draw();
            this.spriteBatchAdapter.End();

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            this.rootElement.Update();
            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            this.spriteFont = this.Game.Content.Load<SpriteFont>("SpriteFont");
            this.spriteBatchAdapter = new SpriteBatchAdapter(this.GraphicsDevice);
            var spriteFontAdapter = new SpriteFontAdapter(this.spriteFont);

            var items = new ObservableCollection<string>();
            var itemsControl = new ItemsControl
                {
                    ItemTemplate = () =>
                        {
                            var textBlock = new TextBlock(spriteFontAdapter)
                                {
                                    Margin = new Thickness(0, 0, 0, 50), 
                                    Background = new SolidColorBrush(GetRandomColor(this.random))
                                };
                            textBlock.SetBinding(TextBlock.TextProperty, new Binding());
                            return textBlock;
                        }, 
                    ItemsSource = items
                };

            var renderer = new Renderer(this.spriteBatchAdapter, new PrimitivesService(this.GraphicsDevice));

            this.rootElement = new RootElement(this.GraphicsDevice.Viewport.ToRect(), renderer, new InputManager())
                {
                   Content = itemsControl 
                };

            Observable.Timer(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1)).ObserveOnDispatcher().Subscribe(
                l => items.Add(DateTime.Now.ToString()));
        }

        private static Color GetRandomColor(Random random)
        {
            int next = random.Next(3);
            switch (next)
            {
                case 0:
                    return Colors.Red;
                case 1:
                    return Colors.Blue;
                case 2:
                    return Colors.Yellow;
            }

            return Colors.Purple;
        }
    }
}