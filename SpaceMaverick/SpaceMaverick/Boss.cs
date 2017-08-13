using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceMaverick
{
  public  class Boss : Enemy
    {
        int chk = 0;
        bool switchs=true;
        int level;
        public Boss(int level,Vector2 Position, Texture2D img, Animation animation, int Health, int CollisionOffset, Vector2 Speed, Texture2D AnimationFire, Texture2D SingleFire, int EnemyFireDelay, int AmountOfFire, int[] FireOffset, Vector2[] SpeedOfBullet,String EnemyString, Weapon myWeapon)
            : base(Position, img, animation, Health, CollisionOffset, Speed, AnimationFire, SingleFire, EnemyFireDelay, AmountOfFire, FireOffset, SpeedOfBullet,EnemyString, myWeapon)
        {
            this.level = level;
        }
       
      // public override void EnemyMiscStuff(Microsoft.Xna.Framework.GameTime gametime)
        //{
        //}

        public override void AddFire()
        {
            for (int i = 0; i < AmountofFire; i++)
            {
                Fire.Add(new Weapon(MyWepon, new Vector2(Position.X + FireOffsets[i], Position.Y + 15), SpeedOfBullet[i]));
                SoundHandler.playSound(Game1.enemyFireSound);
                
            }
        }
        protected override void Movement()
        {
            if (level == 1)
            {
                if (Position.Y < 20)
                {
                    Position.Y += Speed.Y;
                }
                else
                {
                    Position.X += Speed.X;

                    if (Position.X >= Game1.ClientWindow.Width - 300)
                    {
                        switchs = true;
                        Speed.X = -4;
                    }
                    if (Position.X < 20)
                    {
                        switchs = false;
                        Speed.X = 4;
                    }

                    if (switchs)
                    {
                        
                    }
                    if (!switchs)
                    {
                        
                    }

                }
                
            }


            if (level == 2 )
            {
                if (Position.Y < 20)
                {
                    Position.Y += Speed.Y;
                }
                else
                {
                    Position.X += Speed.X;

                    if (Position.X >= Game1.ClientWindow.Width - 300)
                    {
                        switchs = true;
                        Speed.X = -4;
                    }
                    if (Position.X < 20)
                    {
                        switchs = false;
                        Speed.X = 4;
                    }

                    if (switchs)
                    {

                    }
                    if (!switchs)
                    {

                    }

                }
            
            }


            if (level == 3)
            {
                if (Position.Y < 20)
                {
                    Position.Y += Speed.Y;
                }
                else
                {
                    Position.X += Speed.X;

                    if (Position.X >= Game1.ClientWindow.Width - 300)
                    {
                        switchs = true;
                        Speed.X = -4;
                    }
                    if (Position.X < 20)
                    {
                        switchs = false;
                        Speed.X = 4;
                    }

                    if (switchs)
                    {

                    }
                    if (!switchs)
                    {

                    }

                }
            
            }

            if (level == 4)
            {
                if (Position.Y < 20)
                {
                    Position.Y += Speed.Y;
                }
                else
                {
                    Position.X += Speed.X;

                    if (Position.X > Game1.ClientWindow.Width - 300)
                    {
                        Speed.X = -4;
                    }
                    if (Position.X < 300)
                    {
                        Speed.X = 4;
                    }

                }

            }

            if (level == 5)
            {
                if (Position.Y < 20)
                {
                    Position.Y += Speed.Y;
                }
                else
                {
                    Position.X += Speed.X;

                    if (Position.X > Game1.ClientWindow.Width - 300)
                    {
                        Speed.X = -4;
                    }
                    if (Position.X < 300)
                    {
                        Speed.X = 4;
                    }

                }

            }

            if (level == 6)
            {
                if (Position.Y < 20)
                {
                    Position.Y += Speed.Y;
                }
                else
                {
                    Position.X += Speed.X;

                    if (Position.X > Game1.ClientWindow.Width - 300)
                    {
                        Speed.X = -4;
                    }
                    if (Position.X < 300)
                    {
                        Speed.X = 4;
                    }

                }

            }

            if (level == 7)
            {
                if (Position.Y < 20)
                {
                    Position.Y += Speed.Y;
                }
                else
                {
                    Position.X += Speed.X;

                    if (Position.X > Game1.ClientWindow.Width - 300)
                    {
                        Speed.X = -4;
                    }
                    if (Position.X < 300)
                    {
                        Speed.X = 4;
                    }

                }

            }

            if (level == 8)
            {
                if (Position.Y < 20)
                {
                    Position.Y += Speed.Y;
                }
                else
                {
                    Position.X += Speed.X;

                    if (Position.X > Game1.ClientWindow.Width - 300)
                    {
                        Speed.X = -4;
                    }
                    if (Position.X < 300)
                    {
                        Speed.X = 4;
                    }

                }

            }

            if (level == 9)
            {
                if (Position.Y < 20)
                {
                    Position.Y += Speed.Y;
                }
                else
                {
                    Position.X += Speed.X;

                    if (Position.X > Game1.ClientWindow.Width - 300)
                    {
                        Speed.X = -4;
                    }
                    if (Position.X < 300)
                    {
                        Speed.X = 4;
                    }

                }

            }

         



        }

    }
}
