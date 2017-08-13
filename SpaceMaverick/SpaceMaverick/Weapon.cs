using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace SpaceMaverick
{
  public  class Weapon
    {
        public Vector2 Position;
        public Vector2 Speed;
        public Texture2D img;
        public Animation animation;
        public bool Active;
        public int Damage;
        public String Direction;
        public int Health;
        public int numPressed;
        public bool right;
        public Vector2 Plocation;
        public Weapon(bool right,int numPressed,Texture2D img, Vector2 Speed, Animation animation, int Damage, Vector2 Position,String Direction, int Health)
        {
            //this.Position = Position;
            this.Position =new Vector2(Position.X,Position.Y);
            this.img = img;
            this.Speed = Speed;
            this.animation = animation;
            this.Damage = Damage;
            Active = true;
            this.Direction = Direction;
            this.Health = Health;
            this.numPressed = numPressed;
            this.right = right;
            this.Plocation = Position;
        }

        public Weapon(Weapon x, Vector2 Position,Vector2 Speed)
        {
            
            this.Position = Position;
            //this.right = x.right;
            this.img = x.img;
            this.Speed = Speed;
            this.animation = new Animation(x.animation);
            this.Damage = x.Damage;
            Active = true;
            this.Direction = x.Direction;
            this.Health = x.Health;

        }
        public Weapon(Weapon x, Vector2 Position)
        {

            this.Position = Position;
            //this.right = x.right;
            this.img = x.img;
            this.Speed = x.Speed;
            this.animation = new Animation(x.animation);
            this.Damage = x.Damage;
            Active = true;
            this.Direction = x.Direction;
            this.Health = x.Health;

        }


        private void Movement()
        {
            if (numPressed == 0)
            {
                Position += Speed;
            }


            if (numPressed == 1)
            {
                Position += Speed;
            }
            if (numPressed == 2)
            {
                if (!right)
                {
                    Position += Speed;
                }
                else
                {
                    Position.Y += Speed.Y;
                    Position.X -= Speed.X;
                }
                if (Position.X - Plocation.X > 50)
                {
                    right = !right;

                }
                else if (Plocation.X - Position.X > 50)
                {
                    right = !right;

                }
        
            }
            if (numPressed == 3)
            {
                Position += Speed;
            }





            if (Direction == "UP")
            {
                if (Position.Y < 0)
                {
                    Active = false;
                    
                }
            }
            else if (Direction =="DOWN")
            {
                if (Position.Y > Game1.ClientWindow.Height)
                {
                    Active = false;
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            Movement();
            animation.Update(gameTime, Position);
        }

        public void Draw(SpriteBatch s1)
        {
            animation.Draw(s1);
        }

        public Rectangle CollisionRect()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, img.Width, img.Height);
        }




        
    }
}
