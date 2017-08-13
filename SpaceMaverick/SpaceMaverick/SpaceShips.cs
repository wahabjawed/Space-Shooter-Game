using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace SpaceMaverick
{
    //All SpaceShips Inheirt from this class, Even Our own
   public abstract class SpaceShips
    {
        // The Position of the SpaceShips
       public Vector2 Position;
        //SpriteSheet for the Ship
       public Texture2D img;
        //The Object Which Animates the ship
       public Animation animation;
        //The Variable We Check to see if our ship should still be alive
       public bool Active;
        //The Speed with which the ship moves
       public Vector2 Speed;
       //The varable we use To make our collision Rectangles More acurate.
       public int CollisionOffset;
       public int Health;
       public float LayerDepth;
       public Texture2D EnemyFire;
       public Texture2D SingleFire;
       public int DamageCount = -1;

        public SpaceShips(Vector2 Position, Texture2D img, Animation animation, int Health, int CollisionOffset, Vector2 Speed)
        {
            this.Speed = Speed;
            this.CollisionOffset = CollisionOffset;
            this.Position = Position;
            this.img = img;
            this.animation = animation;
            this.Health = Health;
            //this.LayerDepth = LayerDepth;
            
            Active = true;

        }

        public SpaceShips(Vector2 Position, Texture2D img, Animation animation, int Health, int CollisionOffset, Vector2 Speed, Texture2D AnimationFire, Texture2D SingleFire)
        {
            this.Speed = Speed;
            this.CollisionOffset = CollisionOffset;
            this.Position = Position;
            this.img = img;
            this.animation = animation;
            this.Health = Health;
            //this.LayerDepth = LayerDepth;

            Active = true;
            EnemyFire = AnimationFire;
            this.SingleFire = SingleFire;
        }

        public Rectangle CollisionRect()
        {
            return new Rectangle((int)Position.X + CollisionOffset, (int)Position.Y + CollisionOffset, img.Width - (CollisionOffset * 2), img.Height - (CollisionOffset * 2));
                
        }

        public virtual void Update(GameTime gameTime)
        {
            animation.Update(gameTime, Position);
            Movement();

        }

        public virtual void Draw(SpriteBatch s1, GameTime gameTime)
        {
            animation.Draw(s1);
        }

        protected abstract void Movement();



        public abstract void Destruction(Texture2D EnemyTexture);
        

    }
}
