using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;

namespace Project
{
	public class Game1 : Game
	{
		private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;
		public int windowWidth = 800;
		public int windowHeight = 480;

		//Texture2D[] runningTextures;

		Texture2D backgroundTexture;
		Player player;
		List<Sprite> sprites;
		public Game1()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
		}

		protected override void Initialize()
		{
			// TODO: Add your initialization logic here
			_graphics.IsFullScreen = false;
			_graphics.PreferredBackBufferWidth = windowWidth;
			_graphics.PreferredBackBufferHeight = windowHeight;
			_graphics.ApplyChanges();
			base.Initialize();
		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);

			//runningTextures = new Texture2D[11];

			sprites = new();
			Texture2D playerTexture = Content.Load<Texture2D>("idle-with-weapon-1");
			Texture2D enemy = Content.Load<Texture2D>("walk-1");
			backgroundTexture = Content.Load<Texture2D>("background");

			sprites.Add(new Sprite(enemy, new Vector2(100, 100)));
			sprites.Add(new Sprite(enemy, new Vector2(400, 200)));
			sprites.Add(new Sprite(enemy, new Vector2(700, 300)));

			player = new Player(playerTexture, new Vector2(0, 360));

            sprites.Add(player);
            base.LoadContent();

        }

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();
			List<Sprite> killList = new();
			foreach (var sprite in sprites)
			{
				sprite.Update(gameTime);

				if (sprite != player && sprite.Rect.Intersects(player.Rect))
				{
					killList.Add(sprite);
				}
			}

			foreach (var kill in killList)
			{
				sprites.Remove(kill);
			}
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);
			_spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, 800, 480), Color.White);
            foreach (var sprite in sprites)
			{
				sprite.Draw(_spriteBatch);
			}
			_spriteBatch.End();
			base.Draw(gameTime);
		}
	}
}