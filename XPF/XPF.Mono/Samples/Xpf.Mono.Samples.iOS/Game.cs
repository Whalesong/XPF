using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace Xpf.Mono.Samples.iOS
{
	public class Game1:Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		public Game1()
		{
			graphics = new GraphicsDeviceManager (this);
            Content.RootDirectory = "Content/XpfSamples/S01";
			graphics.IsFullScreen = true;
		}

        protected override void Initialize()
        {
            //this.Components.Add(new Xpf.Mono.Samples.Android.Samples.S01.MyComponent(this));
            //this.Components.Add(new Xpf.Mono.Samples.Android.Samples.S05.WithoutBindingFactory.MyComponent(this));
            //this.Components.Add(new Xpf.Mono.Samples.Android.Samples.S05.WithBindingFactory.MyComponent(this));
            this.Components.Add(new Xpf.Mono.Samples.iOS.Samples.R01.MyComponent(this));
            base.Initialize();
        }

		protected override void LoadContent()
		{
		}

		protected override void Update(GameTime gameTime)
		{
			base.Update (gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear (Color.CornflowerBlue);


			base.Draw (gameTime);
		}
	}
}

