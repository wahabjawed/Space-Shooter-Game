

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace SpaceMaverick
{
    public class Enemy : SpaceShips
    {
        int EnemyFireDelay;
        int TimeElaspedSinceLastFire;
        public int EnemyCount = -1;
        public String EnemyDamage = "";
        public String EnemyName;
        protected List<Weapon> Fire = new List<Weapon>();
        public int AmountofFire;
        public int[] FireOffsets;
        public Vector2[] SpeedOfBullet;
       public Weapon MyWepon;
        
      
        public List<Weapon> fire
        {
            get { return Fire; }

        }
 
        public void ModedFire(List<Weapon> ModedFirer)
        {
            Fire = ModedFirer;
        }
            
        

        public Enemy(Vector2 Position, Texture2D img, Animation animation, int Health, int CollisionOffset, Vector2 Speed,Texture2D AnimationFire, Texture2D SingleFire,int EnemyFireDelay, int AmountOfFire, int[] FireOffset, String EnemyString,Weapon myWeapon)
            : base(Position, img, animation, Health, CollisionOffset, Speed,AnimationFire,SingleFire)
        {
            this.EnemyFireDelay = EnemyFireDelay;
            this.AmountofFire = AmountOfFire;
            this.FireOffsets = FireOffset;
            this.EnemyName = EnemyString;
            this.MyWepon = myWeapon;
        }

        public Enemy(Vector2 Position, Texture2D img, Animation animation, int Health, int CollisionOffset, Vector2 Speed, Texture2D AnimationFire, Texture2D SingleFire, int EnemyFireDelay, int AmountOfFire, int[] FireOffset, Vector2[] SpeedOfBullet ,String EnemyString, Weapon myWeapon)
            : base(Position, img, animation, Health, CollisionOffset, Speed, AnimationFire, SingleFire)
        {
            this.EnemyFireDelay = EnemyFireDelay;
            this.AmountofFire = AmountOfFire;
            this.FireOffsets = FireOffset;
            this.EnemyName = EnemyString;
            this.MyWepon = myWeapon;
            this.SpeedOfBullet = SpeedOfBullet;
        }

        protected override void Movement()
        {
            if (EnemyName == "Enemy1")
            {
                Position += Speed;

            }
            else if (EnemyName == "Enemy2")
            {
                Position += Speed;

            }
            else if (EnemyName == "Enemy3")
            {
                Position += Speed;

            }
            else if (EnemyName == "Enemy4")
            {
                Position += Speed;

            }
            else if (EnemyName == "Enemy5")
            {
                Position += Speed;

            }
            else if (EnemyName == "Enemy6")
            {
                Position += Speed;

            }
            else if (EnemyName == "Enemy7")
            {
                if (Position.Y < 250)
                {
                    Position += Speed;
                }
            }
            else if (EnemyName == "Enemy8")
            {
                Position += Speed;

            }
            else if (EnemyName == "Enemy9")
            {
                Position += Speed;

            }
            }

        public virtual void AddFire()
        {
            for(int i = 0 ; i< AmountofFire; i++)
            {   Fire.Add(new Weapon(MyWepon, new Vector2(Position.X + FireOffsets[i], Position.Y + 15)));

            SoundHandler.playSound(Game1.enemyFireSound);
            
            }
         }
        
        public override void Draw(SpriteBatch s1,GameTime gametime)
        {

            for (int i = Fire.Count - 1; i >= 0; i--)
            {

                Fire[i].Draw(s1);

            }
            
            base.Draw(s1,gametime);
        }


        public override void Destruction(Texture2D EnemyTexture) {

            animation.Sheet = EnemyTexture;
            animation.SheetSize.Y = 2;
            animation.SheetWidth.X = 95;
            animation.SheetWidth.Y = 102;
            DamageCount -= 1;
        }
        public override void Update(GameTime gametime)
        {
            //EnemyMiscStuff(gametime);

            if (Position.Y > Game1.ClientWindow.Height + 50)
            {
                Active = false;
            }
            base.Update(gametime);      
        }

        public virtual void EnemyMiscStuff(GameTime gametime)
        {
            if (EnemyCount < 0)
            {
                EnemyDamage = "";
            }
            else
            {
                EnemyDamage = "Damage";

                EnemyCount--;
            }

            TimeElaspedSinceLastFire += gametime.ElapsedGameTime.Milliseconds;

            if (Fire.Count < 5)
            {

                if (TimeElaspedSinceLastFire > EnemyFireDelay)
                {
                    AddFire();
                    TimeElaspedSinceLastFire = 0;
                }

            }
            if (Fire.Count > 0)
            {
                for (int i = Fire.Count - 1; i >= 0; i--)
                {
                    Fire[i].Update(gametime);
                    if (!Fire[i].Active)
                    {
                        Fire.RemoveAt(i);
                    }


                }
            }
        }
    }

}


