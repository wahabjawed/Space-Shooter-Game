using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace SpaceMaverick
{
   public class MotherShip : SpaceShips
    {
        

        public MotherShip(Vector2 Position, Texture2D img, Animation animation, int Health, int CollisionOffset, Vector2 Speed)
            : base(Position,img,animation,Health,CollisionOffset,Speed)
        {
           
        }

        public override void Destruction(Texture2D EnemyTexture)
        {

            animation.Sheet = EnemyTexture;
            animation.SheetSize.Y = 2;
            animation.SheetWidth.X = 95;
            animation.SheetWidth.Y = 102;

        }
        protected override void Movement()
        {
            KeyboardState key = Keyboard.GetState();

            if (key.IsKeyDown(Keys.Up))
            {
                Position.Y -= Speed.Y;
                
            }else if (key.IsKeyDown(Keys.Down))

            {
                Position.Y += Speed.Y;
            }else if (key.IsKeyDown(Keys.Left))
            {
                Position.X -= Speed.X;
                
                if (!Game1.MotherDamage.Equals("Damage"))
                {
                    Game1.MotherName = "MotherShip" + Game1.MotherShipIndex + "Right";
                }
                else {
                    Game1.MotherName = "MotherShip" + Game1.MotherShipIndex + Game1.MotherDamage;
                }
            }else if (key.IsKeyDown(Keys.Right))
            {
                Position.X += Speed.X;
                if (!Game1.MotherDamage.Equals("Damage"))
                {
                    Game1.MotherName = "MotherShip" + Game1.MotherShipIndex + "Left";
                }
                else
                {
                    Game1.MotherName = "MotherShip" + Game1.MotherShipIndex + Game1.MotherDamage;
                }
            
            } else {
                Game1.MotherName = "MotherShip"+Game1.MotherShipIndex + Game1.MotherDamage;
            }
        }
        public void InBoundry(int width,int height)
        {
            if (Position.X < 0)
                Position.X = 0;
           
            if (Position.Y < 0)
                Position.Y = 0;
            if (Position.X > width - 95)
                Position.X = width - 95;
            if (Position.Y > height - 100)
                Position.Y = height - 100;
        }
        public void Fire()
        {

        }

        public override void Update(GameTime gametime)
        {
            base.Update(gametime);
            
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                Fire();
            }
        }
    }
}
