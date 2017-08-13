using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace SpaceMaverick
{
   public class PowerUp
    {
        Texture2D MyImg;
        Vector2 Position;
        Vector2 speed;
        public int IdNo;
        public bool Active;


        public PowerUp(Texture2D MyImg, Vector2 Position, Vector2 speed, int IdNo)
        {
            this.MyImg = MyImg;
            this.Position = Position;
            this.speed = speed;
            this.IdNo = IdNo;
            Active = true;
        }

        public void MoveMent()
        {
            Position += speed;
            if (Position.Y > Game1.ClientWindow.Height)
            {
                Active = true;
            }
        }

        public void Update()
        {
            MoveMent();
        }


        public Rectangle CollisionRect()
        {
            return new Rectangle((int)Position.X , (int)Position.Y , MyImg.Width, MyImg.Height);

        }

        public void Draw(SpriteBatch s1)
        {
            s1.Draw(MyImg, Position, Color.White);
        }

    }
}
