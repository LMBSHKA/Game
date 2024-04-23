using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using Microsoft.Xna.Framework.Content;

namespace Project
{
    internal class Player : Sprite
    {
        private int _widthWindow = 800;
        private int _heightWindow = 480;

        private SpriteBatch _spriteBatch;

        private bool jump = false;

        public Player (Texture2D texture, Vector2 position) : base (texture, position) { }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (position.Y <= _heightWindow - texture.Height * 2)
            {
                position.Y += 2;
            }
       
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && position.X < (_widthWindow - texture.Width))
            {
                position.X += 5;
                
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left) && position.X > 0)
            {
                position.X -= 5;
            }
            if (!jump && Keyboard.GetState().IsKeyDown(Keys.Up) && position.Y > 0)
            {
                jump = true;
                for (int i = 0; i < 50; i++)
                {
                    position.Y -= 2;
                    
                }
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Up) && position.Y >= _heightWindow - texture.Height * 2)
            {
                jump = false;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down) && position.Y < _heightWindow - texture.Height * 2)
            {
                position.Y += 5;
                Debug.WriteLine(position.Y);
            }

        }
    }
}
